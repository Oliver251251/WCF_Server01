using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Service.Controllers;
using Service.DTO;

namespace Service
{

    public class Service1 : IService1
    {
        public List<Felhasznalok> FelhasznalokLista_CS()
        {
            List<Felhasznalok> felhasznalok = new List<Felhasznalok>();
            List<Record> records = new FelhasznalokController().Select();
            foreach (Record record in records)
            {
                felhasznalok.Add(record as Felhasznalok);
            }

            return felhasznalok;
        }

        public string FelhasznaloHozzaAd_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController felhasznalokController = new FelhasznalokController();
            return felhasznalokController.Insert(felhasznalo);
        }

        public string FelhasznaloModosit_CS(Felhasznalok felhasznalo)
        {
            FelhasznalokController felhasznalokController = new FelhasznalokController();
            return felhasznalokController.Update(felhasznalo);
        }

        public string FelhasznaloTorol_CS(int Id)
        {
            return  new FelhasznalokController().Delete(Id);
        }

        //webes
        public List<Felhasznalok> FelhasznalokLista_Web()
        {
            return FelhasznalokLista_CS();
        }

        public string FelhasznaloHozaAd_Web(Felhasznalok felhasznalo)
        {
            return FelhasznaloHozzaAd_CS(felhasznalo);
        }

        public string FelhasznaloModosit_Web(Felhasznalok felhasznalo)
        {
            return FelhasznaloModosit_CS(felhasznalo);
        }

        public string FelhasznaloTorol_Web(int Id)
        {
            return FelhasznaloTorol_CS(Id);
        }

        //jogosultsagok
        public List<Jogosultsagok> JogosultsagokLista_CS()
        {
            List<Jogosultsagok> jogosultsagok = new List<Jogosultsagok>();
            List<Record> records = new JogosultsagokController().Select();
            foreach (Record record in records)
            {
                jogosultsagok.Add(record as Jogosultsagok);
            }

            return jogosultsagok;
        }

        public string JogosultsagokHozzaAd_CS(Jogosultsagok jogosultsag)
        {
            JogosultsagokController jogosultsagokController = new JogosultsagokController();
            return jogosultsagokController.Insert(jogosultsag);
        }

        public string JogosultsagokModosit_CS(Jogosultsagok jogosultsag)
        {
            JogosultsagokController jogosultsagokController = new JogosultsagokController();
            return jogosultsagokController.Update(jogosultsag);
        }

        public string JogosultsagokTorol_CS(int Id)
        {
            return new JogosultsagokController().Delete(Id);
        }

        //webes
        public List<Jogosultsagok> JogosultsagokLista_Web()
        {
            return JogosultsagokLista_CS();
        }

        public string JogosultsagokHozaAd_Web(Jogosultsagok jogosultsagok)
        {
            return JogosultsagokHozzaAd_CS(jogosultsagok);
        }

        public string JogosultsagokModosit_Web(Jogosultsagok jogosultsagok)
        {
            return JogosultsagokModosit_CS(jogosultsagok);
        }

        public string JogosultsagokTorol_Web(int Id)
        {
            return FelhasznaloTorol_CS(Id);
        }

        //DTO
        public List<FelhasznalokNevEmail> FelhasznalokNevEmail_CS()
        {
            return new FelhasznalokNevEmail().Levalogatas();
        }

        //Login
        public string GetSalt_CS(string loginNev)
        {
            return new LoginController().GetSalt(loginNev);
        }

        public string Login_CS(Login login)
        {
            return new LoginController().Login(login);
        }
    }
}
