/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceProxy.cs
Function           :   Proxy method collection to connect service to service intraction
Created By         :   Amit
Created on         :   22-Apr-2020
Revision History   :   [06-May-2020] : Dharmendra
                   :   [] : Added New Method Process Operation for service to service intraction
                   :   [12-May-2020] : Amit
                   :   [] : Process Operation to get the worked.
                   :   [16-Oct-2020] : SrashtiGupta
                   :   [] : PostAsync : Added New Method for service to service intraction & modified the name of method
                   :   [27-Oct-2020] : SrashtiGupta
                   :   [] : GetAllAsync : Added IsMultipleDictioanry property in method & implementation
                   :   [06-Nov-2020] : SrashtiGupta
                   :   [] : Modified Constructor by making port as optional parameter
****************************************************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Infrastructure.Helpers;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Infrastructure.Core;
using Common.SF.Contracts.Models.Core.Proxy;
using System.Fabric;
using Common.Core.Contracts.Interfaces;
using System.Runtime.Serialization.Formatters.Binary;
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Extensions;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Common.SF.Infrastructure.Helpers
{
    /// <summary>
    /// Class for Service to Service interaction
    /// </summary>
    public class NetCoreServiceProxy
    {
        /// <summary>
        /// Local Reference for _fabricClient
        /// </summary>
        private readonly IWrappedFabricClient _fabricClient = FabricClientProvider.FabricClient;
        /// <summary>
        /// Local Reference for _serviceEndpoint
        /// </summary>
        private readonly string _serviceEndpoint;
        /// <summary>
        /// Local Reference for HttpClient
        /// </summary>
        private static readonly HttpClient HttpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
        /// <summary>
        /// Local Reference for _address
        /// </summary>
        private readonly Uri _address = null;
        /// <summary>
        /// Constructor for NetCoreServiceProxy
        /// </summary>
        /// <param name="clusterEndpointAddress">clusterEndpointAddress</param>
        /// <param name="route">EndPoint Route</param>
        /// <param name="address">Uri Address</param>
        /// <param name="port">Port Number</param>
        public NetCoreServiceProxy(string clusterEndpointAddress, string route, Uri address, string port = "19081")
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            _serviceEndpoint = $"http://{clusterEndpointAddress}:{port}/{route}";
            _address = address;

        }
        /// <summary>
        /// Execute to fetch the Range of Partitions
        /// </summary>
        /// <returns>Task<List<Range>></returns>
        public async Task<List<Range>> EstablishPartitions()
        {
            Console.WriteLine($"{ DateTime.Now.ToString()} --EstablishPartitions ::  started");
            try
            {
                var _partitions = await _fabricClient.QueryManager.GetPartitionListAsync(_address);
                if (_partitions.Count > 16)
                    throw new FabricInvalidPartitionKeyException("Partition count for the selected service is greater than 16 and cannot be processed using" +
                        " the generic classes.");

                var ranges = new List<Range>();

                foreach (var partition in _partitions)
                {
                    switch (partition.PartitionInformation)
                    {
                        case IWrappedSingletonPartitionInformation _:
                            return ranges;

                        case IWrappedInt64RangePartitionInformation int64RangePartitionInformation when int64RangePartitionInformation.LowKey < 0:
                            throw new ArgumentOutOfRangeException(nameof(int64RangePartitionInformation.LowKey), "Low and high key for partitions must be set to 0 and 15");

                        case IWrappedInt64RangePartitionInformation int64RangePartitionInformation when int64RangePartitionInformation.HighKey > 15:
                            throw new ArgumentOutOfRangeException(nameof(int64RangePartitionInformation.HighKey), "Low and high key for partitions must be set to 0 and 15");

                        case IWrappedInt64RangePartitionInformation int64RangePartitionInformation:
                            ranges.Add(new Range(int64RangePartitionInformation.LowKey, int64RangePartitionInformation.HighKey));
                            break;

                        default:
                            throw new ArgumentException("Service partitions are not of an expected type Int64RangePartitionInformation or SingletonPartitionInformation");
                    }
                }

                return ranges;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ DateTime.Now.ToString()} --EstablishPartitions ::  { ex.Message} :: { ex.StackTrace  }");
            }
            Console.WriteLine($"{ DateTime.Now.ToString()} --EstablishPartitions ::  ended");
            return new List<Range>();

        }
        /// <summary>
        /// To pass the filter correct.
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>string</returns>
        public string SetFilterValue(object fieldvalue)
        {
            if (fieldvalue != null)
            {
                if (fieldvalue.GetType() == typeof(string))
                    return $"\"{ fieldvalue.ToString() }\"";
                else
                    return fieldvalue.ToString();
            }
            else
                return null;
        }
        /// <summary>
        /// Replace the Delimiters with string.Empty
        /// </summary>
        /// <param name="bodyString">string</param>
        /// <returns>string</returns>
        private static string ReplacePostResponseDelimiters(string bodyString)
        {
            if (bodyString.StartsWith("[\""))
            {
                bodyString = bodyString.Replace("[\"", string.Empty);
            }
            if (bodyString.EndsWith("\"]"))
            {
                bodyString = bodyString.Replace("\"]", string.Empty);
            }
            if (bodyString.StartsWith("\""))
            {
                bodyString = bodyString.Replace("\"", string.Empty);
            }
            if (bodyString.EndsWith("\""))
            {
                bodyString = bodyString.Replace("\"", string.Empty);
            }
            return bodyString;
        }
        /// <summary>
        /// Read the Service Response
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>Task<string></returns>
        private async Task<string> ReadResponseAsync(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }
        /// <summary>
        /// Read the Response & DeserializeObject data
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="response">HttpResponseMessage</param>
        /// <returns>Task<T></returns>
        private async Task<T> ReadUncompressedResponseAsync<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }
        #region HTTP Methods

        #region GetByFilterPostAsync
        /// <summary>
        /// Get Data using filter service data for service to service intraction
        /// </summary>
        /// <typeparam name="T">Generic Model</typeparam>
        /// <param name="parameters">Extended Endpoint parameters</param>
        /// <param name="obj">filter object</param>
        /// <param name="IsMultipleDictioanry">Default : False</param>
        /// <returns></returns>
        public async Task<List<T>> GetByFilterPostAsync<T>(string parameters, object obj = null, bool IsMultipleDictioanry = false)
        {
            List<Range> partitions = new List<Range>();
            if (IsMultipleDictioanry == false)
                partitions = await EstablishPartitions();

            var items = new List<T>();
            var tasks = new List<Task>();
            var content = JsonConvert.SerializeObject(obj).CompressBase64();
            if (IsMultipleDictioanry == false)
            {
                foreach (var key in partitions.Select(it => it.Low))
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await PostAsync($"{_serviceEndpoint }/{ parameters }?PartitionKey={ key }&PartitionKind=Int64Range", content);
                        foreach (var objData in objDataList)
                        {
                            if (objData != "AAAAAB+LCAAAAAAAAAoDAAAAAAAAAAAA")
                            {
                                CompressorNonStatic compressorPost = new CompressorNonStatic();
                                var results = JsonConvert.DeserializeObject<List<T>>(compressorPost.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                                if (results.Count > 0)
                                {
                                    Console.WriteLine($"{ DateTime.Now.ToString()} -- <T>  Return Results Count ::  { results.Count }");
                                    lock (items)
                                        items.AddRange(results);
                                    compressorPost.Dispose();
                                }
                            }
                        }
                    }));
                }
            }
            else
            {
                tasks.Add(Task.Run(async () =>
                {
                    var objDataList = await PostAsync($"{_serviceEndpoint }/{ parameters }?PartitionKey=0&PartitionKind=Int64Range", content);
                    foreach (var objData in objDataList)
                    {
                        if (objData != "AAAAAB+LCAAAAAAAAAoDAAAAAAAAAAAA")
                        {
                            CompressorNonStatic compressorPost = new CompressorNonStatic();
                            var results = JsonConvert.DeserializeObject<List<T>>(compressorPost.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                            if (results.Count > 0)
                            {
                                Console.WriteLine($"{ DateTime.Now.ToString()} -- <T>  Return Results Count ::  { results.Count }");
                                lock (items)
                                    items.AddRange(results);
                                compressorPost.Dispose();
                            }
                        }
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return items;
        }

        #endregion

        #region Get

        /// <summary>
        /// IsMultiplePartitions : [TRUE] - Fetch the data by PartitionKeys
        /// IsMultiplePartitions : [FALSE] - Fetch all data
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="IsMultiplePartitions">Default : true</param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync<T>(bool IsMultiplePartitions = true)
        {
            List<Range> partitions = new List<Range>();
            if (IsMultiplePartitions == true)
                partitions = await EstablishPartitions();

            var items = new List<T>();
            var tasks = new List<Task>();
            if (IsMultiplePartitions == true)
            {
                foreach (var key in partitions.Select(it => it.Low))
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var results = await GetAll<T>($" {_serviceEndpoint }?PartitionKey={ key }&PartitionKind=Int64Range");
                        lock (items)
                            items.AddRange(results);
                    }));
                }
            }
            else if (IsMultiplePartitions == false)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var results = await GetAll<T>($" {_serviceEndpoint }");
                    lock (items)
                        items.AddRange(results);
                }));

            }
            await Task.WhenAll(tasks);
            return items;
        }

        /// <summary>
        /// Get Specific Fields Data using filter service data for service to service intraction
        /// </summary>
        /// <param name="serviceEndpoint">Service EndPoint Address</param>
        /// <param name="filtersSpecifics">FiltersSpecificModel Reference</param>
        /// <returns></returns>
        async Task<List<string>> GetSpecificFieldsAsyncByFilter(string serviceEndpoint, FiltersSpecificModel filtersSpecifics)
        {
            Console.WriteLine($"{ DateTime.Now.ToString()} --GetSpecificFieldsAsyncByFilter ::  { serviceEndpoint }");
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(serviceEndpoint, new StringContent(JsonConvert.SerializeObject(filtersSpecifics).CompressBase64(), Encoding.UTF8, "text/plain"));
            var result = await response.Content.ReadAsStringAsync();
            resultdata.Add(result);
            return resultdata;
        }

        /// <summary>
        /// GetAll service data for service to service intraction
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="serviceEndpoint">Service EndPoint Address</param>
        /// <returns></returns>
        public async Task<List<T>> GetAll<T>(string serviceEndpoint)
        {
            CompressorNonStatic compressor = new CompressorNonStatic();
            List<T> returnResult = default(List<T>);
            try
            {
                using (var response = await HttpClient.GetAsync(serviceEndpoint))
                {
                    var result = await ReadResponseAsync(response);
                    if (result != "")
                        returnResult = JsonConvert.DeserializeObject<List<T>>(compressor.DecompressBase64(ReplacePostResponseDelimiters(result)));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                compressor.Dispose();
            }
            return returnResult;
        }

        #endregion

        #region PostAndGet
        /// <summary>
        /// PostAndGet service data for service to service intraction
        /// </summary>
        /// <typeparam name="T">Return Type</typeparam>
        /// <param name="properties">Extended Endpoint parameters</param>
        /// <param name="filtersSpecifics">FiltersSpecificModel Reference</param>
        /// <returns></returns>
        public async Task<List<T>> GetSpecificFieldsAsyncByFilter<T>(string properties = null, FiltersSpecificModel filtersSpecifics = null)
        {
            var partitions = await EstablishPartitions();
            var items = new List<T>();
            var tasks = new List<Task>();
            try
            {
                foreach (var key in partitions.Select(it => it.Low))
                {
                    tasks.Add(Task.Run(async () =>
                    {

                        string actionProperty = string.Empty;
                        if (properties != null)
                            actionProperty =/* "/" +*/ properties;

                        var objDataList = await GetSpecificFieldsAsyncByFilter($"{_serviceEndpoint }/{ actionProperty }?PartitionKey={ key }&PartitionKind=Int64Range", filtersSpecifics);
                        foreach (var objData in objDataList)
                        {
                            if (objData != "")
                            {
                                CompressorNonStatic compressor = new CompressorNonStatic();
                                var results = JsonConvert.DeserializeObject<List<T>>(compressor.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                                if (results.Count > 0)
                                {
                                    Console.WriteLine($"{ DateTime.Now.ToString()} -- GetSpecificFieldsAsyncByFilter<T> Data ::  { results.Count }");

                                    lock (items)
                                        items.AddRange(results);
                                    compressor.Dispose();
                                }
                            }
                        }
                    }));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ DateTime.Now.ToString()} -- GetSpecificFieldsAsyncByFilter<T> :: Exception { ex.Message } :: { ex.StackTrace }");
            }
            await Task.WhenAll(tasks);
            return items;
        }


        #endregion

        #region  Process Operation for service to service intraction
        /// <summary>
        /// Process service data for service to service intraction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceEndpoint"></param>
        /// <param name="items"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<T>> ProcessOperation<T>(String requeststring, string parameters = null)
        {

            Dictionary<long, string> RequestsPipeLineWithModels = new Dictionary<long, string>();
            CompressorNonStatic compressor = new CompressorNonStatic();
            string routevalue = string.Empty;
            var partitions = await EstablishPartitions();
            List<T> erroredModels = new List<T>();
            var tasks = new List<Task>();
            var PartitionsInformation = partitions.Select(it => new
            {
                LowKey = it.Low,
                HighKey = it.High

            });

            if (!String.IsNullOrEmpty(requeststring))
            {
                var ReturnString = ReplacePostResponseDelimiters(requeststring);
                JToken PostedData = JValue.Parse(Compressor.DecompressBase64(ReturnString));

                var postedModelsStructure = PostedData.GroupBy(it => (new Guid(it["Id"].ToString())).ToPartitionKey()).Select(
                                                it =>
                                                new
                                                {
                                                    PartitionKey = it.Key,
                                                    Models = it.ToList()
                                                }).ToDictionary(x => x.PartitionKey, x => x.Models);

                RequestsPipeLineWithModels = PartitionsInformation.Select(it => new
                {
                    it.LowKey,
                    Models = postedModelsStructure.Where(p => p.Key >= it.LowKey && p.Key <= it.HighKey).Where(w => w.Value != null)
                    .SelectMany(s => s.Value)
                }).ToDictionary(x => x.LowKey, x => Compressor.CompressBase64(JsonConvert.SerializeObject(x.Models.ToList())));
                postedModelsStructure.Clear();
            }

            foreach (var key in RequestsPipeLineWithModels.Where(it => it.Value != "AgAAAB+LCAAAAAAABACLjgUAKbtMDQIAAAA="))
            {
                tasks.Add(Task.Run(async () =>
                {

                    string actionProperty = string.Empty;
                    if (parameters != null)
                        actionProperty =/* "/" +*/ parameters;

                    var objDataList = await PostAsync($"{_serviceEndpoint }/{ actionProperty }?PartitionKey={ key.Key }&PartitionKind=Int64Range", key.Value);
                    foreach (var objData in objDataList)
                    {
                        if (objData != "AAAAAB+LCAAAAAAAAAoDAAAAAAAAAAAA")
                        {
                            CompressorNonStatic compressorPost = new CompressorNonStatic();
                            var results = JsonConvert.DeserializeObject<List<T>>(compressorPost.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                            if (results.Count > 0)
                            {
                                Console.WriteLine($"{ DateTime.Now.ToString()} -- <T>  Return Results Count ::  { results.Count }");
                                lock (erroredModels)
                                    erroredModels.AddRange(results);
                                compressorPost.Dispose();
                            }
                        }
                    }
                }));
            }
            await Task.WhenAll(tasks);

            return erroredModels;
        }

        async Task<List<string>> PostAsync(string serviceEndpoint, string compressedData)
        {
            Console.WriteLine($"{ DateTime.Now.ToString()} --PostAsync ::  { serviceEndpoint }");
            List<string> resultdata = new List<string>();
            var response = await HttpClient.PostAsync(serviceEndpoint, new StringContent((compressedData), Encoding.UTF8, "text/plain"));
            var result = await response.Content.ReadAsStringAsync();
            resultdata.Add(result);
            return resultdata;
        }
        #endregion
        #endregion

    }
}
