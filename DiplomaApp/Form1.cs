using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MySql.Data.MySqlClient;

namespace DiplomaApp
{

    public partial class Form1 : MaterialForm
    {


        public Form1()
        {
            InitializeComponent();
            var SkinManager = MaterialSkinManager.Instance;
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.Sizable = false;
            PswTextBox.PasswordChar = '•';

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string psw = PswTextBox.Text;
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "<Host>";
            conn_string.UserID = "<Username>";
            conn_string.Password = "<Password>";
            conn_string.Database = "<Database Name>";

            using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT COUNT(*) from admin where admin_email = '" + email + "' and admin_password = '" + psw + "'", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        var MainForm = new MainForm();
                        MainForm.Closed += (s, args) => this.Close();
                        MainForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Wrong Password or Email", "Login Error");
                    }

                }
                catch (Exception ex)
                {
                     MessageBox.Show("No Connection");
                     MessageBox.Show(ex.Message);
                }

                finally
                {
                    conn.Close();
                }
            }
        }

        private void PswTextBox_Click(object sender, EventArgs e)
        {
           
        }
    }
}
