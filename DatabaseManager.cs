using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Proiect_Admitere_Facultate
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source=admitere.db;Version=3;";

        public DatabaseManager()
        {
            if (!File.Exists("admitere.db"))
            {
                SQLiteConnection.CreateFile("admitere.db");
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Candidati (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nume TEXT, Prenume TEXT, CNP TEXT UNIQUE, 
                        Facultate TEXT, MedieBac REAL, NotaAdmitere REAL, 
                        PondereBac REAL, PondereAdmitere REAL, MedieFinala REAL)";
                using (var cmd = new SQLiteCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
            }
        }

        public void InserareCandidat(Candidat c)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Candidati (Nume, Prenume, CNP, Facultate, MedieBac, NotaAdmitere, PondereBac, PondereAdmitere, MedieFinala) " +
                     "VALUES (@n, @p, @cnp, @f, @mb, @na, @pb, @pa, @mf)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", c.Nume);
                    cmd.Parameters.AddWithValue("@p", c.Prenume);
                    cmd.Parameters.AddWithValue("@cnp", c.CNP);
                    cmd.Parameters.AddWithValue("@f", c.FacultateAleasa);
                    cmd.Parameters.AddWithValue("@mb", c.MediiExamen.MedieBac);
                    cmd.Parameters.AddWithValue("@na", c.MediiExamen.NotaAdmitere);
                    cmd.Parameters.AddWithValue("@pb", c.MediiExamen.PondereBac); 
                    cmd.Parameters.AddWithValue("@pa", c.MediiExamen.PondereAdmitere); 
                    cmd.Parameters.AddWithValue("@mf", c.MedieCalculata);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Candidat> IncarcaCandidati()
        {
            List<Candidat> lista = new List<Candidat>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Candidati";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double pBac = Convert.ToDouble(reader["PondereBac"]);
                        double pAdm = Convert.ToDouble(reader["PondereAdmitere"]);

                        Medii m = new Medii(Convert.ToDouble(reader["MedieBac"]),
                                            Convert.ToDouble(reader["NotaAdmitere"]),
                                            pBac, pAdm); 

                        Candidat c = new Candidat(reader["Nume"].ToString(),
                                                 reader["Prenume"].ToString(), "",
                                                 reader["CNP"].ToString(),
                                                 DateTime.Now, "", m,
                                                 reader["Facultate"].ToString());
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        public void StergeCandidat(string cnp)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Candidati WHERE CNP = @cnp";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cnp", cnp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizeazaCandidat(Candidat c, string cnpOriginal)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Candidati 
                       SET Nume=@n, Prenume=@p, Facultate=@f, 
                           MedieBac=@mb, NotaAdmitere=@na, 
                           PondereBac=@pb, PondereAdmitere=@pa, 
                           MedieFinala=@mf 
                       WHERE CNP=@cnpOrig";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", c.Nume);
                    cmd.Parameters.AddWithValue("@p", c.Prenume);
                    cmd.Parameters.AddWithValue("@f", c.FacultateAleasa);
                    cmd.Parameters.AddWithValue("@mb", c.MediiExamen.MedieBac);
                    cmd.Parameters.AddWithValue("@na", c.MediiExamen.NotaAdmitere);
                    cmd.Parameters.AddWithValue("@pb", c.MediiExamen.PondereBac);
                    cmd.Parameters.AddWithValue("@pa", c.MediiExamen.PondereAdmitere);
                    cmd.Parameters.AddWithValue("@mf", c.MedieCalculata);
                    cmd.Parameters.AddWithValue("@cnpOrig", cnpOriginal);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}