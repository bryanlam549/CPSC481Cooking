using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for ProfilePreferencesPage.xaml
    /// </summary>
    public partial class ProfilePreferencesPage : Page
    {
        public ProfilePreferencesPage(string pref1, string pref2)
        {
            InitializeComponent();
            string tempPref = pref1;
            string weightPref = pref2;

            if (tempPref.Equals("1"))
            {
                _Cel.IsChecked = true;
            }
            else if (tempPref.Equals("2"))
            {
                _Fah.IsChecked = true;
            }
            else
            {
                _Cel.IsChecked = false;
                _Fah.IsChecked = false;
            }

            if (weightPref.Equals("1"))
            {
                _Oun.IsChecked = true;
            }
            else if (weightPref.Equals("2"))
            {
                _Gram.IsChecked = true;
            }
            else
            {
                _Oun.IsChecked = false;
                _Gram.IsChecked = false;
            }
        }
    }
}
