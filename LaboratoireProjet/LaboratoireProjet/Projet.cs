using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireProjet
{
    internal class Projet
    {
        string numProjet;
        string dateDebut;
        int budget;
        string description;
        string matriculeEmp;
        string nomEmploye;
        string prenomEmploye;

        public string NumProjet { get => numProjet; set => numProjet = value; }
        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string MatriculeEmp { get => matriculeEmp; set => matriculeEmp = value; }
        public string NomEmploye { get => nomEmploye; set => nomEmploye = value; }
        public string PrenomEmploye { get => prenomEmploye; set => prenomEmploye = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public override string ToString()
        {
            return numProjet + " " + budget + "" + description + "" + budget;
        }
    }
}