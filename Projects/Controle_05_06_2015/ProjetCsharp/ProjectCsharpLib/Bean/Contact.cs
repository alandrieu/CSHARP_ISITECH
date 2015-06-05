using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCsharpLib.Bean
{
    /// <summary>
    /// Classe d'entité qui représente un Contact
    /// </summary>
    public class Contact
    {
        private static int uniqueId = 0;

        public int Id { get; private set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Email { get; set; }

        public int Age { get; set; }
        public SexeEnum Sexe { get; set; }
        public String Address { get; set; }
        public String TelephoneNumber { get; set; }
        public CountryEnum Country { get; set; }
        public String OwnDescription { get; set; }

        public String FaceBookAccount { get; set; }
        public String GooglePlusAccount { get; set; }
        public String LinkedinAccount { get; set; }

        public enum SexeEnum
        {
            Male,
            Female
        }

        public enum CountryEnum
        {
            France,
            USA,
            Japan
        }

        public Contact()
        {
            Id = uniqueId;
            uniqueId--;
        }
    }
}
