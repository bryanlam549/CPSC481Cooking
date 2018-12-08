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
        public int i;

        public ProfilePreferencesPage(string username)
        {
            InitializeComponent();

            this.i = GlobalData.Instance.accountList.IndexOf(username);
            string x = GlobalData.Instance.accountList[i + 3];
            string y = GlobalData.Instance.accountList[i + 4];

            if (x.Equals("1"))
            {
                _Cel.IsChecked = true;
            }
            else if (x.Equals("2"))
            {
                _Fah.IsChecked = true;
            }

            if (y.Equals("1"))
            {
                _Oun.IsChecked = true;
            }
            else if (y.Equals("2"))
            {
                _Gram.IsChecked = true;
            }

        }

        private void _Cel_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.accountList[i + 3] = "1";
        }

        private void _Fah_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.accountList[i + 3] = "2";
        }

        private void _Oun_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.accountList[i + 4] = "1";
        }

        private void _Gram_Checked(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.accountList[i + 4] = "2";
        }
    }
}
