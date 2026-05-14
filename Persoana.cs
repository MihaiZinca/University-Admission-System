using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Admitere_Facultate
{
    [Serializable]
    public abstract class Persoana
    {

        private string nume;
        private string prenume;
        private string sex;
        private string cnp;
        private DateTime dataNasterii;
        private string domiciliu;

        public abstract string ObtineStatusAdmitere();

        public Persoana()
        {

        }

        public Persoana(string nume, string prenume, string sex, string cnp, DateTime dataNasterii, string domiciliu)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.sex = sex;
            this.cnp = cnp;
            this.dataNasterii = dataNasterii;
            this.domiciliu = domiciliu;
        }

        public string Nume
        {
            get { return nume; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Numele nu poate fi gol!");
                nume = value;
            }
        }

        public string Prenume
        {
            get { return prenume; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Prenumele nu poate fi gol!");
                prenume = value;
            }
        }

        public string CNP
        {
            get { return cnp; }
            set
            {
                if (value.Length != 13)
                    throw new Exception("CNP invalid!");
                cnp = value;
            }
        }

        public DateTime DataNasterii
        {
            get { return dataNasterii; }
            set
            {

                if (value > DateTime.Now)
                    throw new Exception("Data invalida!");
                dataNasterii = value;
            }
        }

        public string Domiciliu
        {
            get { return domiciliu; }
            set { domiciliu = value; }
        }

        public string Sex
        {
            get { return sex; }
            set
            {
                if (value != "M" && value != "F")
                    throw new Exception("Sex invalid (M/F)!");
                sex = value;
            }
        }

        public int CalculVarsta()
        {
            return DateTime.Now.Year - dataNasterii.Year;
        }


        public override string ToString()
        {
            return $"{nume}|{prenume}|{sex}|{cnp}|{dataNasterii}|{domiciliu}";
        }
    }
}
