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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaboratoireProjet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<string> liste = new List<string>();
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void nvSample_SelectionChanged(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;
            header.Text = item.Content.ToString();              // Code pour alle attraper le header indiqué lorsqu'on clique sue un item du Navigattion 

            switch (item.Name)
            {
                case "ajoutEmploye":
                    mainFrame.Navigate(typeof(AjouterEmploye));
                    break;

                case "ajoutProjet":
                    mainFrame.Navigate(typeof(AjoutProjet));
                    break;

                case "affichageProjet":
                    mainFrame.Navigate(typeof(Liste));
                    break;

                case "recherche":
                    mainFrame.Navigate(typeof(recherche));
                    break;


                default:
                    break;


            }
        }    
    }
}

