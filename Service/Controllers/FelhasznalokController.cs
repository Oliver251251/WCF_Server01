using MySql.Data.MySqlClient;
using Service.DataBaseManager;
using Service.Models;
using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    public class FelhasznalokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select()
        {
            List<Record> records = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok ORDER BY Nev;";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Felhasznalok felhasznalo = new Felhasznalok();
                    felhasznalo.Id = int.Parse(reader["Id"].ToString());
                    felhasznalo.LoginNev = reader["LoginNev"].ToString();
                    felhasznalo.HASH = reader["HASH"].ToString();
                    felhasznalo.SALT = reader["SALT"].ToString();
                    felhasznalo.Nev = reader["Nev"].ToString();
                    felhasznalo.Jog = int.Parse(reader["Jog"].ToString());
                    felhasznalo.Aktiv = bool.Parse(reader["Aktiv"].ToString());
                    felhasznalo.Email = reader["Email"].ToString();
                    felhasznalo.ProfilKep = reader["ProfilKep"].ToString();
                    records.Add(felhasznalo);
                }
            }
            catch (Exception e)
            {
                Felhasznalok felhasznalo = new Felhasznalok();
                felhasznalo.Id = -1;
                felhasznalo.Nev = e.Message;
                records.Add(felhasznalo);
            }
            finally
            {
                connection.Close();
            }

            return records;
        }

        public string Insert(Record record)
        {
            if (record != null)
            {
                Felhasznalok felhasznalok = record as Felhasznalok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"INSERT INTO felhasznalok (LoginNev, HASH, SALT, Nev, Jog, Aktiv, Email, ProfilKep)" +
                    @"VALUES(@LoginNev, @HASH, @SALT, @Nev, @Jog, @Aktiv, @Email, @ProfilKep);";
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.VarChar)).Value = felhasznalok.LoginNev;
                cmd.Parameters.Add(new MySqlParameter("@HASH", MySqlDbType.VarChar)).Value = felhasznalok.HASH;
                cmd.Parameters.Add(new MySqlParameter("@SALT", MySqlDbType.VarChar)).Value = felhasznalok.SALT;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = felhasznalok.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Jog", MySqlDbType.Int32)).Value = felhasznalok.Jog;
                cmd.Parameters.Add(new MySqlParameter("@Aktiv", MySqlDbType.Byte)).Value = felhasznalok.Aktiv;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = felhasznalok.Email;
                cmd.Parameters.Add(new MySqlParameter("@ProfilKep", MySqlDbType.VarChar)).Value = felhasznalok.ProfilKep;
                cmd.Connection = BaseDatabaseManager.connection;

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Connection.Close();
                }
                return $"A felhasználó adatai sikeresen eltárolva: {felhasznalok.Nev}";
            }

            return "Null értéket kaptam";
        }

        public string Update(Record record)
        {
            if (record != null)
            {
                Felhasznalok felhasznalok = record as Felhasznalok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"UPDATE felhasznalok SET
                    LoginNev = @LoginNev, HASH = @HASH, SALT = @SALT, Nev = @Nev, Jog = @Jog, Aktiv = @Aktiv,Email = @Email, ProfilKep = @ProfilKep WHERE Id = @Id";
                cmd.Parameters.Add(new MySqlParameter("Id", felhasznalok.Id));
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", felhasznalok.LoginNev));
                cmd.Parameters.Add(new MySqlParameter("@HASH", felhasznalok.HASH));
                cmd.Parameters.Add(new MySqlParameter("@SALT", felhasznalok.SALT));
                cmd.Parameters.Add(new MySqlParameter("@Nev", felhasznalok.Nev));
                cmd.Parameters.Add(new MySqlParameter("@Jog", felhasznalok.Jog));
                cmd.Parameters.Add(new MySqlParameter("@Aktiv", felhasznalok.Aktiv));
                cmd.Parameters.Add(new MySqlParameter("@Email", felhasznalok.Email));
                cmd.Parameters.Add(new MySqlParameter("@ProfilKep", felhasznalok.ProfilKep));
                cmd.Connection = BaseDatabaseManager.connection;

                try
                {
                    cmd.Connection.Open();
                    int db = cmd.ExecuteNonQuery();
                    if (db == 0)
                    {
                        return "Hibás id-t adtál meg!";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Connection.Close();
                }
                return $"A felhasználó adatai sikeresen frissítve: {felhasznalok.Nev}";
            }

            return "Null értéket kaptam";
        }

        public string Delete(int Id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"DELETE FROM felhasznalok WHERE Id = @Id";
            cmd.Parameters.Add(new MySqlParameter("Id", Id));
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();

                if (db == 0)
                {
                    return "Nincs ilyen id";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Connection.Close();
            }
            return $"Felhasználó törölve: {Id}";
        }
    }
}