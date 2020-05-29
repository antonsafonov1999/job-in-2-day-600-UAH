using CourceWork;
using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class RedCondit : Form
    {

        public List<Conditer> conditer = new List<Conditer>();
        ClassDataBase db = new ClassDataBase();
        public RedCondit(string text)
        {
            InitializeComponent();
            try
            {

                int id = Convert.ToInt32(text);

                string p = @"SELECT DISTINCT * FROM Conditer WHERE Id='" + id + "';";
                db.Execute<Conditer>("CourseWork.db", p, ref conditer);
                label9.Text = Convert.ToString(id);
                for (int i = 0; i < conditer.Count; i++)
                {
                    textBox6.Text = conditer[i].Name;
                    textBox1.Text = conditer[i].NamePostavka;
                    textBox5.Text = conditer[i].NameConditer;
                    maskedTextBox1.Text = conditer[i].Telephone;
                    maskedTextBox4.Text = Convert.ToString(conditer[i].ColConditer);
                    maskedTextBox3.Text = Convert.ToString(conditer[i].SaleOneConditer);
                    label10.Text = Convert.ToString(conditer[i].DataPostavka);
                    textBox2.Text = Convert.ToString(conditer[i].FulSaleConditer);
                }
            }
            catch 
            {

              
            }
           
        }
        
      
      

        private void RedCondit_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox1.Text != "" && textBox5.Text != "" && maskedTextBox1.Text != "" && maskedTextBox4.Text != "" && maskedTextBox3.Text != "" && label10.Text != "" && textBox2.Text != "")
            {
                string x = @"UPDATE Conditer SET NameConditer =  '" + textBox5.Text + "' WHERE Id = '" + label9.Text + "';";   
                string x2 = @"UPDATE Conditer SET Telephone =  '" + maskedTextBox1.Text + "' WHERE Id = '" + label9.Text + "';";   
                string x3 = @"UPDATE Conditer SET ColConditer =  '" + maskedTextBox4.Text + "' WHERE Id = '" + label9.Text + "';";  
                string x4 = @"UPDATE Conditer SET SaleOneConditer =  '" + maskedTextBox3.Text + "' WHERE Id = '" + label9.Text + "';";  
                string x5 = @"UPDATE Conditer SET DataPostavka =  '" + label10.Text + "' WHERE Id = '" + label9.Text + "';";   
                string x6 = @"UPDATE Conditer SET FulSaleConditer =  '" + textBox2.Text + "' WHERE Id = '" + label9.Text + "';";   
                string x7 = @"UPDATE Conditer SET Name =  '" + textBox6.Text + "' WHERE Id = '" + label9.Text + "';";   
                string x8 = @"UPDATE Conditer SET NamePostavka =  '" + textBox1.Text + "' WHERE Id = '" + label9.Text + "';"; 

                int t = db.ExecuteNonQuery("CourseWork.db", x);
                int t2 = db.ExecuteNonQuery("CourseWork.db", x2);
                int t3 = db.ExecuteNonQuery("CourseWork.db", x3);
                int t4 = db.ExecuteNonQuery("CourseWork.db", x4);

                int t5 = db.ExecuteNonQuery("CourseWork.db", x5);
                int t6 = db.ExecuteNonQuery("CourseWork.db", x6);
                int t42 = db.ExecuteNonQuery("CourseWork.db", x7);
                int t52 = db.ExecuteNonQuery("CourseWork.db", x8);

            }
            else           
                MessageBox.Show("Заполните правильно и все формы заполнения!", "Error", MessageBoxButtons.OK);
            this.Hide();

        }

        private void maskedTextBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (maskedTextBox4.Text != "" & maskedTextBox3.Text != "")
            {
                try
                {
                    var cost = Convert.ToDecimal(maskedTextBox4.Text) * Convert.ToDecimal(maskedTextBox3.Text);
                    textBox2.Text = Convert.ToString(cost);
                }
                finally { }


            }
        }


        private void maskedTextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (maskedTextBox4.Text != "" & maskedTextBox3.Text != "")
            {
                try
                {
                    var cost = Convert.ToDecimal(maskedTextBox4.Text) * Convert.ToDecimal(maskedTextBox3.Text);
                    textBox2.Text = Convert.ToString(cost);
                }
                finally { }


            }
        }

      

        private void maskedTextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (maskedTextBox4.Text != "" & maskedTextBox3.Text != "")
            {
                try
                {
                    var cost = Convert.ToDecimal(maskedTextBox4.Text) * Convert.ToDecimal(maskedTextBox3.Text);
                    textBox2.Text = Convert.ToString(cost);
                }
                finally { }


            }
        }

        private void maskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox4.Text.Length == 0)
                if (e.KeyChar == '0') e.Handled = true;
        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox4.Text.Length == 0)
                if (e.KeyChar == '0') e.Handled = true;
        }
    }
}
