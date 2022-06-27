using CBTAuth.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBTAuth
{
    public partial class login : Form
    {
        private static readonly HttpClient client = new HttpClient();
        

        public static HttpClient Client
        {
            get { return client; }
            
        }
        public login()
        {
            InitializeComponent();
            
        }

        public  async Task<HallLoginDto> HallLogin(HallLoginModel model)
        {
           //client.BaseAddress = new Uri(txtBaseURL.Text.Trim());
           
            HttpResponseMessage ResMessage = null;

            
            var stringTask = client.PostAsJsonAsync("/api/v1/services/hall/login", model);
            try
            {
                ResMessage = stringTask.Result;
            }
            catch (Exception)
            {


            }

            if (ResMessage == null)
            {
                return null;
            }

            if (ResMessage.IsSuccessStatusCode)
            {

                var readTask = ResMessage.Content.ReadFromJsonAsync<HallLoginDto>();
               

                var hallLoginDto = readTask.Result;

                return hallLoginDto;
            }

            return null;
        }
        public   async Task<StudentDto> GetStudent(string matno)
        {
            StudentDto StudJSON;
            GlobalClass.BaseURL = txtBaseURL.Text.Trim();
            client.BaseAddress = new Uri(GlobalClass.BaseURL);            

            try
            {
                var stringTask = client.GetFromJsonAsync<StudentDto>("/api/v1/services/student/" + matno);

                StudJSON = stringTask.Result;

            }
            catch (Exception)
            {
                StudJSON = new StudentDto();
            }

            return StudJSON;
        }


        private void login_Load(object sender, EventArgs e)
        {
            GlobalClass.BaseURL = txtBaseURL.Text.Trim();
            txtUsername.Select();
            client.BaseAddress = new Uri(GlobalClass.BaseURL);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            var model = new HallLoginModel()
            {
                Name = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            var ret = HallLogin(model).Result;
            //var stud = GetStudent("string").Result;

            //var ret = new HallLoginDto()
            //{
            //    FIR = "AAAAAAA",
            //    Name = "Hall"
            //};

            if (ret != null)
            {
                GlobalClass.HallName = ret.Name;
                GlobalClass.IsLogin = true;
                GlobalClass.HallFIR = ret.FIR;

               // Home.modeMenu.Enabled = true;

                //this.Hide();
                this.Close();                
           
            }
            else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Select();
            }


        }

        private void txtBaseURL_TextChanged(object sender, EventArgs e)
        {
            GlobalClass.BaseURL = txtBaseURL.Text.Trim();
        }
    }
}
