using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApplication1.ServiceReference1;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateListViews();
        }

        public void PopulateListViews()
        {
            var service = new ServiceClient();
            EDFEntity edf = service.GetData();
            //TreeView0.ItemsSource = edf.EDF;
            MenuItem root = new MenuItem() { Title = "EDF" };
            foreach (var sharePointEntity in edf.EDF)
            {
                MenuItem sharePointNode = new MenuItem() { Title = "SharePoint" };
                foreach (var webApplicationEntity in sharePointEntity.SharePoint)
                {
                    MenuItem webApplicationNode = new MenuItem() { Title = "webApplication" };
                    foreach (var siteCollectionEntity in webApplicationEntity.WebApplication)
                    {
                        MenuItem siteCollectionNode = new MenuItem() { Title = "siteCollection" };
                        foreach (var site in siteCollectionEntity.SitesCollection)
                        {
                            MenuItem siteNode = new MenuItem() { Title = "site" };
                            

                            siteNode.Items.Add(new MenuItem() { Title = "NomAdmin : \t \t" + site.NomAdmin});
                            siteNode.Items.Add(new MenuItem() { Title = "LoginAdmin : \t \t" + site.LoginAdmin });
                            siteNode.Items.Add(new MenuItem() { Title = "Langue : \t \t \t" + site.Langue });
                            siteNode.Items.Add(new MenuItem() { Title = "Url : \t \t \t" + site.Url});
                            siteNode.Items.Add(new MenuItem() { Title = "Modele : \t \t" + site.Modele});
                            siteNode.Items.Add(new MenuItem() { Title = "Charte : \t \t \t" + site.Charte});
                            siteNode.Items.Add(new MenuItem() { Title = "NomProprietaire : \t" + site.NomProprietaire});
                            siteNode.Items.Add(new MenuItem() { Title = "LoginProprietaire : \t" + site.LoginProprietaire});
                            siteNode.Items.Add(new MenuItem() { Title = "NomEspace : \t \t" + site.NomEspace});
                            siteNode.Items.Add(new MenuItem() { Title = "DescriptionEspace : \t" + site.DescriptionEspace});
                            siteNode.Items.Add(new MenuItem() { Title = "CodeUM : \t \t" + site.CodeUM});
                            siteNode.Items.Add(new MenuItem() { Title = "OffreService : \t \t" + site.OffreService});
                            siteNode.Items.Add(new MenuItem() { Title = "TypeAcces : \t \t" + site.TypeAcces});
                            siteNode.Items.Add(new MenuItem() { Title = "NiveauAudience : \t \t" + site.NiveauAudience});
                            siteNode.Items.Add(new MenuItem() { Title = "Direction : \t \t" + site.Direction});
                            siteNode.Items.Add(new MenuItem() { Title = "Date : \t \t \t" + site.Date});
                            siteNode.Items.Add(new MenuItem() { Title = "VersionModele : \t \t" + site.VersionModele });
                            siteNode.Items.Add(new MenuItem() { Title = "GuidSite : \t \t" + site.ID });
                            siteNode.Items.Add(new MenuItem() { Title = "Ferme : \t \t \t" + site.Ferme });

                            siteCollectionNode.Items.Add(siteNode);
                        }
                        webApplicationNode.Items.Add(siteCollectionNode);
                    }
                    sharePointNode.Items.Add(webApplicationNode);
                }
                root.Items.Add(sharePointNode);
            }
            TreeView0.Items.Add(root);

        }
    }

    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }
}
