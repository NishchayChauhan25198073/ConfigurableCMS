using CMS.Foundation.Infrastructure.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CMS.Foundation.Infrastructure.Types
{
    public class PageItem : ContentItem
    {
        public PageItem() : base() { }
        public PageItem(string className) : base(className)
        {

        }

        [JsonIgnore]
        public string Components
        {
            get
            {
                return this.GetSharedField<string>("components");
            }
            set
            {
                SetSharedField("components", value.ToString());
            }
        }


        [JsonIgnore]
        public List<ComponentDetail> ComponentsList
        {
            get
            {
                if (!string.IsNullOrEmpty(Components))
                {
                    return JsonSerializer.Deserialize<List<ComponentDetail>>(Components);
                }
                return new List<ComponentDetail>();
            }
            set
            {
                Components = JsonSerializer.Serialize(value);
            }
        }


    }
}
