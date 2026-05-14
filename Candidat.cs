using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Admitere_Facultate
{
    [Serializable]
    public class Candidat : Persoana, ICloneable, IComparable, IExportabil
    {
        private Medii mediiExamen;
        private string facultateAleasa;

        public Medii MediiExamen
        {
            get { return mediiExamen; }
            set
            {
                if (value == null)
                    throw new Exception("Medii invalide!");
                mediiExamen = value;
            }
        }

       
        public double MedieCalculata
        {
            get
            {
                if (MediiExamen == null) return 0;
               
                return MediiExamen.CalculeazaMedieFinala();
            }
         }

        public string FacultateAleasa
        {
            get { return facultateAleasa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Facultatea este obligatorie!");
                facultateAleasa = value;
            }
        }

        public Candidat() { }

        public Candidat(string nume, string prenume,string sex, string cnp,DateTime dataNasterii,string domiciliu, Medii medii, string facultate)
            : base(nume, prenume,sex,cnp,dataNasterii,domiciliu)
        {
            MediiExamen = medii;
            FacultateAleasa = facultate;
        }
        public override string ObtineStatusAdmitere()
        {
            return MedieCalculata >= 6.00 ? "Admis" : "Respins";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is Candidat))
                throw new Exception("Obiectul nu este candidat");
            Candidat c= (Candidat)obj;
            return MedieCalculata.CompareTo(c.MedieCalculata);
        }

        public object Clone()
        {
            Candidat clona = new Candidat(Nume, Prenume, Sex, CNP, DataNasterii, Domiciliu,new Medii(MediiExamen.MedieBac,
                MediiExamen.NotaAdmitere,MediiExamen.PondereBac, MediiExamen.PondereAdmitere) ,FacultateAleasa);
            return clona;
        }
        public static Candidat operator +(Candidat c, double punctBonus)
        {
            c.mediiExamen.NotaAdmitere += punctBonus;
            return c;
        }

        public static bool operator >(Candidat c1, Candidat c2)
        {
            return c1.MedieCalculata > c2.MedieCalculata;
        }

        public static bool operator <(Candidat c1, Candidat c2)
        {
            return c1.MedieCalculata < c2.MedieCalculata;
        }

        public string Export()
        {
            return $"{Nume}|{Prenume}|{Sex}|{CNP}|{DataNasterii:yyyy-MM-dd}|{Domiciliu}|" +
             $"{MediiExamen.MedieBac}|{MediiExamen.NotaAdmitere}|" +
             $"{MediiExamen.PondereBac}|{MediiExamen.PondereAdmitere}|" +
             $"{FacultateAleasa}";
        }


    }
}
