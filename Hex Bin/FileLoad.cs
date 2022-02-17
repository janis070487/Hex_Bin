using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Hex_Bin
{
    internal class FileLoad
    {
        private string path;
        private byte[] data;
        private bool errorcode = false;
        public string Path => path != null ? path : "null";
        public byte[] Data => data;
        public bool ErrorCode => errorcode;
        public FileLoad(){ }
        public FileLoad(string path) 
        {
            this.path = path;
        }
        public byte[] Load()
        {
            if (File.Exists(path))
            {
                data = File.ReadAllBytes(path);
                errorcode = true;   
                return data;
            }
            else
            {
               errorcode = false;
                return null;
            }
        }

    }
}
