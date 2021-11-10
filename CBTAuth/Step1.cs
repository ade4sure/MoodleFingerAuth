using CBTAuth.Dtos;
using SecuGen.SecuBSPPro.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBTAuth
{
    public partial class Step1 : Form
    {
        private SecuBSPMx m_SecuBSP;
        private string m_EnrollFIRText;
        private string m_CaptureFIRText;
        private bool m_DeviceOpened;
        private EnrollDto Verified;
        public Step1()
        {
            InitializeComponent();
        }

        public async Task<StudentDto> GetStudent(string matno)
        {
            StudentDto StudJSON = new StudentDto() { Name = "Error Occured!", ImageURL = "/images/Avatar.png" }; 
            //login.Client.BaseAddress = new Uri(GlobalClass.BaseURL);
            HttpResponseMessage ResMessage = null;

            var model = new GetStudentDto()
            {
                MatNo = matno,
                CourseCode = GlobalClass.CCode,
                hall = GlobalClass.HallName
            };

            try
            {
                //var stringTask = login.Client.GetFromJsonAsync<StudentDto>("/api/v1/services/student/" + model);      //_v1
                var stringTask = login.Client.PostAsJsonAsync("/api/v2/services/student", model);

                ResMessage = stringTask.Result;
                
            }
            catch (Exception)
            {
                return new StudentDto() { Name = "Error Occured!", ImageURL = "/images/Avatar.png" };
            }

            if (ResMessage.IsSuccessStatusCode)
            {

                var readTask = ResMessage.Content.ReadFromJsonAsync<StudentDto>();

                StudJSON = readTask.Result;

                StudJSON.ImageURL = GlobalClass.BaseURL + StudJSON.ImageURL;

                return StudJSON;
            }

            return StudJSON;
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            List<CourseDto> Courses;
            //login.Client.BaseAddress = new Uri(GlobalClass.BaseURL);

            try
            {
                var stringTask = login.Client.GetFromJsonAsync<List<CourseDto>>("/api/v1/services/getcourses/" + GlobalClass.HallName);

                Courses = stringTask.Result;

            }
            catch (Exception)
            {
                Courses = new List<CourseDto>();
            }

            return Courses;
        }

        public async Task<EnrollDto> EnrollStudent(EnrollDto model)
        {
            var enrol = new EnrollDto();

            HttpResponseMessage ResMessage = null;



            var stringTask = login.Client.PostAsJsonAsync("/api/v2/services/enroll", model);
            try
            {
                ResMessage = stringTask.Result;
            }
            catch (Exception)
            {

            }

            if (ResMessage.IsSuccessStatusCode)
            {
                var readTask = ResMessage.Content.ReadFromJsonAsync<EnrollDto>();

                enrol = readTask.Result;

                return enrol;
            }

            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatno.Text.Trim()))
            {
                return;
            }

            btnAuth.Enabled = false;
            //var lg = new login();
            var stud = GetStudent(txtMatno.Text.Trim()).Result;
            lblStdName.Text = stud.Name;
            if (!stud.Name.ToLower().Contains("not found"))
            {
                m_EnrollFIRText = stud.FIR;
                this.AcceptButton = btnAuth;
                btnAuth.Enabled = true;
            }
            pikStudent.ImageLocation = stud.ImageURL;

        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            EnrollDto verif;

            Verified = null;
            try
            {
                verif = Verify(m_EnrollFIRText);
            }

            catch (Exception ex)
            {

                MessageBox.Show("Internal Error!", "Unknown Finger");

                verif = new EnrollDto();
            }
            // verif = verif == false ? true : true; //Remove for production 

            if (verif != null)
            {
                //Create a PrintDocument object  
                PrintDocument pd = new PrintDocument();

                //Set PrinterName as the selected printer in the printers list  
                pd.PrinterSettings.PrinterName = comboPrinters.SelectedItem.ToString();

                //Add PrintPage event handler  
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                //Print the document  
                pd.Print();

                lblStdName.Text = "";
            }


            txtMatno.Clear();
            txtMatno.Select();
            this.AcceptButton = btnSearch;
        }

        //The PrintPage event handler   
        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {

            //Get the Graphics object  
            Graphics g = ev.Graphics;

            //Create a font Arial with size 16  
            Font font = new Font("Calibri", 13);
            Font fontB = new Font("Arial", 11, FontStyle.Bold);

            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(Color.Black);

            //Draw "Hello Printer!";  
            g.DrawString("Course:  " + Verified.CourseCode, new Font("Arial", 10), brush, new Rectangle(20, 0, 350, 50));
            g.DrawString("Username =  ", fontB, brush, new Rectangle(20, 20, 350, 50));
            g.DrawString(Verified.MatNo, font, brush, new Rectangle(120, 20, 350, 50));
            g.DrawString("Password =  ", fontB, brush, new Rectangle(20, 50, 400, 50));
            g.DrawString(Verified.Pwd.ToUpper(), font, brush, new Rectangle(120, 50, 400, 50));
            g.DrawString("PrintDate: " + Verified.EnrollDate.ToString("dd/MMM/yyyy hh:mm tt"), new Font("Arial", 9), brush, new Rectangle(20, 80, 400, 50));

        }

        private EnrollDto Verify(string m_EnrollFIR)
        {
            BSPError err;


            if (m_EnrollFIR == "")
            {
                return null;
            }

            m_SecuBSP.CaptureWindowOption.WindowStyle = (int)WindowStyle.POPUP;


            m_SecuBSP.CaptureWindowOption.ShowFPImage = true;

            m_SecuBSP.CaptureWindowOption.FingerWindow = (IntPtr)0;


            err = m_SecuBSP.Verify(m_EnrollFIR);

            //var rnG1 = new RandomGenerator();

            if (err == BSPError.ERROR_NONE)
            {
                if (m_SecuBSP.IsMatched)
                {
                    var rnG = new RandomGenerator();
                    //Enroll student
                    var enrol = new EnrollDto()
                    {
                        MatNo = txtMatno.Text.Trim(),
                        CourseCode = comboCourses.Text,
                        Pwd = rnG.RandomPassword().ToLower()
                    };
                    var bol = EnrollStudent(enrol).Result;
                    if (bol != null)
                    {
                        Verified = enrol;
                        return enrol;
                    }
                }
                else return null;
            }
            return null;

        }


        string MakeHexaDecimal(Int32 numbers, Int32 digit)
        {
            string dest_str = "0000000000000000"; // digit can not exceed 16

            string str = Convert.ToString(numbers, 16);
            Int32 len = str.Length;

            if (len > digit)
                dest_str = "";
            else
                dest_str = dest_str.Substring(0, digit - len) + str;

            return dest_str;
        }




        private void Step1_Load(object sender, EventArgs e)
        {


            m_DeviceOpened = false;

            m_SecuBSP = new SecuBSPMx();


            m_EnrollFIRText = "";
            m_CaptureFIRText = "";


            EnumBtn_Click_1(sender, e);

            //Get all available printers and add them to the combo box  
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                comboPrinters.Items.Add(printer.ToString());
            }
            comboPrinters.SelectedIndex = 0;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnOpenDevice_Click_1(object sender, EventArgs e)
        {
            BSPError err;

            if (m_DeviceOpened)
            {
                m_SecuBSP.CloseDevice();
                m_DeviceOpened = false;
            }

            // Get Selected device 
            string selected_device = DeviceIDCombo.Text;
            selected_device = selected_device.Substring(0, 6);
            Int16 device_id = Convert.ToInt16(selected_device.Substring(0, 6), 16);

            m_SecuBSP.DeviceID = device_id;

            err = m_SecuBSP.OpenDevice();
            if (err != BSPError.ERROR_NONE)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            GlobalClass.CCode = comboCourses.Text;

            m_DeviceOpened = true;
            btnOpenDevice.Enabled = false;
            EnumBtn.Enabled = false;

            comboCourses.Enabled = false;
            comboPrinters.Enabled = false;
            DeviceIDCombo.Enabled = false;



        }

        private void EnumBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;
            DeviceIDCombo.Items.Clear();


            err = m_SecuBSP.EnumerateDevice();
            if (err == BSPError.ERROR_NONE)
            {
                for (int i = 0; i < m_SecuBSP.DeviceNum; i++)
                {
                    Int16 device_id = m_SecuBSP.GetDeviceID(i);

                    string device_id_info;
                    device_id_info = "0x" + MakeHexaDecimal(device_id, 4) + "  ("
                       + m_SecuBSP.GetDeviceName(device_id) + ","
                       + m_SecuBSP.GetDeviceInstanceNum(device_id) + ")";

                    DeviceIDCombo.Items.Add(device_id_info);

                }
                if (m_SecuBSP.DeviceNum > 0) DeviceIDCombo.SelectedIndex = 0;
            }
            else MessageBox.Show(err.ToString());

            var Courses = GetCourses().Result;
            foreach (var crs in Courses)
            {
                comboCourses.Items.Add(crs.Code);
            }
            if (Courses.Count() > 0) comboCourses.SelectedIndex = 0;
        }
    }
}
