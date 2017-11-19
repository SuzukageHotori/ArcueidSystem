using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcueidSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpServer http = new HttpServer(new Server(8081));
            http.Handlers.Add(new SubstitutingFileReader());
            http.Handlers.Add(new RESTfulApiHandlerBase(HMethod.POST, "/api/hello", new List<string>() {"index","userid" }, new HelloHander()));
            this.IsEnabled = false;
        }
        public class HelloHander : IRESTfulHandler
        {

            public bool Process(HttpServer server, HttpRequest request, HttpResponse response, Dictionary<string, string> param)
            {
                
                response.Content = " "+param["index"];
                return true;
            }
        }

    }
}
