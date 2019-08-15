using System;
using TWG.CustomCell;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TWG.DataTemplateSelector
{
    public class GridDataTemplateSelector: Xamarin.Forms.DataTemplateSelector
    {

        private readonly DataTemplate GriddataTemplate;

        public GridDataTemplateSelector()
        {
            GriddataTemplate= new DataTemplate(typeof(CustViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return GriddataTemplate;
        }
    }
}
