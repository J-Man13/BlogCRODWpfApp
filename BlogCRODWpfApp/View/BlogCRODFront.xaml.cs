using BlogCRODWpfApp.ViewModels;
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
using System.Windows.Shapes;

namespace BlogCRODWpfApp.View
{
    /// <summary>
    /// Interaction logic for BlogCRODFront.xaml
    /// </summary>
    public partial class BlogCRODFront : Window
    {
        BlogCRODFrontViewModel blogCRODFrontViewModel;

        public BlogCRODFront()
        {
            InitializeComponent();
            blogCRODFrontViewModel = new BlogCRODFrontViewModel();
            DataContext = blogCRODFrontViewModel.BlogCRODFrontDataContext;
        }


    }
}
