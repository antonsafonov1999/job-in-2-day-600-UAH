
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using CourceWork;


namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
      public event System.Windows.Forms.TypeValidationEventHandler TypeValidationCompleted;
                                                                                                    // Чтобы быстро перейти на фуйнцию (в вызове пример   InitializeComponent();) 
        public Menu()                                                                               // назжимаешь Ctr + наводишь на функцию и кликаешь мышью 
        {
            InitializeComponent();

        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Desirialization();
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;

            dateTimePicker1.Value = Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd"));
            dateTimePicker1.MaxDate = dateTimePicker1.Value;





        }

        int LogAdminKass = 0;


        private void Desirialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Person person1 = (Person)formatter.Deserialize(fs);
                int id = Convert.ToInt32(person1.Id);
                LogAdminKass = id;
                if (id == 1)
                {
                          treeView1.Nodes[0].Nodes.RemoveAt(3);
                    treeView1.Nodes[0].Nodes.RemoveAt(2);

                }

            }

        }

       
        private void NewAndREd()                                                                                        //Показывает или не,  верхии кнопки в менюшке Администрация ->Просмотр кондитерских изделий
        {
            XmlSerializer fr = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Person person1 = (Person)fr.Deserialize(fs);
                int id = Convert.ToInt32(person1.Id);
                if (id == 2)
                {
                    toolStripButton2.Visible = true;
                    toolStripButton3.Visible = true;
                    toolStripButton4.Visible = true;
                    

                }
                else
                {
                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton4.Visible = true;
                }
            }


        }
        private void information()                                                                                       // криво , очень, понимаю но ...))Xd
        {                                                                                                                //Фун-и, и нижняя тоже, которая скрывает/показывает лишнее,  при нажатие на кнопки,про инфу
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            maskedTextBox2.Visible = false;
         
            maskedTextBox4.Visible = false;
            button1.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label11.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
          
            label7.Visible = false;
        }
        private void NewKass_Admin()
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox1.Visible = true;
            textBox4.Visible = true;
            dateTimePicker1.Visible = true;
            maskedTextBox2.Visible = true;
          
            maskedTextBox4.Visible = true;
            button1.Visible = true;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label11.Visible = true;
            label1.Visible = true;
            label8.Visible = true;
           
            label7.Visible = true;
        }


        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        public List<Kassir> kassir = new List<Kassir>();                                                //Две строки которая помогает с БД 
        ClassDataBase db = new ClassDataBase();                                                         // В данном случае, используется таблица Кассир
        void LoadDataFromDBKassir()                                                                         //Вывод  БД про кассиров
        {
            kassir.Clear();
            dgvKassir.Rows.Clear();                                                             //dgvKassir - название даты грид вью, точнее  таблиця
            string s = @"SELECT * FROM Kassir;";
                db.Execute<Kassir>("CourseWork.db", s, ref kassir);

                for (int i = 0; i < kassir.Count; i++)
                {
                    dgvKassir.Rows.Add( kassir[i].Name, kassir[i].Familia, kassir[i].NomerPasport, kassir[i].Adress, kassir[i].Telephone, kassir[i].DataYear, kassir[i].ColWork);

                }
          
        }



        public List<Admin> admin = new List<Admin>();

        void LoadDataFromDBAdmin()                                                                      //Вывод БД про Администраторов
        {
            admin.Clear();
            dgvAdmin.Rows.Clear();
            string s = @"SELECT * FROM Admin;";
            db.Execute<Admin>("CourseWork.db", s, ref admin);

            for (int i = 0; i < admin.Count; i++)
            {
                dgvAdmin.Rows.Add( admin[i].Name, admin[i].Familai, admin[i].Nomer_pasport, admin[i].Adress, admin[i].Telephone, admin[i].Data_year, admin[i].Col_work);

            }

        }
        public List<Conditer> conditer = new List<Conditer>();

        void LoadDataFromDBConditer()                                                                                  //Вывод БД про Кондитерских изделий
        {
            conditer.Clear();
            dgvFood.Rows.Clear();
            string s = @"SELECT * FROM Conditer;";
            db.Execute<Conditer>("CourseWork.db", s, ref conditer);

            for (int i = 0; i < conditer.Count; i++)
            {
                dgvFood.Rows.Add(conditer[i].Id,conditer[i].ColConditer, conditer[i].Name, conditer[i].NameConditer, conditer[i].DataPostavka, conditer[i].NamePostavka, conditer[i].Telephone, conditer[i].SaleOneConditer, conditer[i].FulSaleConditer);

            }

        }
        void AddAdminDB()                                                                                       //Функ-ия,которая сохраняет Инфу про Админов
        {                                                                                       

            string s1 = @"INSERT INTO Admin (Name,Familia,NomerPasport,Adress,Telephone,DataYear,ColWork)VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + maskedTextBox2.Text + "','" + dateTimePicker1.Text + "','" + maskedTextBox4.Text + "');";


            int t = db.ExecuteNonQuery("CourseWork.db", s1);
            if (t != 0)
            {
                MessageBox.Show("Сохранено в базу Admin", "Informatoin", MessageBoxButtons.OK);
            }
            textBox2.Clear();textBox3.Clear();textBox4.Clear();textBox1.Clear(); maskedTextBox2.Clear(); 
            
           maskedTextBox4.Clear();// делает пустыми формы ввода
            LoadDataFromDBAdmin();                                                                                                                                                //Загружает в дату грид вью данные
                                                                                                                                                                                  //Ctr + Клик на эту вызов функцию

        }


        void AddKassirDB()                                                                                          //Сохранение Инфу про кассиров 
        {

            string s1 = @"INSERT INTO Kassir (Name,Familia,NomerPasport,Adress, Telephone,DataYear,ColWork)VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + maskedTextBox2.Text + "','" + dateTimePicker1.Text + "','" + maskedTextBox4.Text + "');";


            int t = db.ExecuteNonQuery("CourseWork.db", s1);
            if (t != 0)
            {
                MessageBox.Show("Сохранено в базу Kassir", "Informatoin", MessageBoxButtons.OK);
            }
            textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox1.Clear(); maskedTextBox2.Clear();  maskedTextBox4.Clear();
            LoadDataFromDBKassir(); //то же самое что и на 184/183 строке

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text!=""&& textBox4.Text!= "" && textBox1.Text != "" && maskedTextBox2.Text != ""&& dateTimePicker1.Text!=""&& maskedTextBox4.Text!="")
            {
                if (gbKassir_admin.Text == "Информация о кассире")   //проверяет какой гроубокс активен и вызывается функ добавление в БД из форм ввода
                    AddKassirDB();
                else
                {
                    if (gbKassir_admin.Text == "Информация о администраторе")
                        AddAdminDB();
                }
            }
            else
            {
                MessageBox.Show("Заполните правильно и все формы заполнения!", "Error", MessageBoxButtons.OK);
            }

        }

        private void treeView1_NodeMouseDoubleClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {                                                                                                 // Страшная хрень. это типо то что ты нажимаешь в левой стороны экрана приложения
            switch (treeView1.SelectedNode.Text.ToString())                                                //Хреново визуально в коде сделал но думаю ты разберешься
            {                                                                                               //Тут при двойном клике вызывается switch  и проверяет что ты выбрал из списка дерева
                case "Информация о кассирах":
                    gbKassir_admin.Text = "Информация о кассирах";
                    dgvKassir.Visible = true;
                    gbKassir_admin.Visible = true;
                    information();
                    LoadDataFromDBKassir();
                    dgvAdmin.Visible = false;
                    dgvFood.Visible = false;
                    gbSort.Visible = false;
                    gbSearch.Visible = false;

                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton4.Visible = false;
                    
                    toolStripButton5.Visible = true;
                    toolStripButton5.Text = "Удалить кассира";
                    break;
                case "Просмотр кондитерских изделий":
                    gbKassir_admin.Text = "Информация о изделий";
                    toolStripButton5.Visible = false;
                    gbKassir_admin.Visible = true;
                    information();
                    dgvFood.Rows.Clear();
                    LoadDataFromDBConditer();
                    dgvKassir.Visible = false;
                    dgvAdmin.Visible = false;
                    dgvFood.Visible = true;
                    gbSort.Visible = true;
                    gbSearch.Visible = true;
                    NewAndREd();
                    comboBox1.Text = "";
                    textBox5.Text = "";
                    break;
                case "Информация о администраторах":
                    gbKassir_admin.Text = "Информация о администраторах";
                    dgvAdmin.Visible = true;
                    gbKassir_admin.Visible = true;
                    information();
                    LoadDataFromDBAdmin();
                    dgvKassir.Visible = false;
                    dgvFood.Visible = false;
                    gbSort.Visible = false;
                    gbSearch.Visible = false;

                    toolStripButton5.Visible = true;
                    toolStripButton5.Text = "Удалить администратора";
                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton4.Visible = false;
                    break;
                case "Добавление кассиров":
                    gbKassir_admin.Text = "Информация о кассире";
                    NewKass_Admin();
                    LoadDataFromDBKassir();

                    toolStripButton5.Visible = true;
                    toolStripButton5.Text = "Удалить кассира";
                    dgvKassir.Visible = true;
                    gbKassir_admin.Visible = true;
                    dgvFood.Visible = false;
                    dgvAdmin.Visible = false;
                    gbSort.Visible = false;
                    gbSearch.Visible = false;

                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton4.Visible = false;

                    break;
                case "Добавление администраторов":
                    gbKassir_admin.Text = "Информация о администраторе";
                    NewKass_Admin();
                    LoadDataFromDBAdmin();

                    toolStripButton5.Visible = true;
                    toolStripButton5.Text = "Удалить администратора";
                    gbKassir_admin.Visible = true;
                    dgvKassir.Visible = false;
                    dgvFood.Visible = false;
                    dgvAdmin.Visible = true;
                    gbSort.Visible = false;
                    gbSearch.Visible = false;

                    toolStripButton2.Visible = false;
                    toolStripButton3.Visible = false;
                    toolStripButton4.Visible = false;
                    break;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)           //Верхние кнопки на форме Menu
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            NewConditer newConditer = new NewConditer();
            newConditer.ShowDialog();
            LoadDataFromDBConditer();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = Convert.ToString(dgvFood.SelectedCells[0].RowIndex);
                int i = 1 + Convert.ToInt32(textBox6.Text);
                int id1 = Convert.ToInt32(dgvFood.Rows[Convert.ToInt32( textBox6.Text)].Cells[0].Value.ToString());
                textBox6.Text = Convert.ToString(id1);

             
                // textBox6.Text = dgvFood.CurrentCell.Value.ToString();
              
                RedCondit Rc = new RedCondit(this.textBox6.Text);
                Rc.ShowDialog();
                LoadDataFromDBConditer();
            }
            catch 
            {

                
            }
          


           

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            SeleCond Sc = new SeleCond();
            Sc.ShowDialog();
            LoadDataFromDBConditer();
        }

        private void Menu_FormClosing_1(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvFood.Rows.Clear();                                           //чистим дату грид чтобы показать поисковые строки
            SearchDataFromDB1();

        }

        void SearchDataFromDB1()
        {
            conditer.Clear();
            string r = "";
            if (comboBox1.Text == "Количество")
                r = @"SELECT * FROM Conditer where ColConditer ='" + textBox5.Text + "';";
            else
                if (comboBox1.Text == "Название")
                r = @"SELECT * FROM Conditer where Name ='" + textBox5.Text + "';";
            else
                if (comboBox1.Text == "Компания поставки")
                r = @"SELECT * FROM Conditer where NamePostavka ='" + textBox5.Text + "';";
            else
                if (comboBox1.Text == "Полная стоймость")
                r = @"SELECT * FROM Conditer where FulSaleConditer ='" + textBox5.Text + "';";
            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conditer.Clear();
                dgvFood.Rows.Clear();
               
            }
            db.Execute<Conditer>("CourseWork.db", r, ref conditer);
            for (int i = 0; i < conditer.Count; i++)
            {
                dgvFood.Rows.Add(conditer[i].Id, conditer[i].ColConditer, conditer[i].Name, conditer[i].NameConditer, conditer[i].DataPostavka, conditer[i].NamePostavka, conditer[i].Telephone, conditer[i].SaleOneConditer,conditer[i].FulSaleConditer);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox5.Text = "";
            radioButton3.Checked = true;
            LoadDataFromDBConditer();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            conditer.Clear();
            dgvFood.Rows.Clear();
            string r = "";            
                r = @"SELECT * FROM Conditer ORDER BY ColConditer;";           
            db.Execute<Conditer>("CourseWork.db", r, ref conditer);
            for (int i = 0; i < conditer.Count; i++)
            {
                dgvFood.Rows.Add(conditer[i].Id, conditer[i].ColConditer, conditer[i].Name, conditer[i].NameConditer, conditer[i].DataPostavka, conditer[i].NamePostavka, conditer[i].Telephone, conditer[i].SaleOneConditer, conditer[i].FulSaleConditer);

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox5.Text = "";
            LoadDataFromDBConditer();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            conditer.Clear();
            dgvFood.Rows.Clear();
            string r = "";
            r = @"SELECT * FROM Conditer ORDER BY SaleOneConditer;";
            db.Execute<Conditer>("CourseWork.db", r, ref conditer);
            for (int i = 0; i < conditer.Count; i++)
            {
                dgvFood.Rows.Add(conditer[i].Id, conditer[i].ColConditer, conditer[i].Name, conditer[i].NameConditer, conditer[i].DataPostavka, conditer[i].NamePostavka, conditer[i].Telephone, conditer[i].SaleOneConditer, conditer[i].FulSaleConditer);

            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }
       
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (toolStripButton5.Text == "Удалить кассира")
                {
                  int fo =   dgvKassir.SelectedCells[0].RowIndex;
                    string id = Convert.ToString(dgvKassir.Rows[fo].Cells[2].Value.ToString());
                    kassir.Clear();
                    string sb11 = @"delete from Kassir WHERE NomerPasport = '" + id + "';";                   
                    db.ExecuteNonQuery("CourseWork.db", sb11);
                    LoadDataFromDBKassir();
                }
                else
          if (toolStripButton5.Text == "Удалить администратора")
                {
                    int fo = dgvAdmin.SelectedCells[0].RowIndex;
                    string id = Convert.ToString(dgvAdmin.Rows[fo].Cells[2].Value.ToString());
                    admin.Clear();
                    string sb11 = @"delete from Admin WHERE NomerPasport = '" + id + "';";
                    db.ExecuteNonQuery("CourseWork.db", sb11);
                    LoadDataFromDBAdmin();
                }
            }
            catch 
            {

                
            }
          

            
        }

        private void toolStripButton6_Click(object sender, EventArgs e) // продукция
        {
            Product product = new Product();
            product.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e) // поставка
        {
            Postavka postavka = new Postavka();
            postavka.ShowDialog();
        }
    }
}
