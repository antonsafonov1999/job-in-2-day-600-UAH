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
    public partial class SeleCond : Form
    {
        public SeleCond()
        {
            InitializeComponent();

        }




        public List<Conditer> conditer = new List<Conditer>();                                                //Две строки которая помогает с БД 
        ClassDataBase db = new ClassDataBase();
        private void SeleCond_Load(object sender, EventArgs e)
        {
            LoadDB();
        }
        private void LoadDB()
        {
            conditer.Clear();
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();
            string s = @"SELECT * FROM Conditer;";
            db.Execute<Conditer>("CourseWork.db", s, ref conditer);

            for (int i = 0; i < conditer.Count; i++)
            {
                comboBox1.Items.Add(conditer[i].Name);

            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        int sale = 0;
        private void button2_Click(object sender, EventArgs e)
        {   
            if (comboBox1.Text != "")            
            {
                conditer.Clear();
               
                string s = @"SELECT * FROM Conditer where Name ='" + comboBox1.Text + "';";
                db.Execute<Conditer>("CourseWork.db", s, ref conditer);


                bool flag = true;
                int intflag = 0;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value.ToString() == Convert.ToString(conditer[0].Id))
                    {
                        flag = false;
                        intflag = j;
                    }
                }

                if (flag && intflag == 0)
                {
                    for (int i = 0; i < conditer.Count; i++)
                    {
                        dataGridView1.Rows.Add(conditer[i].Id, conditer[i].Name, "1", conditer[i].SaleOneConditer);

                        string sb21 = @"UPDATE Conditer SET ColConditer =  ColConditer - 1 WHERE Id = '" + conditer[i].Id + "';";
                        db.ExecuteNonQuery("CourseWork.db", sb21);
                        sale += conditer[i].SaleOneConditer;
                        label1.Text = $"Всего(грн):";
                        label2.Text = Convert.ToString(sale);
                    }
                }
                else
                {
                    for (int i = 0; i < conditer.Count; i++)
                    {

                        dataGridView1.Rows[intflag].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[intflag].Cells[2].Value) + 1;
                        dataGridView1.Rows[intflag].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[intflag].Cells[3].Value) + conditer[i].SaleOneConditer;

                        string sb21 = @"UPDATE Conditer SET ColConditer =  ColConditer - 1 WHERE Id = '" + conditer[i].Id + "';";
                        db.ExecuteNonQuery("CourseWork.db", sb21);
                        sale += conditer[i].SaleOneConditer;
                        label1.Text = $"Всего(грн):";
                        label2.Text = Convert.ToString(sale);
                    }
                }


                

                comboBox1.Text = "";
            }
          
            
                conditer.Clear();
                comboBox1.Items.Clear();
                string s1 = @"SELECT * FROM Conditer;";
                db.Execute<Conditer>("CourseWork.db", s1, ref conditer);

                for (int i = 0; i < conditer.Count; i++)
                {
                if (conditer[i].ColConditer > 0)
                {
                    comboBox1.Items.Add(conditer[i].Name);
                }
                    

                }
            
        }

     


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView1.SelectedCells[0].RowIndex;
                sale = Convert.ToInt32(label2.Text) - Convert.ToInt32(dataGridView1.Rows[ind].Cells[3].Value) / Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value);
                label2.Text = Convert.ToString(sale);
                dataGridView1.Rows[ind].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[ind].Cells[3].Value) - Convert.ToInt32(dataGridView1.Rows[ind].Cells[3].Value) / Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value);
                dataGridView1.Rows[ind].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value) - 1;


                int id = Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value.ToString());
                string sb21 = @"UPDATE Conditer SET ColConditer =  ColConditer + 1 WHERE Id = '" + id + "';";
                db.ExecuteNonQuery("CourseWork.db", sb21);



                conditer.Clear();
                comboBox1.Items.Clear();
                string s1 = @"SELECT * FROM Conditer;";
                db.Execute<Conditer>("CourseWork.db", s1, ref conditer);

                for (int i = 0; i < conditer.Count; i++)
                {
                    if (conditer[i].ColConditer > 0)
                    {
                        comboBox1.Items.Add(conditer[i].Name);
                    }


                }
                if (dataGridView1.Rows[ind].Cells[2].Value.ToString() == "0")
                {
                    dataGridView1.Rows.RemoveAt(ind);
                }

            }
            catch 
            {

              
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int id1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                int price = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());


                string sb11 = @"UPDATE Conditer SET FulSaleConditer = FulSaleConditer - '" + price + "' WHERE Id = '" + id1 + "';"; 

                db.ExecuteNonQuery("CourseWork.db", sb11);


                conditer.Clear();
                comboBox1.Items.Clear();
                string s1 = @"SELECT * FROM Conditer where Id = '" + id1 + "';";
                db.Execute<Conditer>("CourseWork.db", s1, ref conditer);

                label2.Text = "";

                if (conditer[0].ColConditer == 0)
                {
                    sb11 = @"delete from Conditer WHERE Id = '" + id1 + "';";  

                    db.ExecuteNonQuery("CourseWork.db", sb11);
                }


            }
            dataGridView1.Rows.Clear();

            conditer.Clear();
            comboBox1.Items.Clear();
            string s11 = @"SELECT * FROM Conditer;";
            db.Execute<Conditer>("CourseWork.db", s11, ref conditer);

            for (int i = 0; i < conditer.Count; i++)
            {
                if (conditer[i].ColConditer > 0)
                {
                    comboBox1.Items.Add(conditer[i].Name);
                }


            }

        }

    }
}
