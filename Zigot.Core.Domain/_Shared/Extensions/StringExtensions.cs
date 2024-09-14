namespace Zigot.Core.Domain._Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedText = System.Text.RegularExpressions.Regex.Replace(text, @"[\s_]+", " ");
            var parts = normalizedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var pascalCase = string.Join(string.Empty, parts.Select(part =>
                char.ToUpper(part[0]) + part.Substring(1).ToLower()));

            return pascalCase;
        }
    }
}
