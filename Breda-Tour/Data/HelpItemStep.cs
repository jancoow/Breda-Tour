using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{
    public class HelpItemStep
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageSource { get; private set; }

        public HelpItemStep(string Title, string Description, string ImageSource)
        {
            this.Title = Title;
            this.Description = Description;
            this.ImageSource = "ms-appx:///Storage/helpimages/"+ImageSource;
        }

    }
}
