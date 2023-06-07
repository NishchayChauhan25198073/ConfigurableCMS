namespace CMS.Foundation.Infrastructure.Managers
{
    public class FieldUtility
    {
        public static List<string> GetIdsList(string idstring)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(idstring))
            {
                return new List<string>();
            }
            ids = idstring.Split('|').ToList();
            return ids;
        }

        public static string GetIdsString(List<string> idsList)
        {
            if (!idsList.Any())
            {
                return string.Empty;
            }
            return string.Join("|", idsList);
        }
    }
}
