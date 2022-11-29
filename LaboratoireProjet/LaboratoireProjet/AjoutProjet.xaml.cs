using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace LaboratoireProjet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
        }

        private void reset()
        {
            ErrNum.Visibility = Visibility.Collapsed;
            ErrBudget.Visibility = Visibility.Collapsed;
            ErrDate.Visibility = Visibility.Collapsed;
            ErrDesciption.Visibility = Visibility.Collapsed;
            ErrEmp.Visibility = Visibility.Collapsed;
        }
        
        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            reset();

            if (numProjet.Text.Trim() == "")
            {
                ErrNum.Visibility = Visibility.Visible;
                valide = false;
            }
            if (budget.Text.Trim() == "")
            {
                ErrBudget.Visibility = Visibility.Visible;
                valide = false;
            }
            else if (Convert.ToInt32(budget.Text) < 10000 || Convert.ToInt32(budget.Text) > 100000)
            {
                ErrBudget.Text = "Le coût du projet doit être compris entre 10 000$ et 100 000$";
                ErrBudget.Visibility = Visibility.Visible;
                valide = false;
            }
            if (dateDébut.Text.Trim() == "")
            {
                ErrDate.Visibility = Visibility.Visible;
                valide = false;
            }
            if (description.Text.Trim() == "")
            {
                ErrDesciption.Visibility = Visibility.Visible;
                valide = false;
            }
            if (ChoixEmp.Text.Trim() == "")
            {
                ErrEmp.Visibility = Visibility.Visible;
                valide = false;
            }
            if (matricule.Text.Trim() == "")
            {
                ErrMatricule.Visibility = Visibility.Visible;
                valide = false;
            }

            if (valide)
            {
                Projet p = new Projet()
                {
                    NumProjet = numProjet.Text,
                    DateDebut = dateDébut.Text,
                    Budget = Convert.ToInt32(budget.Text),
                    Description = description.Text,
                    MatriculeEmp = matricule.Text
                };

                Gestion.getInstance().insererProjet(p);
                mainFrame.Navigate(typeof(Liste));
            }
        }

        private void ChoixEmp_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ChoixEmp.ItemsSource = Gestion.getInstance().choixEmp(ChoixEmp.Text);
        }
    }
}
