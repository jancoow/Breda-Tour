using System.Collections.Generic;

namespace Breda_Tour.Data
{
    public class HelpItem
    {
        public string Title { get; private set; }
        public string Language { get; private set; }
        public List<HelpItemStep> HelpItemSteps { get; private set; }

        public HelpItem(string Language, string Title, List<HelpItemStep> Steps)
        {
            this.Language = Language;
            this.Title = Title;
            this.HelpItemSteps = Steps;
        }
    }
}
