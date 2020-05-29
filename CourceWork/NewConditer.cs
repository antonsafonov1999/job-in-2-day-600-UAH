using CourceWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NewConditer : Form
    {
        public NewConditer()
        {
            InitializeComponent();
        }


        public List<Conditer> conditer = new List<Conditer>();
        ClassDataBase db = new ClassDataBase();

        private void NewConditer_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToShortTimeString();
          
   
        }

        private void maskedTextBox3_KeyUp_1(object sender, KeyEventArgs e)
        {
           
            if (maskedTextBox4.Text != "" && maskedTextBox4.Text !=$"{0}" && maskedTextBox3.Text != "" && maskedTextBox4.Text != $"{0}")
            {
                try
                {
                    decimal cost = Convert.ToDecimal(maskedTextBox4.Text) * Convert.ToDecimal(maskedTextBox3.Text);

                    textBox2.Text = Convert.ToString(cost);
                }
                finally { }


            }
        }

        private void maskedTextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (maskedTextBox4.Text != "" && maskedTextBox4.Text != $"{0}" && maskedTextBox3.Text != "" && maskedTextBox4.Text != $"{0}")
            {
                try
                {
                    var cost = Convert.ToDecimal(maskedTextBox4.Text) * Convert.ToDecimal(maskedTextBox3.Text);
                    textBox2.Text = Convert.ToString(cost);
                }
                finally { }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox1.Text != "" && textBox5.Text != "" && maskedTextBox1.Text != "" && maskedTextBox4.Text != "" && maskedTextBox3.Text != "" &&  textBox2.Text != "")
            {
                string s1 = @"INSERT INTO Conditer (NameConditer,Telephone,ColConditer,SaleOneConditer,DataPostavka,FulSaleConditer,Name,NamePostavka)VALUES('" + textBox5.Text + "','" + maskedTextBox1.Text + "',' " + maskedTextBox4.Text + "',' " + maskedTextBox3.Text + "','" + label9.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox1.Text + "');";


                int t = db.ExecuteNonQuery("CourseWork.db", s1);
                if (t != 0)
                {
                    MessageBox.Show("Сохранено в базу Conditer", "Informatoin", MessageBoxButtons.OK);
                }
               
            }
            else
            {
                MessageBox.Show("Заполните правильно и все формы заполнения!", "Error", MessageBoxButtons.OK);
            }
            this.Hide();
        }

        private void maskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox4.Text.Length == 0)
                if (e.KeyChar == '0') e.Handled = true;
        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox3.Text.Length == 0)
                if (e.KeyChar == '0') e.Handled = true;
        }
    }
}
