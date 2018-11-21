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
    /// Interaction logic for SearchPage1.xaml
    /// </summary>
    public partial class SearchPage1 : Page
    {
        public SearchPage1()
        {
            InitializeComponent();
        
			// Creating the list of categories
			var categories = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {
					new BoxView(){HeightRequest=40, WidthRequest=40, BackgroundColor = Color.White},
					new BoxView(){HeightRequest=40, WidthRequest=40, BackgroundColor = Color.Red},
					new BoxView(){HeightRequest=40, WidthRequest=40, BackgroundColor = Color.Blue},
					new BoxView(){HeightRequest=40, WidthRequest=40, BackgroundColor = Color.Green}
				}
			};

			Content = new ScrollView() {
			HorizontalOptions = LayoutOptions.FillAndExpand,
			Orientation = ScrollOrientation.Horizontal,
			Content = categories,
			};
		}


    }
}
