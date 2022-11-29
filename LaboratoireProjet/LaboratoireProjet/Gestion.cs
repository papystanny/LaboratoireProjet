using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireProjet
{
    class Gestion
    {
        MySqlConnection con;

        ObservableCollection<Employe> listeEmploye;
        ObservableCollection<Projet> listeProject;
        static Gestion gestion = null;

        // Connection avec la variable con
        public Gestion()
        {
            this.con = new MySqlConnection("Server=localhost;Database=prog_database_clients;Uid=root;Pwd=root;");
            listeEmploye = new ObservableCollection<Employe>();
            listeProject = new ObservableCollection<Projet>();
        }

        //S'assurer de la connection avec la base de donnée
        public static Gestion getInstance()
        {
            if (gestion == null)
                gestion = new Gestion();

            return gestion;

        }

        // Pouvoir inserer les employé depuis la page ajout employe
        public void insererEmploye(Employe c)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values( @matricule, @nom, @prenom) ";

                commande.Parameters.AddWithValue("@categorie", c.Matricule);
                commande.Parameters.AddWithValue("@prix", c.Nom);
                commande.Parameters.AddWithValue("@ville", c.Prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                //message d'erreur
            }
        }


        // Pouvoir inserer les projets depuis la page projets
        public void insererProjet(Projet c)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values( @numero, @debut, @budget,@description, @employe) ";

                commande.Parameters.AddWithValue("@numero", c.NumProjet);
                commande.Parameters.AddWithValue("@debut", c.DateDebut);
                commande.Parameters.AddWithValue("@budget", c.Budget);
                commande.Parameters.AddWithValue("@description", c.Description);
                commande.Parameters.AddWithValue("@employe", c.MatriculeEmp);


                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                //message d'erreur
            }
        }

        // Pouvoir lire les projets depuis la page affichage projet
        public ObservableCollection<Projet> GetProjets()
        {
            listeProject.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select numero, debut, budget, description, nom, prenom  FROM projet p INNER JOIN employe e on p.employe = e.matricule;";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            try
            {
                while (r.Read())
                {
                    Projet c = new Projet()
                    {
                        NumProjet = r.GetString("matricule"),
                        DateDebut = r.GetString("date"),
                        Description = r.GetString("description"),
                        Budget = r.GetDouble("budget"),
                        NomEmploye = r.GetString("prenom"),
                        PrenomEmploye = r.GetString("nom")

                    };
                    listeProject.Add(c);

                }
                r.Close(); con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return listeProject;
        }

        // Pouvoir Rechercher Employe 
        public ObservableCollection<Employe> GetEmployes(String name)
        {

            listeEmploye.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * FROM employe LIKE nom =  " + "name";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            try
            {
                while (r.Read())
                {
                    Employe c = new Employe()
                    {
                        Matricule = r.GetString("matricule"),
                        Nom = r.GetString("nom"),
                        Prenom = r.GetString("prenom")
                    };
                    listeEmploye.Add(c);

                }
                r.Close(); con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return listeEmploye;

        }






    }
}
