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
			var categories = new StackPanel()
			{
				Orientation = Orientation.Horizontal,
				//HorizontalOptions = LayoutOptions.Fill,
				Children = {
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw1"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw2"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw1"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw2"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw1"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw2"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw1"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw2"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw1"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw2"},
					new TextBlock(){MaxHeight=80, MinWidth=80, Text = "Yehaw3"},
				}
			};

			//CategoryBar.SetValue();

			scroll1.Content = categories;
			
		}
		
	}
}
