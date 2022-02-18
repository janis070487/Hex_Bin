using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex_Bin
{
    internal class file
    {
        private Dictionary<string, int> index = new Dictionary<string, int>()
        {
            ["db"] = 1,
            ["dw"] = 2,
            ["lw"] = 4
        };
        //____________________________Parametri____________________________________________
        public string format = "hex"; // pieņem   hex bin dec asci  kada formata attēlot datus
        public char symbol = '.';     // Ja kods neatbilst nevienam simbolam tad to aizstāj ar šo simbolu
        public bool ShowAdres = false; //Parādīt rindu adreses
        public string WordSize = null;       // No cik baitiem sastāvēs vards iespējamais 1 2 4
        public int MinAdress = 0;      // no kuras baita sak lasit 
        public int MaxAdress = 1024;   // lidz kuram baitam lasit
        public string ColonWord = null;
         //_________________________________________________________________________________
        private byte[] data = null;
        private string[] formatdata = null;
        private string path = null;
        FileLoad f;
        private string errorcode = null;
        public string ErrorCode => errorcode != null ? errorcode : "null";
        public string[] FormatData => formatdata != null ? formatdata : null;
        public byte[] Data => data;
        //___________________________Paligdati________________________________________________
        private string[] adressAray = null;   //sagatavotas rindam adreses atsevišķā metodē
        //_____________________________________________________________________________________
        public file(string path)     // konstruktors ja lasa no faila
        {
            this.path = path;
            f = new FileLoad(path);
            data = f.Load();
            if((data != null)&&(f.ErrorCode != false))
            {
                errorcode = "Dati netika nolasīti";
            }
        }
        public file(byte[] data)   // konstruktors ja vajaag nokopēt datus
        {
            this.data = data;
        }
        //______________________Datu formatēšana___________________________________
        //______________________adrešu formatēšana__________________________________
        private void adressformat()
        {
            //int adressArayLenght = (MaxAdress - MinAdress) / (index.)  
            //adressAray = new string[adressArayLenght];
        }
        public void Format()
        {
//
        }
     }
}
