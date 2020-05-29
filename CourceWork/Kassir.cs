using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourceWork
{
    public class Kassir
    {
        private int id;
        private string name;
        private string familia;
        private string nomerPasport;
        private string adress;
        private string telephone;
        private string dataYear;
      
        private int colWork;

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
        public string Familia
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
        public string NomerPasport
        {
            set
            {
                nomerPasport = value;
            }
            get
            {
                return nomerPasport;
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
        public string DataYear
        {
            set
            {
                dataYear = value;
            }
            get
            {
                return dataYear;
            }
        }
       
        public int ColWork
        {
            set
            {
                colWork = value;
            }
            get
            {
                return colWork;
            }
        }
        public Kassir()
        {
            id = -1;
            name = "";
            familia = "";
            nomerPasport = "";
            adress = "";
            telephone = "";
            dataYear = "";
           
            colWork = 0;

        }



        public Kassir(int id, string name, string familia, string nomerPasport,
            string adress, string telephone, string dataYear, int nomerKassir, int colWork)
        {
            id = -1;
            this.name = name;
            this.familia = familia;
            this.nomerPasport = nomerPasport;
            this.adress = adress;
            this.telephone = telephone;
            this.dataYear = dataYear;
           
            this.colWork = colWork; 

        }

        public Kassir(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            name = val[1];
            familia = val[2];
            nomerPasport = val[3];
            adress = val[4];
            telephone = val[5];
            dataYear = val[6];
           
            colWork= Convert.ToInt32(val[7]);

        }

    }
}
