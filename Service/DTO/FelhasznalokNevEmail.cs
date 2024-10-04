using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Controllers;
using Service.Models;

namespace Service.DTO
{
    public class FelhasznalokNevEmail
    {
        public string Email { get; set; }
        public string Nev {get; set;}
        
        public FelhasznalokNevEmail() { }

        private FelhasznalokNevEmail(string Nev, string Email)
        {
            this.Nev = Nev;
            this.Email = Email;
        }

        public List<FelhasznalokNevEmail> Levalogatas()
        {
            List<FelhasznalokNevEmail> adatok = new List<FelhasznalokNevEmail>();

            foreach (Record record in new FelhasznalokController().Select())
            {
                adatok.Add(new FelhasznalokNevEmail((record as Felhasznalok).Nev, (record as Felhasznalok).Email));
            }

            return adatok;
        }
    }
}