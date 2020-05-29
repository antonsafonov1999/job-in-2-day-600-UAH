using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourceWork
{
    public class Conditer
    {
        private int id;
        private int colConditer;
        private string nameConditer;
        private string name;
        private string telephone;       
        private int saleOneConditer;
        private string dataPostavka;
        private string namePostavka;
        private int fulSaleConditer;
        
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string NameConditer
        {
            set
            {
                nameConditer = value;
            }
            get
            {
                return nameConditer;
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
        public int ColConditer
        {
            set
            {
                colConditer = value;
            }
            get
            {
                return colConditer;
            }
        }
       
        public int SaleOneConditer
        {
            set
            {
                saleOneConditer = value;
            }
            get
            {
                return saleOneConditer;
            }
        }
        public string DataPostavka
        {
            set
            {
                dataPostavka = value;
            }
            get
            {
                return dataPostavka;
            }
        }
        public int FulSaleConditer
        {
            set
            {
                fulSaleConditer = value;
            }
            get
            {
                return fulSaleConditer;
            }
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
        public string NamePostavka
        {
            set
            {
                namePostavka = value;
            }
            get
            {
                return namePostavka;
            }
        }
        public Conditer()
        {
            id = -1;
            colConditer = 0;
            nameConditer = "";
            name = "";
            telephone = "";          
            saleOneConditer = 0;
            dataPostavka = "";
            fulSaleConditer = 0;          
            namePostavka = "";

        }

      

        public Conditer(int id,string nameConditer, string telephone, int colConditer,int saleOneConditer,
            string dataPostavka,int fulSaleConditer, string name, string namePostavka)
        {
            Id = -1;
            this.nameConditer = nameConditer;
            this.telephone = telephone;
            this.colConditer = colConditer;
            this.saleOneConditer = saleOneConditer;
            this.dataPostavka = dataPostavka;
            this.fulSaleConditer = fulSaleConditer;
            this.name = name;
            this.namePostavka = namePostavka;
        }

        public Conditer(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            nameConditer = val[1];
            telephone = val[2];
            colConditer =Convert.ToInt32( val[3]);
            saleOneConditer =Convert.ToInt32( val[4]);
            dataPostavka = val[5];     
            fulSaleConditer =Convert.ToInt32( val[6]);
            name = val[7];
            namePostavka = val[8];
          
        }

    }
}
