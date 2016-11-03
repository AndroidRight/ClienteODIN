using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClienteODIN.NET
{
    public class Handler
    {
        private string dat = "apagado.bat";
        private string dat2 = "reiniciado.bat";
        public void MainCMD(string commands)
        {
            switch (commands)
            {
                case "apagar":
                    {                  
                        Process.Start(dat);
                    }
                    break;
                case "reiniciar":
                    {
                        Process.Start(dat2);
                        break;
                    }
            }
        }
    }
}
