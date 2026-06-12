namespace SalesSystem.Rfq.Extensions
{

    public static class ErrorMarkupFormatter
    {
        public static string FormatForMessageBox(string input)
        {
            StringBuilder sb = new StringBuilder();

            // 1. Strip the header prefix
            string cleanInput = input.Replace("UnprocessableContent: Error Message: ", "", StringComparison.InvariantCultureIgnoreCase);

            // 2. Split items by the double pipe separator
            string[] items = cleanInput.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

            // 3. Group the errors using LINQ
            List<string> blankErrors = items.Where(x => x.Contains("cannot be blank", StringComparison.OrdinalIgnoreCase)).ToList();
            List<string> incorrectValueDetails = items.Where(x => x.Contains("Incorrect Value", StringComparison.OrdinalIgnoreCase)).ToList();

            // 4. Build Critical Errors Section (Explicitly using \r\n for Windows UI compatibility)
            if (blankErrors.Any())
            {
                sb.Append("Unprocessable Content Error:\r\n");
                sb.Append("---------------------------\r\n");
                foreach (string error in blankErrors)
                {
                    sb.Append(CultureInfo.CurrentCulture, $"• {error.Trim()}\r\n");
                }

                sb.Append("\r\n"); // Empty line separator
            }

            // 5. Build Validation Details Section (Removed PadRight as MessageBox ignores tab alignment)
            if (incorrectValueDetails.Any())
            {
                sb.Append("Validation Details:\r\n");
                sb.Append("---------------------------\r\n");

                foreach (string detail in incorrectValueDetails)
                {
                    string[] parts = detail.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        // Simplified clean format for standard proportional UI fonts
                        sb.Append(CultureInfo.CurrentCulture, $"• {key}: {value}\r\n");
                    }
                    else
                    {
                        sb.Append(CultureInfo.CurrentCulture, $"• {detail.Trim()}\r\n");
                    }
                }
            }

            return sb.ToString();
        }
        public static MarkupString ConvertToHtmlMarkup(string input)
        {
            StringBuilder sb = new StringBuilder();

            string cleanInput = input.Replace("UnprocessableContent: Error Message: ", "", StringComparison.InvariantCultureIgnoreCase);
            string[] items = cleanInput.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> blankErrors = items.Where(x => x.Contains("cannot be blank", StringComparison.OrdinalIgnoreCase)).ToList();
            List<string> incorrectValueDetails = items.Where(x => x.Contains("Incorrect Value", StringComparison.OrdinalIgnoreCase)).ToList();

            // Build HTML for Blanks Section
            if (blankErrors.Any())
            {
                sb.Append("<div class='error-title'>Unprocessable Content Error:</div>");
                sb.Append("<div class='error-divider'></div>");
                sb.Append("<ul class='error-list'>");
                foreach (string error in blankErrors)
                {
                    sb.Append(CultureInfo.CurrentCulture, $"<li>{error.Trim()}</li>");
                }

                sb.Append("</ul>");
            }

            // Build HTML for Validation Details Section
            if (incorrectValueDetails.Any())
            {
                sb.Append("<div class='details-title'>Validation Details:</div>");
                sb.Append("<div class='details-divider'></div>");
                sb.Append("<ul class='error-list'>");

                foreach (string detail in incorrectValueDetails)
                {
                    string[] parts = detail.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        sb.Append(CultureInfo.CurrentCulture, $"<li><strong>{parts[0].Trim()}:</strong> {parts[1].Trim()}</li>");
                    }
                    else
                    {
                        sb.Append(CultureInfo.CurrentCulture, $"<li>{detail.Trim()}</li>");
                    }
                }

                sb.Append("</ul>");
            }

            return (MarkupString)sb.ToString();
        }
    }
}
