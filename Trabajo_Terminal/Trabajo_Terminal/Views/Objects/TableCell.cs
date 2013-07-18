using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GraphicNotes.Views.Objects
{
    class TableCell:TextEdit
    {
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected", typeof(bool),
                                      typeof(TableCell),
                                      new FrameworkPropertyMetadata(false));
    }
}
