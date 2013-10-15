using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphicNotes.Views.Objects;
using GraphicNotes.Views.Workspace;
using System.Threading;
using DevExpress.Xpf.Docking;
using GraphicNotes.Core;


using DevExpress.Xpf.Bars;
using DevExpress.Utils;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;

namespace GraphicNotes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetLanguageDictionary();
            ThemeManager.ThemeChanged += OnApplicationThemeChanged;
        }

        void OnApplicationThemeChanged(DependencyObject sender, ThemeChangedRoutedEventArgs e)
        {
            SelectCurrentThemeItem();
            UpdateApplicationButtonLargeIcon(e.ThemeName);
        }

        void SelectCurrentThemeItem()
        {
            string themeName = ThemeManager.ApplicationThemeName;
            foreach (GalleryItemGroup group in gTheme.Gallery.Groups)
            {
                foreach (GalleryItem item in group.Items)
                {
                    if (Convert.ToString(item.Caption).Replace(" ", "") == themeName)
                    {
                        gTheme.Gallery.ItemClick -= OnThemeItemClick;
                        item.IsChecked = true;
                        gTheme.Gallery.ItemClick += new GalleryItemEventHandler(OnThemeItemClick);
                        return;
                    }
                }
            }
        }

        void UpdateApplicationButtonLargeIcon(string themeName)
        {
            if (ribbonControl == null || string.IsNullOrEmpty(themeName)) return;
            if (themeName == Theme.MetropolisDarkName || themeName == Theme.MetropolisLightName || themeName == Theme.Office2013Name)
            {
                ribbonControl.ApplicationButtonLargeIcon = null;
                ribbonControl.RibbonStyle = RibbonStyle.Office2010;
            }
            else
            {
                ribbonControl.ApplicationButtonLargeIcon = new BitmapImage(new Uri(@"/GraphicNotes;component/Images/ribbon-application-32x32.png", UriKind.Relative));
                ribbonControl.RibbonStyle = RibbonStyle.Office2007;
            }
        }

        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "es-MX":
                    dict.Source = new Uri("..\\Languages\\StringResources.xaml", UriKind.Relative);
                    break;
                case "en-GB":
                    dict.Source = new Uri("..\\Languages\\StringResources.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Languages\\StringResources.xaml", UriKind.Relative);
                    break;
            }
            //this.Resources.MergedDictionaries.Add(dict);
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        protected virtual void OnThemeDropDownGalleryInit(object sender, DropDownGalleryEventArgs e)
        {
            Gallery gallery = e.DropDownGallery.Gallery;
            gallery.AllowHoverImages = false;
            gallery.IsItemCaptionVisible = true;
            gallery.ItemGlyphLocation = Dock.Top;
            gallery.IsGroupCaptionVisible = DefaultBoolean.True;
        }
        protected virtual void OnThemeItemClick(object sender, GalleryItemEventArgs e)
        {
            string themeName = (string)e.Item.Caption;
            themeName = themeName.Replace(" ", string.Empty);
            //Theme = Theme.FindTheme(themeName); 
            ThemeManager.ApplicationThemeName = themeName;
        }

        //private void button1_Click_1(object sender, RoutedEventArgs e)
        //{
        //    BaseObject ob = new BaseObject();
        //    Image content = new Image();
        //    BitmapImage bi = new BitmapImage(new Uri("./Icons/delete_object.png", UriKind.Relative));
        //    content.Source = bi;
        //    content.Stretch = Stretch.None;

        //    ob.Content = content;

        //    CanvasWorkspace.SetLeft(ob, 10);
        //    CanvasWorkspace.SetTop(ob, 10);
        //    canvasWorkspace1.Children.Add(ob);
        //    ob.IsSelected = true;
        //    Console.WriteLine("DataContext:" + ob.DataContext);
        //}

        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            SetLanguageDictionary();
        }

        private void btnFrench_Click(object sender, RoutedEventArgs e)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("es-MX");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            SetLanguageDictionary();
        }

        private void bNew_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DocumentContainer dc = new DocumentContainer();
            documentGroup1.Items.Add(dc.DocumentPanel);
            this.dockManager1.DockController.Activate(dc.DocumentPanel);
        }

        private void groupFile_CaptionButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("This is File Open dialog", "File Open Dialog");
        }
    }
}
