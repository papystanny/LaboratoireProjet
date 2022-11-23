using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireProjet
{
    internal class Projet
    {
        int numProjet;
        string dateDebut;
        int budget;
        string description;
        string matriculeEmp;

        public int NumProjet { get => numProjet; set => numProjet = value; }
        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public int MatriculeEmp { get => matriculeEmp; set => matriculeEmp = value; }

        public override string ToString()
        {
            return numProjet + " " + budget + "" + description + "" + budget;
        }
    }
}
