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
        private int byteCounter = 0;
        public string format = "hex"; // pieņem   hex bin dec asci  kada formata attēlot datus
        public char symbol = '.';     // Ja kods neatbilst nevienam simbolam tad to aizstāj ar šo simbolu
        public bool ShowAdres = false; //Parādīt rindu adreses
        public bool ShowValue = false; //parada rindu vertibu parveršot vesalajos sakitlos
        public bool ShowAscii = false; //parada rindu vertibu parversot Asci simbolos
        public int WordSize = 1;       // No cik baitiem sastāvēs vards iespējamais 1 2 4
        public int Minbyte = 0;      // no kuras baita sak lasit 
        public int Maxbyte = 64;   // lidz kuram baitam lasit
        private int minAdress = 0;
        private int maxAdress = 0;
        public int ColonWord = 1;
        private int line = 0;
         //_________________________________________________________________________________
        private byte[] data = null;
        private string path = null;
        FileLoad f;
        private string errorcode = null;
        public string ErrorCode => errorcode != null ? errorcode : "null";
       // public string[] FormatData => formatdata != null ? formatdata : null;
        public byte[] Data => data;
        //___________________________Paligdati________________________________________________
        private string[] adressAray = null;   //sagatavotas rindam adreses atsevišķā metodē
        private string[] asciiAray = null;    //
        private string[] value = null;
        private string[] firstData = null;   //glabajas tikai dati kas ir bez nevienas papildinformacijas
        private string[] formatdata = null;  //glabajas beigu dati
        //_____________________________________________________________________________________
        public file(string path)     // konstruktors ja lasa no faila
        {
            this.path = path;
            f = new FileLoad(path);
           // line = Maxbyte - Minbyte; // apreikina cik bus linijas
            data = f.Load();
            if ((data != null)&&(f.ErrorCode != false))
            {
                errorcode = "Dati netika nolasīti";
            }
        }
        public file(byte[] data)   // konstruktors ja vajaag nokopēt datus
        {
         //   line = Maxbyte - Minbyte; // apreikina cik bus linijas
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
        private void asciFormat()
        {

            asciiAray = new string[line];
            int counter = 0;
            for (int i = 0; i < line; i++)
            {
                
                for (int j = 0; j < ColonWord + WordSize; j++)
                {
                    if ((data[counter] > 32) && (data[counter] < 127))
                    {
                        asciiAray[i] = asciiAray[i] + Convert.ToChar(data[counter]);
                    }
                    else
                    {
                        asciiAray[i] = asciiAray[i] + symbol;
                    }
                    counter++;
                }
            }
        }
        private void valueFornat()
        {
            value = new string[line];
        }
        private void dataFormat()
        {
           firstData = new string[line];
            int counter = minAdress;                   // ar kuru baitu sak kautko darit
            for (int i = 0; i < firstData.Length; i++) // aizpilda visas rindas
            {
                string acumulator = null;
               for(int j = 0; j < ColonWord; j++) // aizpilda vardus rinda
                {
                    for(int k = 0; k < WordSize; k++) //aizpilda vardu atkariba no varda lieluma
                    {
                        acumulator = Convert.ToString(data[counter], toBase: 16);
                        if(acumulator.Length == 1)
                        {
                            acumulator = '0' + acumulator;
                        }
                        if (byteCounter < Maxbyte)
                        {
                            firstData[i] = firstData[i] + acumulator;
                        counter++;
                        byteCounter++;
                        
                           
                        }
                        
                    }
                    firstData[i] = firstData[i] + ' '; // Starm rindas vardiem ieliek atstarpi
                   // firstData[i] = acumulator + ' ';
                }
          
            }
        }
        private void restart()
        {
            //___________________nomešana_______________________________
            formatdata = null;
            line = 0;
            byteCounter = 0;
            adressAray = null;
            firstData = null;
            asciiAray = null;
            value = null;
            //___________________inicilizacija__________________________

            // formatdata = new string[line];
            line = Maxbyte - Minbyte; // apreikina cik bus linijas
            line = line / (WordSize * ColonWord);
           
            if ((Maxbyte - Minbyte) % (ColonWord * WordSize) != 0) // ja dalot ir atlikums tad pievieno vel vienu liniju
            {
                line++;
            }
            formatdata = new string[line]; // beigu dati
        }
        private void finishData()
        {
        for(int i = 0; i < line; i++)
            {
                if (ShowAdres)
                {
                    formatdata[i] = formatdata[i] + adressAray[i] + '\t';
                }

                formatdata[i] = formatdata[i] + firstData[i] + '\t';

                if (ShowAscii)
                {
                    formatdata[i] = formatdata[i] + asciiAray[i] + '\t';
                }
                if (ShowValue)
                {

                }
            }
        }
        public string[] Format()
        {
           restart();
            if (ShowAdres)
            {
                adressformat();
            }
            dataFormat();
            if (ShowAscii)
            {
                asciFormat();
            }
            if (ShowValue)
            {
                valueFornat();
            }
           finishData();
            return formatdata;
           // return firstData;
        }
     }
}
