namespace SalesSystem.Dsi.Services
{
    public class CsvExportService
    {
        readonly IJSRuntime _JsRuntime;

        public CsvExportService(IJSRuntime jsRuntime)
        {
            _JsRuntime = jsRuntime;
        }
        async Task DownloadFileAsync(string content, string fileName, string mimeType)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            string base64String = Convert.ToBase64String(bytes);
            
            await _JsRuntime.InvokeVoidAsync("downloadFileFromBase64", base64String, fileName, mimeType);
        }
    }
}