using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCsharpLib.Bean
{
    public class Contact
    {

        public int Id { get; set; }
        public String Name { get; set; }

        public String Email { get; set; }

        public enum SexeEnum
        {
            Male,
            Femelle
        }

        public SexeEnum Sexe { get; set; }
        public int Age { get; set; }

        public Contact()
        {

        }
    }
}
