using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Serialization()                                                         //Сериализация для того чтобы сохранить выбор, и в формк Menu
        {
            int a = 0;                                                                       // показывало или нет, функции Админа.
            if (radioButton1.Checked == true) a = 1;                                        

            if (radioButton2.Checked == true) a = 2;

            Person person = new Person(a);
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))     // * Сохраняется Id в файле persons.xml
            { formatter.Serialize(fs, person); }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // Переход на Menu(форму) с проверкой на пустые поля 
        {
                Serialization();                                   //Вызывается функция сериализации чтобы в Menu после  вызвать Десериализацию, и прочить тот радион батон котороый ты выбрал.
                this.Hide();
                Menu f1 = new Menu();
                f1.ShowDialog();

          
        }

    }
}
