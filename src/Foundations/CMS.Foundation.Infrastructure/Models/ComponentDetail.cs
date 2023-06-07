using CMS.Foundation.Infrastructure.Types;
using System.Text.Json.Serialization;

namespace CMS.Foundation.Infrastructure.Models
{
    public class ComponentDetail
    {
        public string Path { get; set; }
        public string TemplateIds { get; set; }

        public string ComponentName { get; set; }

        [JsonIgnore]
        public List<TemplateItem> TemplateItems { get; set; }
    }
}
