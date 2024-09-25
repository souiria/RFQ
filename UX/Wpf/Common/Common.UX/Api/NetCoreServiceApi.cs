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
*                  :   [30-Mar-2020] : Srashti Gupta
*                  :   [] : Added new method GetSpecificFieldsAsyncByFilter(), GetFieldsSelectorWithFilterByDictionary(), PostAndGet() for fetching the data w.r.t filter and Ids.   
*                  :   [14-04-2020] : Amit Agarwal
                   :   [] : Improvements done w.r.t filters.
                   :   [23-04-2020] : Srashti Gupta
                   :   [] : Added log to GetSpecificFieldsAsyncByFilter() & GetFieldsSelectorWithFilterByDictionary()
*                  :   [27-May-2020] : Amit
*                  :   [] : passed parameters to ProcessOpeation method
                   :   [03-May-2020] : Amit
                   :   [] : Added the endpoints IsExistsByFiltersAsync()
                   :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Overload constructor added to accept string Parameter.
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api
{
    public class NetCoreServiceApi
    {
        private readonly string _serviceEndpoint;
        private static readonly HttpClient HttpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        public NetCoreServiceApi(string clusterEndpointAddress, ServiceEndpointRoutes route, string properties = null,string port = "8100")
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            _serviceEndpoint = $"http://{clusterEndpointAddress}:{ port }/{route}/{properties}";
        }
        public NetCoreServiceApi(string clusterEndpointAddress, string route)
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            _serviceEndpoint = $"http://{clusterEndpointAddress}:{route}";
        }


        #region Private Methods

        private static string ReplaceGetResponseDelimiters(string bodyString)
        {
            if (bodyString.StartsWith("\""))
            {
                bodyString = bodyString.Replace("\"", string.Empty);
            }
            if (bodyString.EndsWith("\""))
            {
                bodyString = bodyString.Replace("\"", string.Empty);
            }
            if (bodyString.StartsWith("[\""))
            {
                bodyString = bodyString.Replace("[\"", string.Empty);
            }
            if (bodyString.EndsWith("\"]"))
            {
                bodyString = bodyString.Replace("\"]", string.Empty);
            }
            return bodyString;
        }

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

        private async Task<string> ReadResponseAsync(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : NetCoreService URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            return data;
        }

        private async Task<T> ReadUncompressedResponseAsync<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : NetCoreService URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }

        #endregion

        #region HTTP Methods

        #region Post

        public async Task<T> PostAsync<T>(object obj = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "text/plain"))
            using (var response = await HttpClient.PostAsync(_serviceEndpoint, content))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(result.DecompressBase64());
            }
        }
       
        #endregion

        #region Get
       
        
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
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filtersSpecifics).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : NetCoreService URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            resultdata.Add(result);
            return resultdata;
        }
        public async Task<List<string>> IsExistsByFiltersAsync(List<SpecificDataFilteringModel> filters)
        {
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filters).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : NetCoreService URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            resultdata.Add(result);
            return resultdata;
        }


        public async Task<List<string>> GetFieldsSelectorWithFilterByDictionary(FiltersSpecificModel filtersSpecifics)
        {
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filtersSpecifics).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await response.Content.ReadAsStringAsync();
            UXLogger.UXLoggingForDebug($"Downloaded data size :: { GetDownloadedContentSize(response.Content.Headers.ContentLength.Value) } : NetCoreService URI -  { response.RequestMessage.RequestUri.AbsoluteUri }");
            resultdata.Add(result);
            return resultdata;
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

        public async Task<T> GetAllAsync<T>(object parameters = null)
        {
            using (var response = await HttpClient.GetAsync($"{_serviceEndpoint}/{parameters}"))
            {
                var result = await ReadResponseAsync(response);
                return JsonConvert.DeserializeObject<T>(ReplaceGetResponseDelimiters(result).DecompressBase64());
            }
        }

        public async Task<List<T>> GetAllAsyncUncompressed<T>()
        {
            using (var response = await HttpClient.GetAsync(_serviceEndpoint))
            {
                var result = await ReadUncompressedResponseAsync<List<T>>(response);
                return result;
            }
        }

        #endregion

        #region PostAndGet
        public async Task<List<string>> PostAndGet<T>(object obj = null)
        {
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(_serviceEndpoint, new StringContent(JsonConvert.SerializeObject(obj).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await ReadResponseAsync(response);
            resultdata.Add(result);
            return resultdata;
        }
        #endregion

        #endregion
    }
}
