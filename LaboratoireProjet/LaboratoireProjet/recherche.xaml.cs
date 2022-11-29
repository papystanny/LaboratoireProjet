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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace LaboratoireProjet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class recherche : Page
    {
        public recherche()
        {
            this.InitializeComponent();
        }

        private void autoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            List<string> suggestions = new List<string>();

            foreach (var texte in Gestion.)
            {
                if (texte.Contains(autoSuggestBox.Text))
                    suggestions.Add(texte);
            }

            if (suggestions.Count == 0)
                suggestions.Add("Aucun résultat");

            autoSuggestBox.ItemsSource = suggestions;
        }

        private void autoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //on traite le texte entré dans la autoSuggestBox
        }


    }
}
