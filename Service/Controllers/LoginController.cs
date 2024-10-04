using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Service.Controllers
{
    public class LoginController
    {
        public string GetSalt(string loginNev)
        {
            /*
            //Egy felhasznalo SALT és HASH  adatbázisban történő megadásához.
            string jelszo = "a";
            string SALT = new Login().GenerateSalt();
            string TESTHASH = new Login().CreateSHA256(jelszo+SALT);
            string HASH = new Login().CreateSHA256(TESTHASH);
            //Vége
            */

            List<Record> records = new FelhasznalokController().Select();
            int szamlalo = 0;
            string Salt = string.Empty;
            while (true && szamlalo < records.Count)
            {
                if ((records[szamlalo] as Felhasznalok).LoginNev == loginNev)
                {
                    Salt = (records[szamlalo] as Felhasznalok).SALT;
                    break;
                }
                szamlalo++;
            }

            return Salt;
        }

        public string Login(Login login)
        {
            string Hash = new Login().CreateSHA256(login.HASH);
            List<Record> felhasznalok = new FelhasznalokController().Select();
            int szamlalo = 0;
            string token = "";
            while (true && szamlalo < felhasznalok.Count)
            {
                if ((felhasznalok[szamlalo] as Felhasznalok).LoginNev == login.LoginNev && (felhasznalok[szamlalo] as Felhasznalok).HASH == Hash)
                {
                    token = Guid.NewGuid().ToString();
                    break;
                }
                szamlalo++;
            }
            return token;
        }

    }
}