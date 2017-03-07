using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb; 
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DayView
{
    public partial class SearchForm : Form
    {
        private OleDbConnection con;
        public SearchForm()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/PZey/Desktop/MatabDB.accdb;Persist Security Info=False");
            InitializeComponent();
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



   
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show(listBox1.SelectedItem.ToString());
            con.Open();
            string query = "select firstName, lastName, age, history, phoneNumber, allergy from Profile  ";
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
            // myCommand.ExecuteNonQuery();
            OleDbDataReader oReader = myCommand.ExecuteReader();



            int idxFirstName = oReader.GetOrdinal("firstName");
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
                }
                
            }

            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            this.Close(); 
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_family_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
