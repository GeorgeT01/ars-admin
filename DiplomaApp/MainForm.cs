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
using System.Net.Mail;
using System.Net;

namespace DiplomaApp
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();

            var SkinManager = MaterialSkinManager.Instance;
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            // charts
            charts();

            DateTimeStyle();

            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "<Host>";
            conn_string.UserID = "<Username>";
            conn_string.Password = "<Password>";
            conn_string.Database = "<Database Name>";

            MySqlConnection conn = new MySqlConnection(conn_string.ToString());

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT user_fname, user_lname, user_email, user_phone, date_signed, time_signed FROM users", conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                for (int i = 0; i < table.Columns.Count; i++)
                    materialListView1.Columns.Add(table.Columns[i].ColumnName.ToString(), materialListView1.Width / 6 - 1);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    ListViewItem row = new ListViewItem(table.Rows[i][0].ToString());
                    for (int j = 1; j < table.Columns.Count; j++)
                        row.SubItems.Add(table.Rows[i][j].ToString());
                    materialListView1.Items.Add(row);
                }
                materialListView1.Columns[0].Text = "First Name";
                materialListView1.Columns[0].Width = 100;
                materialListView1.Columns[1].Text = "Last Name";
                materialListView1.Columns[1].Width = 100;
                materialListView1.Columns[2].Text = "Email";
                materialListView1.Columns[2].Width = 150;
                materialListView1.Columns[3].Text = "Phone Number";
                materialListView1.Columns[3].Width = 150;
                materialListView1.Columns[4].Width = 100;
                materialListView1.Columns[5].Width = 100;




                MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT *FROM cancellation INNER JOIN reservation on cancellation.res_id = reservation.res_id", conn);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);

                for (int i = 0; i < table2.Columns.Count; i++)
                    materialListView2.Columns.Add(table2.Columns[i].ColumnName.ToString(), materialListView2.Width / 6 - 1);

                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    ListViewItem row = new ListViewItem(table2.Rows[i][0].ToString());
                    for (int j = 1; j < table2.Columns.Count; j++)
                        row.SubItems.Add(table2.Rows[i][j].ToString());
                    materialListView2.Items.Add(row);
                }

                MySqlDataAdapter adapter3 = new MySqlDataAdapter("SELECT * FROM reservation" +
                " INNER JOIN passenger ON reservation.passenger_id = passenger.passenger_id " +
                "INNER JOIN seat_reservation on reservation.res_id = seat_reservation.res_id", conn);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);

                for (int i = 0; i < table3.Columns.Count; i++)
                    materialListView3.Columns.Add(table3.Columns[i].ColumnName.ToString(), materialListView3.Width / 6 - 1);

                for (int i = 0; i < table3.Rows.Count; i++)
                {
                    ListViewItem row = new ListViewItem(table3.Rows[i][0].ToString());
                    for (int j = 1; j < table3.Columns.Count; j++)
                        row.SubItems.Add(table3.Rows[i][j].ToString());
                    materialListView3.Items.Add(row);
                }


            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SendEMail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 465;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("<email@example.com>", "<Password>");
        }
        //sending emails
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && materialSingleLineTextField1.Text != "")
            {
                try
                {
                        string email = "";
                        email = materialSingleLineTextField2.Text;
                        MailAddress to = new MailAddress(email);
                        //sender email address
                        MailAddress from = new MailAddress("email_from@example.com");
                         MailMessage msg = new MailMessage();
                        msg.Subject = materialSingleLineTextField1.Text;
                        string email_msg = textBox1.Text;
                        msg.Body = email_msg;
                        msg.From = from;
                        msg.To.Add(to);
                        SendEMail(msg);

                    MessageBox.Show("Message Sent Successfully");
                    textBox1.Text = "";
                    materialSingleLineTextField2.Text = "";
                    materialSingleLineTextField1.Text = "";

                }
                catch (Exception em) { MessageBox.Show(em.Message); }
            }
        }

        private void DateTimeStyle()
        {

            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;
        }

        private void materialListView1_MouseClick(object sender, MouseEventArgs e)
        {


            ListView.SelectedListViewItemCollection lvc =
            this.materialListView1.SelectedItems;

            foreach (ListViewItem item in lvc)
            {
                string email = materialListView1.SelectedItems[0].SubItems[2].Text;
                materialSingleLineTextField2.Text = email;
            }
        }

        private void charts()
        {

            this.chart1.Series["Reservations"].Points.AddXY("Mar", 250);
            this.chart1.Series["Reservations"].Points.AddXY("Apr", 220);
            this.chart1.Series["Reservations"].Points.AddXY("May", 280);
            this.chart1.Series["Reservations"].Points.AddXY("June", 240);
            this.chart1.Series["Reservations"].Points.AddXY("July", 333);
            this.chart1.Series["Reservations"].Points.AddXY("Aug", 370);
            this.chart1.Series["Reservations"].Points.AddXY("Sep", 348);
            this.chart1.Series["Reservations"].Points.AddXY("Oct", 450);
            this.chart2.Series["Classes"].Points.AddXY("Economy 60%", 60);
            this.chart2.Series["Classes"].Points.AddXY("Business 25%", 35);
            this.chart2.Series["Classes"].Points.AddXY("First 15%", 15);
            chart2.BackColor = Color.Transparent;
            chart2.ChartAreas[0].BackColor = Color.Transparent;
            chart2.Legends[0].BackColor = Color.Transparent;
            chart2.Legends[0].ForeColor = Color.WhiteSmoke;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            this.chart1.ChartAreas[0].AxisX.LineColor = Color.WhiteSmoke;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.WhiteSmoke;
            this.chart1.ChartAreas[0].AxisY.LineColor = Color.WhiteSmoke;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.WhiteSmoke;
            chart1.Legends[0].ForeColor = Color.WhiteSmoke;
            chart1.Legends[0].BackColor = Color.Transparent;
            chart1.BackColor = Color.Transparent;
            chart2.ForeColor = Color.WhiteSmoke;

        }


        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {


                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "<Host>";
                conn_string.UserID = "<Username>";
                conn_string.Password = "<Password>";
                conn_string.Database = "<Database Name>";

                MySqlConnection conn = new MySqlConnection(conn_string.ToString());


                string flight_number = FlighNumberTB.Text;

                // origin
                string from_city = textBox2.Text;
                string from_airport = textBox3.Text;
                string from_country = textBox4.Text;

                string depart_date = this.dateTimePicker1.Text;
                string depart_time = this.dateTimePicker2.Text;

                //distination
                string to_city = textBox11.Text;
                string to_airport = textBox10.Text;
                string to_country = textBox9.Text;

                string arrival_date = this.dateTimePicker3.Text;
                string arrival_time = this.dateTimePicker4.Text;

                string ac_number = AcNumberTB.Text; // aircraft number

                // economy class
                int eco_number = (int)numericUpDown1.Value;
                int eco_price = (int)numericUpDown6.Value;
                int eco_baggage = (int)numericUpDown9.Value;

                // business classs
                int bus_number = (int)numericUpDown2.Value;
                int bus_price = (int)numericUpDown5.Value;
                int bus_baggage = (int)numericUpDown8.Value;

                // first class
                int first_number = (int)numericUpDown3.Value;
                int first_price = (int)numericUpDown4.Value;
                int first_baggage = (int)numericUpDown7.Value;

                conn.Open();
                // checking airport table 
                string query = "SELECT COUNT(*) FROM airport WHERE airport_name ='" + from_airport + "' AND city = '" + from_city + "' AND country = '" + from_country + "' ";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataAdapter returnVal = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                returnVal.Fill(dt);

                if (dt.Rows[0][0].ToString() == "0")
                {
                    // insert into airport table
                    string airport_query1 = "INSERT INTO airport(airport_name, city, country) VALUES" +
                     "('" + from_airport + "', '" + from_city + "', '" + from_country + "')";
                    MySqlCommand cmd_airport1 = new MySqlCommand(airport_query1, conn);

                    cmd_airport1.ExecuteNonQuery();
                }

                // checking airport table for distination fligjt
                string query2 = "SELECT COUNT(*) FROM airport WHERE airport_name ='" + to_airport + "' AND city = '" + to_city + "' AND country = '" + to_country + "' ";
                MySqlCommand command2 = new MySqlCommand(query2, conn);
                MySqlDataAdapter returnVal2 = new MySqlDataAdapter(query2, conn);
                DataTable dt2 = new DataTable();
                returnVal2.Fill(dt2);

                if (dt2.Rows[0][0].ToString() == "0")
                {
                    //insert into airport table
                    string airport_query2 = "INSERT INTO airport(airport_name, city, country) VALUES" +
                     "('" + to_airport + "', '" + to_city + "', '" + to_country + "')";
                    MySqlCommand cmd_airport2 = new MySqlCommand(airport_query2, conn);

                    cmd_airport2.ExecuteNonQuery();
                }

                // insert in flight table 
                string flight_query = "INSERT INTO flights(flight_number, from_city, to_city) VALUES" +
                     "('" + flight_number.ToString() + "', '" + from_city + "', '" + to_city + "')";
                MySqlCommand cmd_flight = new MySqlCommand(flight_query, conn);
                cmd_flight.ExecuteNonQuery();

                // insert into aircraft table
                string ac_query = "INSERT INTO aircraft(ac_number) VALUES('" + ac_number.ToString() + "')";
                MySqlCommand cmd_ac = new MySqlCommand(ac_query, conn);
                cmd_ac.ExecuteNonQuery();
                long ac_id = cmd_ac.LastInsertedId; // aircraft id (last inserted id)

                // insert into flight_details table
                string flight_details_query = "INSERT INTO flight_details (flight_number, depart_date, arrival_date, depart_time, arrival_time, ac_id) " +
                 " VALUES('" + flight_number.ToString() + "', '" + depart_date.ToString() + "', '" + arrival_date.ToString() + "', '" + depart_time.ToString() + "', '" + arrival_time.ToString() + "', '" + ac_id.ToString() + "')";
                MySqlCommand cmd_fd = new MySqlCommand(flight_details_query, conn);
                cmd_fd.ExecuteNonQuery();


                string economy_flight_price = "INSERT INTO flight_price(flight_number, class_id, price, baggage) "
                            + " VALUES('" + flight_number.ToString() + "', '1', '" + eco_price.ToString() + "', '" + eco_baggage.ToString() + "')";
                MySqlCommand cmd_eco = new MySqlCommand(economy_flight_price, conn);
                cmd_eco.ExecuteNonQuery();


                string business_flight_price = "INSERT INTO flight_price(flight_number, class_id, price, baggage) "
                        + " VALUES('" + flight_number.ToString() + "', '2', '" + bus_price.ToString() + "', '" + bus_baggage.ToString() + "')";
                MySqlCommand cmd_bus = new MySqlCommand(business_flight_price, conn);
                cmd_bus.ExecuteNonQuery();


                string first_flight_price = "INSERT INTO flight_price(flight_number, class_id, price, baggage) "
                   + " VALUES('" + flight_number.ToString() + "', '3', '" + first_price.ToString() + "', '" + first_baggage.ToString() + "')";
                MySqlCommand cmd_first = new MySqlCommand(first_flight_price, conn);
                cmd_first.ExecuteNonQuery();

                for (int i = 1; i <= eco_number; i++)
                {
                    string economy_seats = "INSERT INTO seats(seat_number, class_id, statement, ac_id) "
                        + " VALUES('E" + i.ToString() + "', '1', 'Available', '" + ac_id.ToString() + "')";
                    MySqlCommand cmd_economy = new MySqlCommand(economy_seats, conn);
                    cmd_economy.ExecuteNonQuery();
                }


                for (int j = 1; j <= bus_number; j++)
                {
                    string business_seats = "INSERT INTO seats(seat_number, class_id, statement, ac_id) "
                        + " VALUES('B" + j.ToString() + "', '2', 'Available', '" + ac_id.ToString() + "')";
                    MySqlCommand cmd_business = new MySqlCommand(business_seats, conn);
                    cmd_business.ExecuteNonQuery();
                }

                for (int h = 1; h <= first_number; h++)
                {
                    string first_seats = "INSERT INTO seats(seat_number, class_id, statement, ac_id) "
                        + " VALUES('A" + h.ToString() + "', '3', 'Available', '" + ac_id.ToString() + "')";
                    MySqlCommand cmd_firstclass = new MySqlCommand(first_seats, conn);
                    cmd_firstclass.ExecuteNonQuery();
                }

                MessageBox.Show("Data Successfuly Inserted");
                conn.Close();
               FlighNumberTB.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";



                //distination
                textBox11.Text = "";
               textBox10.Text = "";
               textBox9.Text = "";



                AcNumberTB.Text = ""; // aircraft number

                // economy class
               numericUpDown1.Value = 1;
                numericUpDown6.Value = 1;
              numericUpDown9.Value = 1;

                // business classs
              numericUpDown2.Value = 1;
                numericUpDown5.Value = 1;
                numericUpDown8.Value = 1;

                // first class
                numericUpDown3.Value = 1;
                numericUpDown4.Value = 1;
                numericUpDown7.Value = 1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
    }
}

