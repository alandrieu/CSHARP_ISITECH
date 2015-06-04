using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaveLib.Utils
{
    public class Hashing
    {

        /// <summary>
        /// Cette méthode Hash une chaine avec l'algorithme SHA512. Utilisée pour la protection des Mots de passe en base de données.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string SHA512(string text)
        {
            SHA512 alg = System.Security.Cryptography.SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Encoding.UTF8.GetString(result);
        }
    }
}
