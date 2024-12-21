using System.Text.RegularExpressions;

namespace LibraryTemp;

public static class TemplateUtility
{
    /// <summary>
    /// Constructs a template string by replacing placeholders with values.
    /// </summary>
    /// <param name="template">The template string with placeholders.</param>
    /// <param name="placeholders">A dictionary of placeholder keys and values.</param>
    /// <returns>The formatted string with placeholders replaced.</returns>
    public static string ReplacePlaceholders(string template, Dictionary<string, string> placeholders)
    {
        if (string.IsNullOrEmpty(template) || placeholders == null)
            return template;

        return Regex.Replace(template, @"\{\{\{(\w+)\}\}\}", match =>
        {
            var key = match.Groups[1].Value; // Extract the key inside triple curly braces
            return placeholders.TryGetValue(key, out var value) ? value : match.Value; // Replace if key exists
        });
    }

    /// <summary>
    /// Validates whether all placeholders in a template have corresponding values.
    /// </summary>
    /// <param name="template">The template string with placeholders.</param>
    /// <param name="placeholders">A dictionary of placeholder keys and values.</param>
    /// <returns>True if all placeholders have values; otherwise, false.</returns>
    public static bool ValidatePlaceholders(string template, Dictionary<string, string> placeholders)
    {
        if (string.IsNullOrEmpty(template))
            return false;

        if (placeholders == null)
            return false;

        // Extract all placeholders in the format {{{key}}}
        var matches = Regex.Matches(template, @"\{\{\{(\w+)\}\}\}");
        foreach (Match match in matches)
        {
            var key = match.Groups[1].Value; // Extract the placeholder key
            if (!placeholders.ContainsKey(key)) // Check if the key exists in the dictionary
                return false;
        }

        return true; // All placeholders are valid
    }
}