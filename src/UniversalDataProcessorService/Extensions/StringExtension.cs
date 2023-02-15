namespace UniversalDataProcessorService.Extensions
{
    public static class StringExtension
    {
        public static string StandardiseColumnTableName(this string name)
        {

            return name.Replace("[", "").Replace("]", "").Replace("|", "_").Replace(";", "_")
                .Replace(",", "_").Replace(" ", "").Replace("#", "_").Replace("-", "_").Replace("%", "_")
                .Replace(".", "_").Trim();
        }
    }
}
