using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; 
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DayView
{
    public partial class Appointment : Form
    {
        
        private OleDbConnection con;
        public Appointment()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/PZey/Desktop/MatabDB.accdb;Persist Security Info=False");
            InitializeComponent();

            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                for (int a = listBox1.Items.Count - 1; a >= 0; a--)
                {
                    listBox1.Items.RemoveAt(a);
                }
                listBox1.Refresh();

            }
            con.Open();
            string query = "select firstName, lastName, phoneNumber from Profile  ";

            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
             // myCommand.ExecuteNonQuery();
            OleDbDataReader oReader =   myCommand.ExecuteReader();


             
            int idxFirstName = oReader.GetOrdinal("firstName");
            int idxLastName = oReader.GetOrdinal("lastName");
            int idxPhoneNumber = oReader.GetOrdinal("phoneNumber");
            bool flag =false;
            while (oReader.Read())
            {
            //    MessageBox.Show("+" + oReader.GetValue(idxLastName).ToString() + "+" + txt_family.Text + "+");
                if (oReader.GetValue(idxFirstName) != null && (txt_family.Text != "" && txt_family.Text == oReader.GetValue(idxLastName).ToString()) || (txt_name.Text != "" && txt_name.Text == oReader.GetValue(idxFirstName).ToString()))
                { listBox1.Items.Add(oReader.GetValue(idxFirstName) + " " + oReader.GetValue(idxLastName) + " " + oReader.GetValue(idxPhoneNumber)); flag = true; }
                else if (oReader.GetValue(idxFirstName) != null && txt_family.Text == "" && txt_name.Text == "")
                {    listBox1.Items.Add(oReader.GetValue(idxFirstName) + " " + oReader.GetValue(idxLastName) + " " + oReader.GetValue(idxPhoneNumber));
                    flag=true;}
                
                    
            }
            if (!flag) 
                MessageBox.Show("فردی با این مشخصات پیدا نشد");
            con.Close(); 
         //   MessageBox.Show(reader.GetString(1));
            txt_name.Text = "";
            txt_family.Text = "";


        }

        int selectedIndex = -1; 

   
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show(listBox1.SelectedItem.ToString());
            con.Open();
            string query = "select ID , firstName, lastName, age, history, phoneNumber, allergy from Profile  ";
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
            // myCommand.ExecuteNonQuery();
            OleDbDataReader oReader = myCommand.ExecuteReader();

            int idxFirstName = oReader.GetOrdinal("firstName");
            int idxId = oReader.GetOrdinal("ID");
            int idxLastName = oReader.GetOrdinal("lastName");
            int idxAge = oReader.GetOrdinal("age");
            int idxHistory = oReader.GetOrdinal("history");
            int idxPhoneNumber = oReader.GetOrdinal("phoneNumber");
            int idxAllergy = oReader.GetOrdinal("allergy");
            String[] words=null;
            if (listBox1.SelectedItem != null)
            {
                words = listBox1.SelectedItem.ToString().Split(' ');
            }
            while (oReader.Read())
            {
                if (oReader.GetValue(idxFirstName) != null && words !=null && (words[0] == oReader.GetValue(idxFirstName).ToString()))
                {
                    MessageBox.Show(oReader.GetValue(idxFirstName).ToString() + "\n" +
                      oReader.GetValue(idxLastName).ToString() + "\n" +
                      oReader.GetValue(idxAge).ToString() + "\n" +
                      oReader.GetValue(idxHistory).ToString() + "\n" +
                      oReader.GetValue(idxPhoneNumber).ToString() + "\n" +
                      oReader.GetValue(idxAllergy).ToString());
                      selectedIndex = (int)oReader.GetValue(idxId);
                      textBox1.Text = oReader.GetValue(idxFirstName).ToString()+" " + oReader.GetValue(idxLastName).ToString();

                }
                
            }

            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            this.Close(); 
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");         
            string query = "insert into Appointment (AppointmentDate, PateintId) VALUES ('" + theDate + "', '" + selectedIndex + "' )";
            if(selectedIndex==-1)
            {
                MessageBox.Show("لطفا با جستجو یک نفر را از لیست انتخاب نمایید!");
                return;
            }

            con.Open();

            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
            myCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("داده‌های مریض با موفقیت ثبت گردید!");

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

       

       
        
    }


    }
 
