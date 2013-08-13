using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Docking;
using System.Windows;


namespace GraphicNotes.Core
{
    class Document
    {
        private DocumentPanel documentPanel;
        public DocumentPanel DocumentPanel{
         get{ return documentPanel; }
         set{ documentPanel=value;  }
        }

        public String Name
        {
            get;
            set;
        }

        public Document(String name)
        {
            this.Name = name;
            documentPanel = new DocumentPanel();
            documentPanel.DataContext = this;
            documentPanel.Caption = Name;
            DocumentPanel.SetResourceReference(DocumentPanel.StyleProperty, "DocumentPanelStyle");
        }
    }
}
