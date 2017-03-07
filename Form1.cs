using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DayView.Models;
using System.Windows.Forms;
using System.Data.OleDb;


namespace DayView
{
    public partial class Form1 : Form
    {

        private OleDbConnection con;
        public Form1()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/PZey/Desktop/MatabDB.accdb;Persist Security Info=False");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_name.Text == "") { MessageBox.Show("نام وارد نشده است"); return; }
            if (txt_family.Text == "") { MessageBox.Show("نام خانوادگی وارد نشده است");return; }
            if (txt_phone_number.Text == "") { MessageBox.Show("شماره تماس وارد نشده است");return; }   
            con.Open();
            string query = "insert into Profile (age, history , allergy , firstName , lastName , phoneNumber ) VALUES ('" + txt_age.Text + "', '" + txt_history.Text + "', '" + txt_alergy.Text + "' , '" + txt_name.Text + "', '" + txt_family.Text + "','" + txt_phone_number.Text + "' )";

            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
            myCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("داده‌های مریض با موفقیت ثبت گردید!");
            txt_name.Text = "";
            txt_family.Text = "";
            txt_history.Text = "";
            txt_age.Text = "";
            txt_alergy.Text = "";
            txt_phone_number.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
