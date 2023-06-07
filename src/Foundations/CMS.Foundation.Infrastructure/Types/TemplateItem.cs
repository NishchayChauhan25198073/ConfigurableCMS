using CMS.Foundation.Infrastructure.Managers;
using System.Text.Json.Serialization;

namespace CMS.Foundation.Infrastructure.Types
{
    public class TemplateItem : ContentItem
    {
        public TemplateItem() : base() { }
        public TemplateItem(string className) : base(className)
        {

        }

        [JsonIgnore]
        public string ParentPages
        {
            get
            {
                return this.GetSharedField<string>("parentpages");
            }
            set
            {
                SetSharedField("parentpages", value.ToString());
            }
        }

        [JsonIgnore]
        public List<SectionItem> sectionItems { get; set; }

        [JsonIgnore]
        public string SectionsIds
        {
            get
            {
                return GetSharedField<string>("sections");
            }
            set
            {
                SetSharedField("sections", value.ToString());
            }
        }


        [JsonIgnore]
        public List<string> ParentPagesList
        {
            get
            {
                if (!string.IsNullOrEmpty(ParentPages))
                {
                    return FieldUtility.GetIdsList(ParentPages);
                }
                return new List<string>();
            }
            set
            {
                ParentPages = FieldUtility.GetIdsString(value);
            }
        }
    }
}
