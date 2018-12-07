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


            if (GlobalData.Instance.test == 0 && GlobalData.Instance.newAcc == false)
            {
                if (tempPref.Equals("1"))
                {
                    _Cel.IsChecked = true;
                    GlobalData.Instance.preference1 = "1";
                }
                else if (tempPref.Equals("2"))
                {
                    _Fah.IsChecked = true;
                    GlobalData.Instance.preference1 = "2";
                }



                if (weightPref.Equals("1"))
                {
                    _Oun.IsChecked = true;
                    GlobalData.Instance.preference2 = "1";
                }
                else if (weightPref.Equals("2"))
                {
                    _Gram.IsChecked = true;
                    GlobalData.Instance.preference2 = "2";
                }

                GlobalData.Instance.test = 1;
                
            }
            else if (GlobalData.Instance.newAcc == true && GlobalData.Instance.test2 == 0)
            {
                _Cel.IsChecked = false;
                _Fah.IsChecked = false;

                _Oun.IsChecked = false;
                _Gram.IsChecked = false;

                GlobalData.Instance.test2 = 1;

            }
            else
            {
                
                if (GlobalData.Instance.preference1.Equals("1"))
                {
                    _Cel.IsChecked = true;
                    GlobalData.Instance.preference1 = "1";
                }
                else
                {
                    _Fah.IsChecked = true;
                    GlobalData.Instance.preference1 = "2";
                }
                
                if (GlobalData.Instance.preference2.Equals("1"))
                {
                    _Oun.IsChecked = true;
                    GlobalData.Instance.preference2 = "1";
                }
                else
                {
                    _Gram.IsChecked = true;
                    GlobalData.Instance.preference2 = "2";
                }
                
            }

            
        }

        private void _Cel_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.preference1 = "1";
        }

        private void _Fah_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.preference1 = "2";
        }

        private void _Oun_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.preference2 = "1";
        }

        private void _Gram_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.preference2 = "2";
        }
    }
}
