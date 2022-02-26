using System;

namespace Hex_Bin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] result = null;
            string Path = "ConsoleApplication1.exe";
            //FileLoad f = new FileLoad(Path);
            file f = new file(Path);
           
            f.ShowAdres = true;
            f.ShowAscii = true;
            f.ShowLineNumbers = true;
            f.ShowValue = true;
            f.Minbyte = 0;
            f.Maxbyte = 1024;
            f.AllByte = false;
            f.WordSize = 4;
            f.ColonWord = 2;
           result =  f.Format();
            if (result != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
            else
            {
                Console.WriteLine("datu nav");
            }
        }
    }
}
