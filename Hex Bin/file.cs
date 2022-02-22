using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex_Bin
{
    internal class file
    {
        //____________________________Parametri____________________________________________
        public string format = "hex"; // pieņem   hex bin dec asci  kada formata attēlot datus
        public char symbol = '.';     // Ja kods neatbilst nevienam simbolam tad to aizstāj ar šo simbolu
        public bool ShowAdres = false; //Parādīt rindu adreses
        public int WordSize = 1;       // No cik baitiem sastāvēs vards iespējamais 1 2 4
        public int Minbyte = 0;      // no kuras baita sak lasit 
        public int Maxbyte = 64;   // lidz kuram baitam lasit
        private int minAdress = 0;
        private int maxAdress = 0;
        public int ColonWord = 1;
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
        private string[] asciiAray = null;
        private string[] value = null;
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
        public string[] DataFormatHex()
        {
            return formatdata;
        }
        //______________________adrešu formatēšana__________________________________
        private void adressformat()
        {
            if (ShowAdres)
            {
                int line = Maxbyte - Minbyte; // apreikina cik bus linijas
                line = line / (WordSize * ColonWord);
                if ((Maxbyte - Minbyte) % (ColonWord * WordSize) != 0) // ja dalot ir atlikums tad pievieno vel vienu liniju
                {
                    line++;
                }
                adressAray = new string[line];  // izveido masivu liniju adresu izveidei
                string acumulator;
                for (int i = 0; i < line; i++)
                {
                    acumulator = Convert.ToString(Minbyte + (ColonWord * WordSize * i));
                    while (acumulator.Length < 8)
                    {
                        acumulator = '0' + acumulator;
                    }
                    adressAray[i] = acumulator;
                    acumulator = "";
                }
            }
        }
        private void asciFormat()
        {
//
        }
        private void valueFornat()
        {
//
        }
        public string[] dataFormat()
        {
            adressformat();
            asciFormat();
            valueFornat();
            return formatdata;
        }
     }
}
