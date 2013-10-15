using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GraphicNotes.Views.Objects
{
    class TableObject:BaseObject
    {
        Grid gridTable;

        static TableObject()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TableObject), new FrameworkPropertyMetadata(typeof(TableObject)));
            
        }

        public TableObject()
        {
            this.Loaded += new RoutedEventHandler(this.TableObject_Loaded);
        }

        private void TableObject_Loaded(object sender, RoutedEventArgs e)
        {
            if(gridTable==null)
                gridTable=this.Template.FindName("PART_Grid", this) as Grid;
        }

        public IEnumerable<TableCell> SelectedElements
        {
            get
            {
                var selectedElements = from element in gridTable.Children.OfType<TableCell>()
                                       where element.IsSelected == true
                                       select element;

                return selectedElements;
            }
        }
    }
}
