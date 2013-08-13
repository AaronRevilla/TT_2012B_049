using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GraphicNotes.Core;


using DevExpress.Xpf.Core;
using System.Collections.ObjectModel;
using GraphicNotes.Core.RibbonBarCommands;
using System.Collections.Specialized;


namespace GraphicNotes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {

        private ObservableCollection<Document> documents;
        private NewDocumentCommand newDocumentCommand;
        

        public MainWindow()
        {
            InitializeComponent();
            SetLanguageDictionary();  
            ThemeManager.ThemeChanged += OnApplicationThemeChanged;
            ThemeManager.ApplicationThemeName = "Office2013";
            documents = new ObservableCollection<Document>();
            documents.CollectionChanged+= OnDocumentsCollectionChanged;


            newDocumentCommand = new NewDocumentCommand(documents);
            bNew.Command = newDocumentCommand;
        }

       
        private void OnDocumentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e){
            
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Document d in e.NewItems)
                    {
                        documentGroup1.Items.Add(d.DocumentPanel);
                        this.dockManager1.DockController.Activate(d.DocumentPanel);
                    }
                    break;
            }

            Console.WriteLine(documents.Count);
        }
        

        private void bNew_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
        }

        private void groupFile_CaptionButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("This is File Open dialog", "File Open Dialog");
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        ~MainWindow()
        {
            Dispose(false);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Windows loaded");
        }
    }
}
