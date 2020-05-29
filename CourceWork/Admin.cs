using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourceWork
{
    public class Admin
    {
        private int id;
        private string name;
        private string familia;
        private string nomer_pasporta;
        private string adress;
        private string telephone;
        private string data_year;
       
        private int col_work;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public string Familai
        {
            set
            {
                familia = value;
            }
            get
            {
                return familia;
            }
        }
        public string Nomer_pasport
        {
            set
            {
                nomer_pasporta = value;
            }
            get
            {
                return nomer_pasporta;
            }
        }
        public string Adress
        {
            set
            {
                adress = value;
            }
            get
            {
                return adress;
            }
        }
        public string Telephone
        {
            set
            {
                telephone = value;
            }
            get
            {
                return telephone;
            }
        }
        public string Data_year
        {
            set
            {
                data_year = value;
            }
            get
            {
                return data_year;
            }
        }
     
        public int Col_work
        {
            get { return col_work; }
            set { col_work = value; }
        }


        public Admin()
        {
            id = -1;
            name = "";
            familia = "";
            nomer_pasporta = "";
            adress = "";
            telephone = "";
            data_year = "";
           
            col_work = 0;
            


        }

        public Admin(int id,string name, string familia, string nomer_pasporta, string adress,string telephone,string data_year,int nomer_admina,int col_work)
        {
            Id = -1;
            this.name = name;
            this.familia = familia;
            this.nomer_pasporta = nomer_pasporta;
            this.adress = adress;
            this.telephone = telephone;
            this.data_year = data_year;
           
            this.col_work = col_work;
        
        }

        public Admin(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            name = val[1];
            familia = val[2];
            nomer_pasporta = val[3];
            adress = val[4];
            telephone = val[5];
            data_year = val[6];
           
            col_work = Convert.ToInt32( val[7]);
           


        }

    }
}
