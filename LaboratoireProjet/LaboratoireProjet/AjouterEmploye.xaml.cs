using System;
using System.Collections.Generic;
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
using static System.Collections.Specialized.BitVector32;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace LaboratoireProjet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AjouterEmploye : Page
    {
        Boolean validite = true;
        public AjouterEmploye()
        {

            this.InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (nom.Text == null || nom.Text == "")
            {
                erreurNom.Visibility = Visibility.Visible;
                validite = false;
            }
            else
            {
                erreurNom.Visibility = Visibility.Collapsed;
            }


            if (prenom.Text == null || prenom.Text == "")
            {
                erreurPrenom.Visibility = Visibility.Visible;
                validite = false;
            }
            else
            {
                erreurPrenom.Visibility = Visibility.Collapsed;
            }

            if (matricule.Text == null || matricule.Text == "")
            {
                erreurMatricule.Visibility = Visibility.Visible;
                validite = false;
            }
            else
            {
                erreurMatricule.Visibility = Visibility.Collapsed;
            }



            if (validite)
            {
                Employe c = new Employe()
                {
                    Nom = nom.Text,
                    Prenom = prenom.Text,
                    Matricule = matricule.Text
                };
                Gestion.getInstance().insererEmploye(c);
                
            }
        }
    }
}
