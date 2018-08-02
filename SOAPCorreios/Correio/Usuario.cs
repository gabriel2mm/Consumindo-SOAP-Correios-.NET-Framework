using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPCorreios.Correio
{
    public class Usuario
    {
        private static Usuario instance;

        public static Usuario getInstance()
        {
            if (instance == null)
            {
                instance = new Usuario();
            }
            return instance;
        }

        public Usuario()
        {
            this.User = "ECT";
            this.Pass = "SRO";
            this.Tipo = "L";
            this.Result = "T";
            this.Language = "101";
        }

        public String User { get; set; }
        public String Pass { get; set; }
        public String Tipo { get; set; }
        public String Result { get; set; }
        public String Language { get; set; }
    }
}
