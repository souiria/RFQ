using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Api.Exceptions;
using Common.UX.Logging;
using Newtonsoft.Json;

namespace Common.UX.Api.Commercial
{
    public class ServiceApi
    {
        private readonly string _serviceEndpoint;
        public readonly HttpClient HttpClient;

        public ServiceApi(HttpClient client, string clusterEndpointAddress, string clusterPortNumber, ServiceEndpointRoutes route, string properties = null)
        {
            HttpClient = client;
            _serviceEndpoint = $"http://{clusterEndpointAddress}:{clusterPortNumber}/Core.Api/SF.Core.Api/{route}/{properties}";
        }

        #region Private Methods

        private async Task<T> ReadResponse<T>(HttpResponseMessage response)
        {
            UXLogger.UXLoggingForDebug($"ServiceApi :: ReadResponse:: started :: URI: {  response.RequestMessage.RequestUri.AbsoluteUri  }");
            byte[] arrayValue = null;
            string responseContent = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    arrayValue = (await response.Content.ReadAsByteArrayAsync());
                    if (arrayValue.Length == 0 | arrayValue == null)
                    {
                        UXLogger.UXLoggingForDebug($"ServiceApi :: ReadResponse:: array is null");
                    }
                    var json = arrayValue.Decompress();
                    //var json = (await response.Content.ReadAsByteArrayAsync()).Decompress();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Read Response received an unexpected result: {e.Message}", e);
                }
            }

            //string responseContent = (await response.Content.ReadAsByteArrayAsync()).Decompress();
            arrayValue = (await response.Content.ReadAsByteArrayAsync());
            if (arrayValue.Length == 0 | arrayValue == null)
                UXLogger.UXLoggingForDebug($"ServiceApi :: ReadResponse:: array is null");

            try
            {
                responseContent = arrayValue.Decompress();
            }
            catch (Exception ex)
            {
                UXLogger.UXLoggingForDebug($"ServiceApi :: ReadResponse:: Exception on Decompress: {  ex.Message } : { ex.StackTrace }");
            }
            var exception = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
            throw new ServiceApiException(response, exception);
        }

        private async Task ReadResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string responseContent = (await response.Content.ReadAsByteArrayAsync()).Decompress();
                var exception = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
                throw new ServiceApiException(response, exception);
            }
        }

        #endregion

        #region HTTP Methods

        #region Post

        public async Task<IEnumerable<T>> ProcessOperation<T>(IEnumerable<object> modelIEnumerable)
        {
            var data = JsonConvert.SerializeObject(modelIEnumerable).Compress();
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                var result = await ReadResponse<IEnumerable<T>>(response);
                return result;
            }
        }

        public async Task ProcessOperation(IEnumerable<object> modelIEnumerable)
        {
            var data = JsonConvert.SerializeObject(modelIEnumerable).Compress();
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                await ReadResponse(response);
            }
        }

        public async Task<T> Post<T>(object obj = null)
        {
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                var result = await ReadResponse<T>(response);
                return result;
            }
        }

        public async Task Post(object obj = null)
        {
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                await ReadResponse(response);
            }
        }

        #endregion

        #region Get
        public async Task<IEnumerable<T>> GetAll<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponse<IEnumerable<T>>(response);
                return result;
            }
        }

        public async Task<T> Get<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponse<T>(response);
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetByFilter<T>(IEnumerable<FilterCollectionModel> filters)
        {
            var data = Compressor.Compress(JsonConvert.SerializeObject(filters));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint + "filter") };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                var result = await ReadResponse<IEnumerable<T>>(response);
                return result;
            }
        }

        #endregion

        #region Update
        public async Task<T> Update<T>(object obj = null)
        {
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Put, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                var result = await ReadResponse<T>(response);
                return result;
            }
        }

        public async Task Update(object obj = null)
        {
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Put, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                await ReadResponse(response);
            }
        }

        #endregion

        #region Delete

        public async Task<T> Delete<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Delete, RequestUri = new Uri(_serviceEndpoint) };
            using (var response = await HttpClient.SendAsync(request))
            {
                var result = await ReadResponse<T>(response);
                return result;
            }
        }

        public async Task Delete(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var data = Compressor.Compress(JsonConvert.SerializeObject(obj));
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Delete, RequestUri = new Uri(_serviceEndpoint) };
            using (var response = await HttpClient.SendAsync(request))
            {
                await ReadResponse(response);
            }
        }

        #endregion

        #endregion

        #region Old HTTP Methods

        //TODO: Remove usage of these methods and replace with the new methods

        #region Private Methods

        private T ReadResponse<T>(HttpWebResponse response)
        {

            using (var streamReader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var data = streamReader.ReadToEnd();
                data = data.Remove(0, 1);
                data = data.Remove(data.Length - 1, 1);
                var result = JsonConvert.DeserializeObject<T>(data.DecompressBase64());
                return result;
            }
        }

        private T ReadUncompressedResponse<T>(HttpWebResponse response)
        {
            using (var streamReader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var data = streamReader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<T>(data);
                return result;
            }
        }

        private async Task<string> ReadResponseAsync(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            return data;
        }

        private async Task<T> ReadUncompressedResponseAsync<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }


        private WebRequest CreateWebRequest(string method, string contentType = "text/plain")
        {
            if (string.IsNullOrEmpty(method)) { throw new NullReferenceException(nameof(method)); }
            if (string.IsNullOrEmpty(contentType)) { throw new NullReferenceException(nameof(contentType)); }
            var webRequest = (HttpWebRequest)WebRequest.Create(_serviceEndpoint);
            webRequest.Timeout = 600000;
            webRequest.ContentType = contentType;
            webRequest.Method = method;
            webRequest.KeepAlive = false;
            return webRequest;
        }
        private WebRequest CreateWebRequestByFilter(string method, string contentType = "application/json; charset=utf-8")
        {
            if (string.IsNullOrEmpty(method)) { throw new NullReferenceException(nameof(method)); }
            if (string.IsNullOrEmpty(contentType)) { throw new NullReferenceException(nameof(contentType)); }

            var webRequest = WebRequest.Create(_serviceEndpoint + "filter");
            webRequest.Timeout = 600000;
            webRequest.ContentType = contentType;
            webRequest.Method = method;
            return webRequest;
        }

        private HttpWebResponse GetHttpWebResponse(WebRequest webRequest, object obj = null)
        {
            if (obj != null)
            {
                webRequest.Timeout = 600000;
                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string jsonString = JsonConvert.SerializeObject(obj).CompressBase64();
                    //jsonString = "\"" + jsonString + "\"";
                    streamWriter.Write(jsonString);
                    streamWriter.Flush();
                }
            }
            return (HttpWebResponse)webRequest.GetResponse();
        }

        private HttpWebResponse GetHttpWebResponseUncompressed(WebRequest webRequest, object obj = null)
        {
            if (obj != null)
            {
                webRequest.Timeout = 600000;
                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string jsonString = JsonConvert.SerializeObject(obj);
                    streamWriter.Write(jsonString);
                    streamWriter.Flush();
                }
            }
            return (HttpWebResponse)webRequest.GetResponse();
        }
        #endregion

        #region HTTP Methods

        #region Post

        public IEnumerable<T> OldProcessOperation<T>(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest, modelIEnumerable);
            var result = ReadResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public IEnumerable<T> OldProcessOperationUncompressed<T>(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, modelIEnumerable);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public void OldProcessOperation(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            GetHttpWebResponse(webRequest, modelIEnumerable).Dispose();
        }

        public void OldProcessOperationUncompressed(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            GetHttpWebResponseUncompressed(webRequest, modelIEnumerable).Dispose();
        }

        public async Task<List<string>> OldPostAsync(object obj = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "text/plain"))
            using (var response = await HttpClient.PostAsync(_serviceEndpoint, content))
            {
                var result = await ReadUncompressedResponseAsync<List<string>>(response);
                return result;
            }
        }

        public async Task<T> OldPostAsync<T>(object obj = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "application/json"))
            using (var response = await HttpClient.PostAsync(_serviceEndpoint, content))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(result.DecompressBase64());
            }
        }

        public T OldPost<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T OldPostUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void OldPost(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void OldPostUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();

        }
        #endregion

        #region Get
        public IEnumerable<T> OldGetAll<T>()
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            var webRequest = CreateWebRequest("GET");
            //stopwatch.Stop();
            //UXLogger.UXLoggingForDebug($"Time Taken to Create Web request:: GetAll Method:: {stopwatch.ElapsedMilliseconds}ms Service URI -  { webRequest.RequestUri.AbsolutePath}");
            webRequest.Timeout = 600000;
            // stopwatch.Restart();
            var response = GetHttpWebResponse(webRequest);
            //  stopwatch.Stop();
            // UXLogger.UXLoggingForDebug($"Time Taken to GetHttpWebResponse from Service:: {stopwatch.ElapsedMilliseconds}ms");
            // stopwatch.Restart();
            var result = ReadResponse<IEnumerable<T>>(response);
            response.Dispose();
            //  stopwatch.Stop();
            //  UXLogger.UXLoggingForDebug($"Time Taken to ReadResponse in ServiceAPI:: {stopwatch.ElapsedMilliseconds}ms");
            return result;
        }

        public async Task<List<string>> OldGetAllAsync()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadUncompressedResponseAsync<List<string>>(response);
                return result;
            }
        }

        public async Task<T> OldGetAllAsync<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(result.DecompressBase64());
            }
        }

        public async Task<IEnumerable<T>> OldGetAllAsyncUncompressed<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadUncompressedResponseAsync<IEnumerable<T>>(response);
                return result;
            }
        }

        public IEnumerable<T> OldGetAllUncompressed<T>()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var webRequest = CreateWebRequest("GET", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to Create Web request:: GetAllUncompressed Method:: {stopwatch.ElapsedMilliseconds}ms Service URI -  { webRequest.RequestUri.AbsolutePath}");
            stopwatch.Restart();
            var response = GetHttpWebResponseUncompressed(webRequest);
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to GetHttpWebResponseUncompressed from Service:: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Restart();
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to ReadResponse in ServiceAPI:: {stopwatch.ElapsedMilliseconds}ms");
            return result;
        }

        public IEnumerable<T> OldGetByFilter<T>(IEnumerable<FilterCollectionModel> filters)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Ajay/Amit: 17-Jul-2018
            //var webRequest = CreateWebRequest("POST");
            var webRequest = CreateWebRequestByFilter("POST");
            webRequest.Timeout = 600000;
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to Create Web request:: GetByFilter Method:: {stopwatch.ElapsedMilliseconds}ms Service URI -  { webRequest.RequestUri.AbsolutePath}");
            stopwatch.Restart();
            //var response = GetHttpWebResponse(webRequest, filters);
            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to GetHttpWebResponseUncompressed from Service:: {stopwatch.ElapsedMilliseconds}ms");
            return ReadResponse<IEnumerable<T>>(response);
        }

        public IEnumerable<T> OldPostAndGet<T>(object obj = null)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to Create Web request:: PostAndGet Method:: {stopwatch.ElapsedMilliseconds}ms Service URI -  { webRequest.RequestUri.AbsolutePath}");
            stopwatch.Restart();
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to GetHttpWebResponseUncompressed from Service:: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Restart();
            var result = ReadResponse<IEnumerable<T>>(response);
            response.Dispose();
            stopwatch.Stop();
            UXLogger.UXLoggingForDebug($"Time Taken to ReadResponse in ServiceAPI:: {stopwatch.ElapsedMilliseconds}ms");
            return result;
        }

        public IEnumerable<T> OldGetByFilterUncompressed<T>(IEnumerable<FilterCollectionModel> filters)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public T OldGet<T>()
        {
            var webRequest = CreateWebRequest("GET");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T OldGetUncompressed<T>()
        {
            var webRequest = CreateWebRequest("GET", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        #endregion

        #region Update
        public T OldUpdate<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT");
            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T OldUpdateUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT", "application/json; charset=utf-8");
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void OldUpdate(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT");
            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void OldUpdateUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT", "application/json; charset=utf-8");
            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();
        }
        #endregion

        #region Delete
        public T OldDelete<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE");
            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T OldDeleteUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE", "application/json; charset=utf-8");
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void OldDelete(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE");
            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void OldDeleteUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE", "application/json; charset=utf-8");
            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();
        }
        #endregion

        #endregion



        #endregion
    }
}
