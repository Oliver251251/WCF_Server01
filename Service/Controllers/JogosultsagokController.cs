using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.DataBaseManager;
using Service.Models;
using MySql.Data.MySqlClient;

namespace Service.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select()
        {
            List<Record> records = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM jogosultsagok ORDER BY Id;";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Jogosultsagok jogosultsagok = new Jogosultsagok();
                    jogosultsagok.Id = int.Parse(reader["Id"].ToString());
                    jogosultsagok.Szint = byte.Parse(reader["Szint"].ToString());
                    jogosultsagok.Nev = reader["Nev"].ToString();
                    jogosultsagok.Leiras = reader["Leiras"].ToString();
                    records.Add(jogosultsagok);
                }
            }
            catch (Exception e)
            {
                Jogosultsagok jogosultsagok = new Jogosultsagok();
                jogosultsagok.Id = -1;
                jogosultsagok.Nev = e.Message;
                records.Add(jogosultsagok);
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
                Jogosultsagok jogosultsagok = record as Jogosultsagok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"INSERT INTO jogosultsagok (Szint, Nev, Leiras) VALUES(@Szint, @Nev, @Leiras);";
                cmd.Parameters.Add(new MySqlParameter("@Szint", MySqlDbType.Byte)).Value = jogosultsagok.Szint;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsagok.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Leiras", MySqlDbType.VarChar)).Value = jogosultsagok.Leiras;
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
                return $"Az új jogosultságok adatai sikeresen eltárolva: {jogosultsagok.Nev}";
            }

            return "Null értéket kaptam";
        }

        public string Update(Record record)
        {
            if (record != null)
            {
                Jogosultsagok jogosultsagok = record as Jogosultsagok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"UPDATE jogosultsagok SET
                    Szint = @Szint, Nev = @Nev, Leiras = @Leiras WHERE Id = @Id";
                cmd.Parameters.Add(new MySqlParameter("Id", jogosultsagok.Id));
                cmd.Parameters.Add(new MySqlParameter("@Szint", jogosultsagok.Szint));
                cmd.Parameters.Add(new MySqlParameter("@Nev", jogosultsagok.Nev));
                cmd.Parameters.Add(new MySqlParameter("@Leiras", jogosultsagok.Leiras));
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
                return $"A jogosultsági adatok ikeresen frissítve: {jogosultsagok.Nev}";
            }

            return "Null értéket kaptam";
        }

        public string Delete(int Id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"DELETE FROM jogosultsagok WHERE Id = @Id";
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
            return $"A jogosultság törölve: {Id}";
        }
    }
}