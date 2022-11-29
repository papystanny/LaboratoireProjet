﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

                commande.Parameters.AddWithValue("@matricule", c.Matricule);
                commande.Parameters.AddWithValue("@nom", c.Nom);
                commande.Parameters.AddWithValue("@prenom", c.Prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }


        // Pouvoir inserer les projets depuis la page projets
        public void insererProjet(Projet c)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into projet values( @numero, @debut, @budget,@description, @employe)";

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
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        // Pouvoir lire les projets depuis la page affichage projet
        public ObservableCollection<Projet> GetProjets()
        {
            listeProject.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT numero, budget, description, debut, employe ,e.nom, e.prenom FROM projet p JOIN employe e ON p.employe =  e.matricule WHERE p.employe = e.matricule;";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            try
            {
                while (r.Read())
                {
                    Projet c = new Projet()
                    {
                        NumProjet = r.GetString("numero"),
                        DateDebut = r.GetString("debut"),
                        Description = r.GetString("description"),
                        MatriculeEmp = r.GetString("employe"),
                        Budget = r.GetInt32("budget"),
                        NomEmploye = r.GetString("prenom"),
                        PrenomEmploye = r.GetString("nom")
                    };
                    listeProject.Add(c);

                }
                r.Close(); 
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return listeProject;
        }

        // Pouvoir Rechercher Employe 
        public ObservableCollection<Employe> GetEmployes()
        {

            listeEmploye.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * FROM employe";
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
                r.Close(); 
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return listeEmploye;

        }

        public ObservableCollection<Employe> choixEmp(string nom)
        { 
            ObservableCollection<Employe> listeChoix = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe where nom like @nom;";

            commande.Parameters.AddWithValue("@nom", "%" + nom + "%");

            con.Open();
            commande.Prepare();
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
                    listeChoix.Add(c);

                }
                r.Close(); 
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return listeChoix;
        }
    }

 }

