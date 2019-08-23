using System;
using System.Collections.Generic;
using System.Linq;
using TWG.CellModel;
using TWG.CustomCell;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TWG.DataTemplateSelector
{
    public class GridDataTemplateSelector: Xamarin.Forms.DataTemplateSelector
    {

        private readonly DataTemplate GridCellLight;
        private readonly DataTemplate GridCellDark;
        private int i = 0;
        public GridDataTemplateSelector()
        {
            GridCellLight = new DataTemplate(typeof(CustViewCell));
            GridCellDark = new DataTemplate(typeof(CustCellDark));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

            var list = (IList<CellDeginsModel>)((ListView)container).ItemsSource;
            var index = list.ToList();
           return index.IndexOf(item as CellDeginsModel) % 2 == 0 ? GridCellLight : GridCellDark;
            //  var index = list.In
            //return null;//(((ListView)container).ItemsSource).IndexOf(item as CellDeginsModel ) % 2 == 0 ? GridCellLight : GridCellDark;
            // i++;
            //if (i % 2 == 0)
            //{
            //    //Even number
            //    return GridCellLight;
            //}
            //else
            //{
            //    return GridCellDark;
            //    //odd number
            //}
                
        }
    }
}
