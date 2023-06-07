using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Foundation.Infrastructure.Types
{
    public class ContentItem : BaseItem
    {
        public ContentItem():base()
        {
                
        }
        public ContentItem(string className) : base(className)
        {

        }

        public bool IsShared
        {
            get
            {
                return this.GetSharedField<bool>("isshared");
            }
        }
    }
}
