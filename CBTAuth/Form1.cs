using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecuGen.SecuBSPPro.Windows;

namespace CBTAuth
{
    public partial class Form1 : Form
    {
        private SecuBSPMx m_SecuBSP = new SecuBSPMx();
        private string m_EnrollFIRText;
        private string m_CaptureFIRText;
        private bool m_DeviceOpened;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DeviceIDCombo.Items.Add("0x00FF (Auto Detect)");
            m_DeviceOpened = false;

            m_SecuBSP = new SecuBSPMx();


            m_EnrollFIRText = "";
            m_CaptureFIRText = "";

            GetInitInfoBtn_Click_1(sender, e);
            EnumBtn_Click_1(sender, e);

            //See if any printers are installed  
            if (PrinterSettings.InstalledPrinters.Count <= 0)
            {
                MessageBox.Show("Printer not found!");
                return;
            }

            //Get all available printers and add them to the combo box  
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                comboPrinters.Items.Add(printer.ToString());
            }
            comboPrinters.SelectedIndex = 0;
        }



        private void CreateTemplateBtn_Click(object sender, System.EventArgs e)
        {
        }


        private void SkinLoadMenu_Click(object sender, System.EventArgs e)
        {

        }

        private void ckboxUseFingerWnd_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ckboxUseFingerWnd.Checked)
                rbWindowInvisible.Checked = true;
        }


        private void ckboxShowFPImage_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ckboxShowFPImage.Checked)
                rbWindowPopup.Checked = true;
        }

        private void menuFIRInfo_Click(object sender, System.EventArgs e)
        {

        }

        //----------------------------------------------------
        private void DisplaySecuBSPErrMsg(string funcName, BSPError errNum)
        {
            if (errNum == 0)
                StatusBar.Text = funcName + "()" + " :Success";
            else
                StatusBar.Text = funcName + "()" + " :Error occurred. Err# = " + Convert.ToString(errNum);
        }

        //----------------------------------------------------
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

        private void ckBoxMonitorDevice_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ckBoxMonitorDevice.Checked)
                m_SecuBSP.MonitorDevice(true, (IntPtr)this.Handle);
            else
                m_SecuBSP.MonitorDevice(false, (IntPtr)0);
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)DriverMessage.WM_DEVICE_EVENT)
            {
                if (message.WParam == (IntPtr)DeviceEvent.FINGER_ON)
                    StatusBar.Text = "Device Message: Finger On";
                else if (message.WParam == (IntPtr)DeviceEvent.FINGER_OFF)
                    StatusBar.Text = "Device Message: Finger Off";
            }
            base.WndProc(ref message);
        }



        private void OpenDeviceBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;

            if (m_DeviceOpened)
            {
                m_SecuBSP.CloseDevice();
                m_DeviceOpened = false;
            }

            // Get Selected device by User
            string selected_device = DeviceIDCombo.Text;
            selected_device = selected_device.Substring(0, 6);
            Int16 device_id = Convert.ToInt16(selected_device.Substring(0, 6), 16);

            m_SecuBSP.DeviceID = device_id;

            err = m_SecuBSP.OpenDevice();
            DisplaySecuBSPErrMsg("OpenDevice", err);
            if (err != BSPError.ERROR_NONE)
                return;

            m_DeviceOpened = true;

            // If the device is FDU03 or FDU04, enable Monitor Device check box
            DeviceName dev_name = m_SecuBSP.GetDeviceName(device_id);
            switch (dev_name)
            {
                case DeviceName.FDU10A:
                case DeviceName.FDU09A:
                case DeviceName.FDU08A:
                case DeviceName.FDU09:
                case DeviceName.FDU06P:
                case DeviceName.FDU08P:
                case DeviceName.FDU08:
                case DeviceName.FDU07A:
                case DeviceName.FDU07:
                case DeviceName.FDU06:
                case DeviceName.FDU05:
                case DeviceName.FDU04:
                case DeviceName.FDU03:
                case DeviceName.FDU02:
                    ckBoxMonitorDevice.Enabled = true;
                    break;
                default:
                    ckBoxMonitorDevice.Enabled = false;
                    break;
            }    // end switch dev_name

            // Get Device Information
            DeviceInfo device_Info = new DeviceInfo();
            err = m_SecuBSP.GetDeviceInfo(device_Info);

            // Display Information
            textImageHeight.Text = Convert.ToString(device_Info.ImageHeight);
            textImageWidth.Text = Convert.ToString(device_Info.ImageWidth);
            textBrightness.Text = Convert.ToString(device_Info.Brightness);
            textContrast.Text = Convert.ToString(device_Info.Contrast);
            textGain.Text = Convert.ToString(device_Info.Gain);
            textImageDPI.Text = Convert.ToString(device_Info.ImageDPI);
            textFWVersion.Text = Convert.ToString(device_Info.FWVersion, 16);
            ASCIIEncoding encoding = new ASCIIEncoding();
            textSerialNum.Text = encoding.GetString(device_Info.DeviceSN);

            if (err != BSPError.ERROR_NONE)
                DisplaySecuBSPErrMsg("GetDeviceInfo", err);

        }

        private void EnumBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;
            DeviceIDCombo.Items.Clear();

            DeviceIDCombo.Items.Add("0x00ff (Auto Detect)");
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
            }
            DisplaySecuBSPErrMsg("EnumerateDevice", err);

        }

        private void AdjustDeviceBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;
            err = m_SecuBSP.AdjustDevice();
            DisplaySecuBSPErrMsg("AdjustDevice", err);
        }

        private void EnrollBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;
            FIRFormat format;

            m_SecuBSP.EnrollWindowOption.WelcomePage = ckboxWelcomePage.Checked;

            if (ckboxAnsi378.Checked)
                format = FIRFormat.ANSI378;
            else
                format = FIRFormat.STANDARDPRO;
            m_SecuBSP.SetFIRFormat(format);

            if (m_EnrollFIRText != "")
                err = m_SecuBSP.Enroll(textUserID.Text, m_EnrollFIRText); // Supported Stored Template
            else
                err = m_SecuBSP.Enroll(textUserID.Text);

            if (err == BSPError.ERROR_NONE)
            {
                m_EnrollFIRText = m_SecuBSP.FIRTextData;
                txtFIRTextData.Text = m_EnrollFIRText;
            }

            DisplaySecuBSPErrMsg("Enroll", err);

        }

        private void VerifyBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;

            m_EnrollFIRText = txtFIRTextData.Text;

            if (m_EnrollFIRText == "")
            {
                MessageBox.Show("Can not find Enrollment data", "Error", MessageBoxButtons.OK);
                return;
            }

            if (rbWindowPopup.Checked)
                m_SecuBSP.CaptureWindowOption.WindowStyle = (int)WindowStyle.POPUP;
            else
                m_SecuBSP.CaptureWindowOption.WindowStyle = (int)WindowStyle.INVISIBLE;

            m_SecuBSP.CaptureWindowOption.ShowFPImage = ckboxShowFPImage.Checked;

            if (ckboxShowFPImage.Checked)
                m_SecuBSP.CaptureWindowOption.ShowFPImage = true;
            else
                m_SecuBSP.CaptureWindowOption.ShowFPImage = false;


            // Check FingerWindow is enabled or not
            if (ckboxUseFingerWnd.Checked)
                m_SecuBSP.CaptureWindowOption.FingerWindow = (IntPtr)fpWindow.Handle;
            else
                m_SecuBSP.CaptureWindowOption.FingerWindow = (IntPtr)0;

            err = m_SecuBSP.Verify(m_EnrollFIRText);

            if (err == BSPError.ERROR_NONE)
            {
                if (m_SecuBSP.IsMatched)
                    StatusBar.Text = "Matched";
                else
                    StatusBar.Text = "Not Matched";

                if (m_SecuBSP.IsMatched && m_SecuBSP.IsPayLoad)
                    MessageBox.Show(m_SecuBSP.PayloadData, "Payload data found", MessageBoxButtons.OK);

            }
            else
                DisplaySecuBSPErrMsg("Verify", err);

        }

        private void CaptureBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;

            if (rbWindowPopup.Checked)
                m_SecuBSP.CaptureWindowOption.WindowStyle = (int)WindowStyle.POPUP;
            else
                m_SecuBSP.CaptureWindowOption.WindowStyle = (int)WindowStyle.INVISIBLE;

            m_SecuBSP.CaptureWindowOption.ShowFPImage = ckboxShowFPImage.Checked;

            if (ckboxShowFPImage.Checked)
                m_SecuBSP.CaptureWindowOption.ShowFPImage = true;
            else
                m_SecuBSP.CaptureWindowOption.ShowFPImage = false;

            // Check FingerWindow is enabled or not
            if (ckboxUseFingerWnd.Checked)
                m_SecuBSP.CaptureWindowOption.FingerWindow = (IntPtr)fpWindow.Handle;
            else
                m_SecuBSP.CaptureWindowOption.FingerWindow = (IntPtr)0;

            err = m_SecuBSP.Capture(FIRPurpose.VERIFY);
            if (err == BSPError.ERROR_NONE)
                m_CaptureFIRText = m_SecuBSP.FIRTextData;

                txtFIRTextData.Text = m_SecuBSP.FIRTextData;

            DisplaySecuBSPErrMsg("Capture", err);

        }

        private void VerifyMatchBtn_Click_1(object sender, EventArgs e)
        {
            if (m_EnrollFIRText == "" || m_CaptureFIRText == "")
            {
                MessageBox.Show("VerifyMatch() requires two input FIRs", "Error", MessageBoxButtons.OK);
                return;
            }

            BSPError err;

            err = m_SecuBSP.VerifyMatch(m_CaptureFIRText, m_EnrollFIRText);

            if (err == BSPError.ERROR_NONE)
            {
                if (m_SecuBSP.IsMatched)
                    StatusBar.Text = "Matched";
                else
                    StatusBar.Text = "Not Matched";

                if (m_SecuBSP.IsMatched && m_SecuBSP.IsPayLoad)
                    MessageBox.Show(m_SecuBSP.PayloadData, "Payload data found", MessageBoxButtons.OK);
            }
            else
                DisplaySecuBSPErrMsg("VerifyMatch", err);

        }

        // CreateTemplate allows
        // 1st and 2nd FIR are both for Enrollment
        // 1st and and FIR are both for Capture
        // If 1st FIR is FIR for Verification and 2nd FIR is FIR for Enrollment, 1 sample in 2nd FIR is not copied to the 1st FIR
        // If 1st FIR is FIR for Enrollment and 2nd FIR is FIR for Capture, it returns SecuAPIERROR_DATA_PROCESS_FAIL.
        private void CreateTemplateBtn_Click_1(object sender, EventArgs e)
        {
            // Make new Template
            BSPError err;
            string curEnrollFIR = "";
            string newEnrollFIR = "";

            err = m_SecuBSP.Enroll("");
            if (err == BSPError.ERROR_NONE)
                curEnrollFIR = m_SecuBSP.FIRTextData;
            else
                return;

            if (m_EnrollFIRText.Length > 0) // If already stored template exist, merge it to newEnrollFIR
                err = m_SecuBSP.CreateTemplate(curEnrollFIR, m_EnrollFIRText, "");
            else
                err = m_SecuBSP.CreateTemplate(curEnrollFIR, "", textUserID.Text); // insert Payload to newEnrollFIR

            if (err == 0)
                newEnrollFIR = m_SecuBSP.FIRTextData;

            DisplaySecuBSPErrMsg("CreateTemplate", err);

            // test code
            /*
            if (err == 0)
            {
               err = m_SecuBSP.VerifyMatch(newEnrollFIR, curEnrollFIR);
               if (m_SecuBSP.IsMatched)
                  DisplaySecuBSPErrMsg("Matched", err);
               else
                  DisplaySecuBSPErrMsg("Not Matched", err);


               if (m_EnrollFIRText != "")
               {
                  err = m_SecuBSP.VerifyMatch(newEnrollFIR, m_EnrollFIRText);
                  if (m_SecuBSP.IsMatched)
                     DisplaySecuBSPErrMsg("Matched", err);
                  else
                     DisplaySecuBSPErrMsg("Not Matched", err);
               }
            }
            */
            // test code

        }

        private void GetInitInfoBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;
            BSPInitInfo initInfo = new BSPInitInfo();

            err = m_SecuBSP.GetInitInfo(initInfo);
            if (err == BSPError.ERROR_NONE)
            {
                MaxFingersForEnrollText.Text = Convert.ToString(initInfo.MaxFingersForEnroll);
                SamplesPerFingerText.Text = Convert.ToString(initInfo.SamplesPerFinger);
                DefaultTimeoutText.Text = Convert.ToString(initInfo.DefaultTimeout);
                EnrollImageQualityText.Text = Convert.ToString(initInfo.EnrollImageQuality);
                VerifyImageQualityText.Text = Convert.ToString(initInfo.VerifyImageQuality);
                SecurityLevelText.Text = Convert.ToString(initInfo.SecurityLevel);
            }
            DisplaySecuBSPErrMsg("GetInitInfo", err);

        }

        private void SetInitInfoBtn_Click_1(object sender, EventArgs e)
        {
            BSPError err;

            BSPInitInfo initInfo = new BSPInitInfo();

            initInfo.MaxFingersForEnroll = Convert.ToInt32(MaxFingersForEnrollText.Text);
            initInfo.SamplesPerFinger = Convert.ToInt32(SamplesPerFingerText.Text);
            initInfo.DefaultTimeout = Convert.ToInt32(DefaultTimeoutText.Text);
            initInfo.EnrollImageQuality = Convert.ToInt32(EnrollImageQualityText.Text);
            initInfo.VerifyImageQuality = Convert.ToInt32(VerifyImageQualityText.Text);
            initInfo.SecurityLevel = Convert.ToInt32(SecurityLevelText.Text);

            err = m_SecuBSP.SetInitInfo(initInfo);
            DisplaySecuBSPErrMsg("SetInitInfo", err);

        }

        private void GetDevInfoBtn_Click_1(object sender, EventArgs e)
        {
            if (m_DeviceOpened)
            {
                // Get Device Information
                DeviceInfo device_Info = new DeviceInfo();
                BSPError err = m_SecuBSP.GetDeviceInfo(device_Info);

                // Display Information
                textImageHeight.Text = Convert.ToString(device_Info.ImageHeight);
                textImageWidth.Text = Convert.ToString(device_Info.ImageWidth);
                textBrightness.Text = Convert.ToString(device_Info.Brightness);
                textContrast.Text = Convert.ToString(device_Info.Contrast);
                textGain.Text = Convert.ToString(device_Info.Gain);
                textImageDPI.Text = Convert.ToString(device_Info.ImageDPI);
                textFWVersion.Text = Convert.ToString(device_Info.FWVersion, 16);
                ASCIIEncoding encoding = new ASCIIEncoding();
                textSerialNum.Text = encoding.GetString(device_Info.DeviceSN);

                DisplaySecuBSPErrMsg("GetDeviceInfo", err);
            }

        }

        private void SetDevInfoBtn_Click_1(object sender, EventArgs e)
        {
            if (m_DeviceOpened)
            {
                DeviceInfo device_Info = new DeviceInfo();

                device_Info.Brightness = Convert.ToInt32(textBrightness.Text);
                device_Info.Contrast = Convert.ToInt32(textContrast.Text);
                device_Info.Gain = Convert.ToInt32(textGain.Text);

                BSPError err = m_SecuBSP.SetDeviceInfo(device_Info);
                DisplaySecuBSPErrMsg("SetDeviceInfo", err);
            }
        }

        private void menuFIRInfo_Click_1(object sender, EventArgs e)
        {
            string firinfo;
            if (m_EnrollFIRText != "")
            {
                firinfo = "Format: " + Convert.ToString(m_SecuBSP.FIRInformation.Format) + "\r\n"
                        + "Version:" + Convert.ToString(m_SecuBSP.FIRInformation.Version) + "\r\n"
                        + "DataType:" + Convert.ToString(m_SecuBSP.FIRInformation.DataType) + "\r\n"
                        + "Purpose:" + Convert.ToString(m_SecuBSP.FIRInformation.Purpose) + "\r\n"
                        + "Quality:" + Convert.ToString(m_SecuBSP.FIRInformation.Quality) + "\r\n"
                        + "FIRText:" + Convert.ToString(m_SecuBSP.FIRTextData) + "\r\n";

                MessageBox.Show(firinfo, "FIR Information", MessageBoxButtons.OK);
            }

        }

        private void SkinLoadMenu_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "dll";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_SecuBSP.SetSkinResource(openFileDialog1.FileName);
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BSPError err;

            m_EnrollFIRText = txtFIRTextData.Text;

            string m_CaptureFIRText = txtVerifyFIR.Text;

            if (m_EnrollFIRText == "" || m_CaptureFIRText == "")
            {
                MessageBox.Show("Can not find Enrollment data", "Error", MessageBoxButtons.OK);
                return;
            }


            err = m_SecuBSP.VerifyMatch(m_CaptureFIRText, m_EnrollFIRText);

            if (err == BSPError.ERROR_NONE)
            {
                if (m_SecuBSP.IsMatched)
                    StatusBar.Text = "Matched";
                else
                    StatusBar.Text = "Not Matched";

                if (m_SecuBSP.IsMatched && m_SecuBSP.IsPayLoad)
                    MessageBox.Show(m_SecuBSP.PayloadData, "Payload data found", MessageBoxButtons.OK);

            }
            else
                DisplaySecuBSPErrMsg("Verify", err);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Create a PrintDocument object  
            PrintDocument pd = new PrintDocument();

            //Set PrinterName as the selected printer in the printers list  
            pd.PrinterSettings.PrinterName = comboPrinters.SelectedItem.ToString();

            for (int i = 0; i < pd.PrinterSettings.PaperSizes.Count-1; i++)
            {
                var p_Size = pd.PrinterSettings.PaperSizes[i];
                if (p_Size.PaperName == "CBT1")
                {
                    pd.DefaultPageSettings.PaperSize = p_Size;
                }
            }

            //Add PrintPage event handler  
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //Print the document  
            pd.Print();



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
            g.DrawString("Course:  MTH101", new Font("Arial", 10), brush, new Rectangle(20, 0, 350, 50));
            g.DrawString("Username =  ", fontB, brush, new Rectangle(20, 20, 350, 50));
            g.DrawString("023456", font, brush, new Rectangle(120, 20, 350, 50));
            g.DrawString("Password =  ", fontB, brush, new Rectangle(20, 50, 400, 50));
            g.DrawString("A2E12I0J1O", font, brush, new Rectangle(120, 50, 400, 50));
            g.DrawString("PrintDate: " + DateTime.Now.ToString("dddd, dd MMMM yyyy"), new Font("Arial", 9), brush, new Rectangle(20, 80,  400, 50));
        
        }
    }
}
