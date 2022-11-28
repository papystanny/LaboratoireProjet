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
        //string desc;
        //description.Document.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out desc);
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
            if (dateDébut.Text.Trim() == "")
            {
                ErrDate.Visibility = Visibility.Visible;
                valide = false;
            }
            if (description == null)
            {
                ErrDesciption.Visibility = Visibility.Visible;
                valide = false;
            }
            if (emp.Text.Trim() == "")
            {
                ErrEmp.Visibility = Visibility.Visible;
                valide = false;
            }

            if (valide)
            { 
                
            }
        }
    }
}
