using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CMS.Foundation.Infrastructure.Types
{
    [DataContract]
    public class BaseItem
    {
        public BaseItem()
        {

        }
        public BaseItem(string classname)
        {
            Id = Guid.NewGuid().ToString();
            PIMId = this.Id;
            ClassName = classname;
        }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string ClassName { get; set; }

        [DataMember(Order = 3)]
        public string Id { get; set; }

        [DataMember(Order = 4)]
        public string PIMId { get; set; }

        [DataMember(Order = 5)]
        public string DisplayTitle { get; set; }

        [DataMember(Order = 6)]
        public string DisplayName { get; set; }

        [DataMember(Order = 7)]
        public Dictionary<string, string> LanguageFields { get; set; }

        [DataMember(Order = 8)]
        public Dictionary<string, string> SharedFields { get; set; }

        [JsonIgnore]
        public TemplateItem TemplateItem { get; set; }

        #region Fields Fetch Operations

        public T GetSharedField<T>(string fieldName) where T : IConvertible
        {
            string fieldValue = string.Empty;
            if (string.IsNullOrEmpty(fieldName))
            {
                return default(T);
            }
            var cleanFieldName = fieldName.ToLower();
            if (this.SharedFields.TryGetValue(cleanFieldName, out fieldValue))
            {
                return (T)Convert.ChangeType(fieldValue, typeof(T));
            }
            return default(T);
        }

        public string GetLanguageField(string fieldName, string culture = "en")
        {
            var fieldValue = string.Empty;
            if (string.IsNullOrEmpty(fieldName))
            {
                return string.Empty;
            }
            var fieldKey = $"{fieldName.ToLower()}_{culture}";
            if (this.LanguageFields.TryGetValue(fieldKey, out fieldValue))
            {
                return fieldValue;
            }
            return fieldValue;
        }

        #endregion

        #region Field Set Operations

        public void SetLanguageField(string fieldName, string fieldValue, string culture = "en")
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return;
            }

            var fieldKey = $"{fieldName.ToLower()}_{culture}";
            if (this.LanguageFields.ContainsKey(fieldKey))
            {
                this.LanguageFields.Remove(fieldKey);
            }
            this.LanguageFields.Add(fieldKey, fieldValue);
        }

        public void SetSharedField(string fieldName, string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return;
            }

            var cleanFieldName = $"{fieldName}";
            if (this.SharedFields.ContainsKey(cleanFieldName))
            {
                this.SharedFields.Remove(cleanFieldName);
            }
            this.SharedFields.Add(cleanFieldName, fieldValue);
        }

        #endregion

        #region Remove Fields Operations

        public void RemoveSharedField(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return;
            }

            var cleanFieldName = fieldName.ToLower();
            if (this.SharedFields.ContainsKey(cleanFieldName))
            {
                this.SharedFields.Remove(cleanFieldName);
                return;
            }
            return;
        }
        public void RemoveLanguageField(string fieldName, string culture = "en")
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return;
            }

            var fieldKey = $"{fieldName.ToLower()}_{culture}";
            if (this.LanguageFields.ContainsKey(fieldKey))
            {
                this.LanguageFields.Remove(fieldKey);
                return;
            }
            return;
        }

        public void RemoveField(string fieldName, string culture = "en")
        {
            if (this.TemplateItem == null)
            {
                return;
            }
            if (this.TemplateItem.IsShared)
            {
                this.RemoveSharedField(fieldName);
            }
            else
            {
                this.RemoveLanguageField(fieldName);
            }
        }



        #endregion

        #region Field availability check

        public bool HasSharedField(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return false;
            }
            string cleanFieldName = fieldName.ToLower();
            if (this.SharedFields.ContainsKey(cleanFieldName))
            {
                return true;
            }
            return false;
        }

        public bool HasLanguageField(string fieldName, string culture = "en")
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return false;
            }
            string fieldKey = $"{fieldName}_{culture}";
            if (this.LanguageFields.ContainsKey(fieldKey))
            {
                return true;
            }
            return false;
        }

        public bool HasField(string fieldName, string culture = "en")
        {
            if (this.TemplateItem == null)
            {
                return false;
            }
            if (this.TemplateItem.IsShared)
            {
                return HasSharedField(fieldName);
            }
            else
            {
                return HasLanguageField(fieldName, culture);
            }
        }

        #endregion

    }
}
