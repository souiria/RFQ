/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceApi.cs
Function           :   Communication bridge of Services/Client
Created By         :   Amit
Created on         :   07-Mar-2018
Revision History   :   [11-Mar-2019] : Amit Agarwal
*                  :   [] : Method modified for provide mocking
*                  :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Added the GetAllFieldsSelector(),GetByFilterFieldsSelector() and GetAllAsyncFieldsSelector()  Methods for fetching the specific fields data.
*                  :   [13-Nov-2019] : Amit Agarwal
*                  :   [] : Added new method GetDownloadedContentSize() method to log dowonloaded bytes from content/header from response.
*                  :   [17-Apr-2020] : Pawan
*                  :   [] : Added log for end point route.
*                  :   [09-Oct-2020] : Shivam Dhingra
*                  :   [] : Overload constructor added to accept string Parameter.
*                  :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Remove Overload constructor added to accept string Parameter.
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Api.Exceptions;
using Common.UX.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api
{

    public class ServiceApi
    {
        private readonly string _serviceEndpoint;
        private static readonly HttpClient HttpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        public ServiceApi(string clusterEndpointAddress, string clusterPortNumber, ServiceEndpointRoutes route, string properties = null)
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            //if (properties == null)
            //    _serviceEndpoint = $"http://{clusterEndpointAddress}:{clusterPortNumber}/{serviceFabricApplicationsNode}/ServiceApi/{route}";
            //else
            _serviceEndpoint = $"http://{clusterEndpointAddress}:{clusterPortNumber}/Core.Api/SF.Core.Api/{route}/{properties}";
            UXLogger.UXLoggingForDebug($"Service URI -  { _serviceEndpoint }");
        }

        #region Private Methods
        private string GetDownloadedContentSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }
        private T ReadResponse<T>(HttpWebResponse response)
        {
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.ContentLength) } : Service URI -  { response.ResponseUri.AbsoluteUri }");
            using (var streamReader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var data = streamReader.ReadToEnd();
                data = data.Remove(0, 1);
                data = data.Remove(data.Length - 1, 1);
                T result = default(T);

                try
                {
                    result = JsonConvert.DeserializeObject<T>(data.DecompressBase64());

                }
                catch (Exception)
                {
                    try
                    {
                        var byteData = Encoding.UTF8.GetBytes(data);
                        result = JsonConvert.DeserializeObject<T>(byteData.Decompress());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }
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
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : Service URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            return data;
        }

        private async Task<T> ReadUncompressedResponseAsync<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : Service URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");

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

        private WebRequest CreateWebRequestByFilterColumns(string method, string contentType = "application/json; charset=utf-8")
        {
            if (string.IsNullOrEmpty(method)) { throw new NullReferenceException(nameof(method)); }
            if (string.IsNullOrEmpty(contentType)) { throw new NullReferenceException(nameof(contentType)); }

            var webRequest = WebRequest.Create(_serviceEndpoint + "GetAllFieldsSelectorFilter");
            webRequest.Timeout = 600000;
            webRequest.ContentType = contentType;
            webRequest.Method = method;
            return webRequest;
        }

        private WebRequest CreateWebRequestAllFieldsSelector(string method, string contentType = "application/json; charset=utf-8")
        {
            if (string.IsNullOrEmpty(method)) { throw new NullReferenceException(nameof(method)); }
            if (string.IsNullOrEmpty(contentType)) { throw new NullReferenceException(nameof(contentType)); }

            var webRequest = WebRequest.Create(_serviceEndpoint + "GetAllFieldsSelector");
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

        public async Task<IEnumerable<T>> ProcessOperation<T>(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest, modelIEnumerable);
            var result = ReadResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public IEnumerable<T> ProcessOperationUncompressed<T>(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, modelIEnumerable);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public void ProcessOperation(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            GetHttpWebResponse(webRequest, modelIEnumerable).Dispose();
        }

        public void ProcessOperationUncompressed(IEnumerable<object> modelIEnumerable)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            GetHttpWebResponseUncompressed(webRequest, modelIEnumerable).Dispose();
        }

        public async Task<List<string>> PostAsync(object obj = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "text/plain"))
            using (var response = await HttpClient.PostAsync(_serviceEndpoint, content))
            {
                var result = await ReadUncompressedResponseAsync<List<string>>(response);
                return result;
            }
        }

        public async Task<T> PostAsync<T>(object obj = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "application/json"))
            using (var response = await HttpClient.PostAsync(_serviceEndpoint, content))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(result.DecompressBase64());
            }
        }

        public T Post<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }
        public async Task<T> PostByteArray<T>(object obj = null)
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

        public T PostUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void Post(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST");
            webRequest.Timeout = 600000;

            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void PostUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();

        }
        #endregion

        #region Get
        public async Task<IEnumerable<T>> GetAll<T>()
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

        /// <summary>
        /// Communicates with the services, retrieving the required items and read the Response.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="fields">Name of fields required in the form of list</param>
        /// <returns>Response from service</returns>
        public async Task<IEnumerable<T>> GetAllFieldsSelector<T>(List<string> fields)
        {

            var webRequest = CreateWebRequestAllFieldsSelector("POST");
            webRequest.Timeout = 600000;
            var response = GetHttpWebResponseUncompressed(webRequest, JsonConvert.SerializeObject(fields).CompressBase64());
            return ReadResponse<IEnumerable<T>>(response);
        }
        /// <summary>
        /// Communicates with the services, retrieving the required items asynchronously and read the Response.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="fields">Name of fields required in the form of list</param>
        /// <returns>Response from service</returns>
        public async Task<List<string>> GetAllAsyncFieldsSelector(List<string> fields)
        {
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(fields).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await ReadUncompressedResponseAsync<List<string>>(response);
            return result;
        }

        public async Task<List<string>> GetSpecificFieldsAsyncByFilter(FiltersSpecificModel filtersSpecifics)
        {
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filtersSpecifics).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await ReadUncompressedResponseAsync<List<string>>(response);
            return result;
        }

        public async Task<List<string>> GetFieldsSelectorWithFilterByDictionary(FiltersSpecificModel filtersSpecifics)
        {
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filtersSpecifics).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await ReadUncompressedResponseAsync<List<string>>(response);
            return result;
        }
        public async Task<List<string>> GetAllAsync()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadUncompressedResponseAsync<List<string>>(response);
                return result;
            }
        }

        public async Task<T> GetAllAsync<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(result.DecompressBase64());
            }
        }

        public async Task<IEnumerable<T>> GetAllAsyncUncompressed<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadUncompressedResponseAsync<IEnumerable<T>>(response);
                return result;
            }
        }

        public IEnumerable<T> GetAllUncompressed<T>()
        {
            var webRequest = CreateWebRequest("GET", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;
            var response = GetHttpWebResponseUncompressed(webRequest);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public async Task<IEnumerable<T>> GetByFilter<T>(IEnumerable<FilterCollectionModel> filters)
        {
            //Ajay/Amit: 17-Jul-2018
            //var webRequest = CreateWebRequest("POST");
            var webRequest = CreateWebRequestByFilter("POST");
            webRequest.Timeout = 600000;
            //var response = GetHttpWebResponse(webRequest, filters);
            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            return ReadResponse<IEnumerable<T>>(response);
        }

        /// <summary>
        /// Communicates with the services, retrieving the required items asynchronously by applying the filters and read the Response.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="filters">Name of fields required in the form of list</param>
        /// <returns>Response from service</returns>
        public async Task<IEnumerable<T>> GetByFilterFieldsSelector<T>(IEnumerable<SpecificDataFilteringModel> filters)
        {
            var webRequest = CreateWebRequestByFilterColumns("POST");
            webRequest.Timeout = 600000;
            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            return ReadResponse<IEnumerable<T>>(response);
        }
        public IEnumerable<T> PostAndGet<T>(object obj = null)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public IEnumerable<T> GetByFilterUncompressed<T>(IEnumerable<FilterCollectionModel> filters)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public IEnumerable<T> GetByFilterFieldsSelectorUncompressed<T>(IEnumerable<SpecificDataFilteringModel> filters)
        {
            var webRequest = CreateWebRequest("POST", "application/json; charset=utf-8");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponseUncompressed(webRequest, filters);
            var result = ReadUncompressedResponse<IEnumerable<T>>(response);
            response.Dispose();
            return result;
        }

        public async Task<T> Get<T>()
        {
            var webRequest = CreateWebRequest("GET");
            webRequest.Timeout = 600000;

            var response = GetHttpWebResponse(webRequest);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T GetUncompressed<T>()
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
        public T Update<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT");
            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T UpdateUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT", "application/json; charset=utf-8");
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void Update(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT");
            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void UpdateUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("PUT", "application/json; charset=utf-8");
            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();
        }
        #endregion

        #region Delete
        public T Delete<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE");
            var response = GetHttpWebResponse(webRequest, obj);
            var result = ReadResponse<T>(response);
            response.Dispose();
            return result;
        }

        public T DeleteUncompressed<T>(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE", "application/json; charset=utf-8");
            var response = GetHttpWebResponseUncompressed(webRequest, obj);
            var result = ReadUncompressedResponse<T>(response);
            response.Dispose();
            return result;
        }

        public void Delete(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE");
            GetHttpWebResponse(webRequest, obj).Dispose();
        }

        public void DeleteUncompressed(object obj = null)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            var webRequest = CreateWebRequest("DELETE", "application/json; charset=utf-8");
            GetHttpWebResponseUncompressed(webRequest, obj).Dispose();
        }
        #endregion

        #endregion

        #region Byte HTTP Methods

        private async Task<T> ReadResponse<T>(HttpResponseMessage response)
        {

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var json = (await response.Content.ReadAsByteArrayAsync()).Decompress();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Read Response received an unexpected result: {e.Message}", e);
                }
            }

            string responseContent = (await response.Content.ReadAsByteArrayAsync()).Decompress();
            var exception = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
            throw new ServiceApiException(response, exception);
        }

        private async Task ReadResponse(HttpResponseMessage response)
        {
            await response.Content.ReadAsStreamAsync();
        }

        #region Post

        public async Task<IEnumerable<T>> ProcessOperationBytes<T>(IEnumerable<object> modelIEnumerable)
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

        public async Task ProcessOperationBytes(IEnumerable<object> modelIEnumerable)
        {
            var data = JsonConvert.SerializeObject(modelIEnumerable).Compress();
            HttpRequestMessage request = new HttpRequestMessage { Content = new ByteArrayContent(data), Method = HttpMethod.Post, RequestUri = new Uri(_serviceEndpoint) };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            using (var response = await HttpClient.SendAsync(request))
            {
                await ReadResponse(response);
            }
        }

        public async Task<T> PostBytes<T>(object obj = null)
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

        public async Task PostBytes(object obj = null)
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
        public async Task<IEnumerable<T>> GetAllBytes<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponse<IEnumerable<T>>(response);
                return result;
            }
        }

        public async Task<T> GetBytes<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadResponse<T>(response);
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetByFilterBytes<T>(IEnumerable<FilterCollectionModel> filters)
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
        public async Task<T> UpdateBytes<T>(object obj = null)
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

        public async Task UpdateBytes(object obj = null)
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

        public async Task<T> DeleteBytes<T>(object obj = null)
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

        public async Task DeleteBytes(object obj = null)
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
    }
}
