using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Admitere_Facultate
{
    [Serializable]
    public class Facultate
    {
        private string denumire;
        private int nrLocuri;
        private List<Candidat> candidati;

        public string Denumire
        {
            get { return denumire; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Nume invalid!");
                denumire = value;
            }
        }

        public int NrLocuri
        {
            get { return nrLocuri; }
            set
            {
                if (value <= 0)
                    throw new Exception("Nr locuri invalid!");
                nrLocuri = value;
            }
        }

        public List<Candidat> Candidati
        {
            get { return candidati; }
            set { candidati = value; }
        }

        public Facultate()
        {
            candidati = new List<Candidat>();
        }

        public Facultate(string denumire, int nrLocuri)
        {
            this.denumire = denumire;
            this.nrLocuri = nrLocuri;
            this.candidati = new List<Candidat>();
        }

        public void AdaugaCandidat(Candidat c)
        {
            candidati.Add(c);
        }

        public void StergeCandidat(Candidat c)
        {
            candidati.Remove(c);
        }

        public void AfisareCandidati()
        {
            foreach (Candidat c in candidati)
            {
                Console.WriteLine(c);
            }
        }

        public List<Candidat> GetAdmisi()
        {
           return candidati
            .OrderByDescending(c => c.MedieCalculata)
            .ThenBy(c => c.Nume)
            .Take(nrLocuri)
             .ToList();
        }

        public double MedieGenerala()
        {
            if (candidati.Count == 0) return 0;
            return candidati.Average(c => c.MedieCalculata);
        }

        public Candidat CautaDupaNume(string nume)
        {
            return candidati.FirstOrDefault(c => c.Nume == nume);
        }
    }
}
