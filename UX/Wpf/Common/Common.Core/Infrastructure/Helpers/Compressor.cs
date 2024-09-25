/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   Compressor.cs
Function           :   Creates a new instance of the proxy Compressor.
Created By         :  
Created on         :  
Revision History   :   [06-Jan-2020] : Amit Agarwal
*                  :   [] : Modifiy w.r.t. memory leak issues
*                  :   [25-feb-2020] : Nitin 
*                  :   [] : Added compression scheme for angular
*                  :   [27-March-2020] :  Amit Agarwal
*                  :   Modifications done w.r.t Compressor Factory
*                  :   [16-Apr-2020] :  Amit Agarwal
*                  :   Modifications done w.r.t null buffer array
****************************************************************************************************/
using Common.Core.Contracts.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Common.Core.Infrastructure.Helpers
{
    
    /// <summary>
    /// Concreate Class for Compression/Decompression, with disose pattern
    /// </summary>
    public class CompressorNonStatic : IDisposable , ICompressor
    {
        byte[] BytesBuffer { get; set; }
        byte[] ZipBuffer { get; set; }
        //
        public string CompressBase64(string text)
        {
            BytesBuffer = Encoding.UTF8.GetBytes(text);
            byte[] gZipBuffer = null;
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var stream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                    {
                        stream.Write(BytesBuffer, 0, BytesBuffer.Length);
                        stream.Dispose();
                    }
                    memoryStream.Position = 0;
                    var compressed = new byte[memoryStream.Length];
                    memoryStream.Read(compressed, 0, compressed.Length);
                    memoryStream.Dispose();
                    gZipBuffer = new byte[compressed.Length + 4];
                    Buffer.BlockCopy(compressed, 0, gZipBuffer, 4, compressed.Length);
                    Buffer.BlockCopy(BitConverter.GetBytes(BytesBuffer.Length), 0, gZipBuffer, 0, 4);
                    return Convert.ToBase64String(gZipBuffer);
                }
            }
            catch { }
            finally
            {
                BytesBuffer = new byte[0];
                ZipBuffer = new byte[0];
            }
            return string.Empty;
        }
        void Log(string text)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} :: Compression :: {text}");
        }
        /// &lt;summary&gt;
        /// Use this to decompress Base-64 string to UTF-8 string.
        /// &lt;/summary&gt;
        /// &lt;param name="compressedText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public string DecompressBase64(string compressedText)
        {
            ZipBuffer = Convert.FromBase64String(compressedText);
            if (!string.IsNullOrEmpty(compressedText))
            {
                using (var memoryStream = new MemoryStream())
                {
                    int dataLength = BitConverter.ToInt32(ZipBuffer, 0);
                    memoryStream.Write(ZipBuffer, 4, ZipBuffer.Length - 4);
                    BytesBuffer = new byte[dataLength];
                    memoryStream.Position = 0;
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gZipStream.Read(BytesBuffer, 0, BytesBuffer.Length);
                        gZipStream.Dispose();
                    }
                    memoryStream.Dispose();
                    return Encoding.UTF8.GetString(BytesBuffer);
                }
            }
            return compressedText;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Array.Clear(ZipBuffer, 0, ZipBuffer.Length);
                    Array.Clear(BytesBuffer, 0, BytesBuffer.Length);
                    ZipBuffer = new byte[0];
                    BytesBuffer = new byte[0];
                    ZipBuffer = null;
                    BytesBuffer = null;
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CompressorNonStatic()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    /// &lt;summary&gt;
    /// Represents a class that can be consumed to compress/decompress string.
    /// &lt;/summary&gt;
    public static class Compressor 
    {
        public static byte[] Compress(this string text)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream gzip =
                  new GZipStream(output, CompressionMode.Compress))
                {
                    using (StreamWriter writer =
                      new StreamWriter(gzip, Encoding.UTF8))
                    {
                        writer.Write(text);
                    }
                }

                return output.ToArray();
            }
        }

        public static string Decompress(this byte[] compressedBytes)
        {
            using (MemoryStream inputStream = new MemoryStream(compressedBytes))
            {
                using (GZipStream gzip =
                  new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader =
                      new StreamReader(gzip, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        #region Less Performant

        /// &lt;summary&gt;
        /// Use this to compress UTF-8 string to Base-64 string.
        /// &lt;/summary&gt;
        /// &lt;param name="text"&gt;The string value to compress.&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static string CompressBase64(this string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            byte[] gZipBuffer = null;
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var stream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Dispose();
                    }
                    memoryStream.Position = 0;
                    var compressed = new byte[memoryStream.Length];
                    memoryStream.Read(compressed, 0, compressed.Length);
                    memoryStream.Dispose();
                    gZipBuffer = new byte[compressed.Length + 4];
                    Buffer.BlockCopy(compressed, 0, gZipBuffer, 4, compressed.Length);
                    Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
                    return Convert.ToBase64String(gZipBuffer);
                }
            }
            catch (Exception ex)
            {
                Log($"Exception: { ex.Message } ");
            }
            finally
            {
                if (buffer != null)
                    Array.Clear(buffer, 0, buffer.Length);
                if (gZipBuffer != null)
                    Array.Clear(gZipBuffer, 0, gZipBuffer.Length);
                buffer = new byte[0];
                gZipBuffer = new byte[0];
                buffer = null;
                gZipBuffer = null;
            }
            return string.Empty;
        }
        static void Log(string text)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} :: Compression :: {text}");
        }
        /// &lt;summary&gt;
        /// Use this to decompress Base-64 string to UTF-8 string.
        /// &lt;/summary&gt;
        /// &lt;param name="compressedText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static string DecompressBase64(this string compressedText)
        {
            byte[] buffer = null;
            var gZipBuffer = Convert.FromBase64String(compressedText);
            try
            {
                if (!string.IsNullOrEmpty(compressedText))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                        memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);
                        buffer = new byte[dataLength];
                        memoryStream.Position = 0;
                        using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                        {
                            gZipStream.Read(buffer, 0, buffer.Length);
                            gZipStream.Dispose();
                        }
                        memoryStream.Dispose();
                        return Encoding.UTF8.GetString(buffer);
                    }
                }
                return compressedText;
            }
            catch
            {
            }
            finally
            {
                Array.Clear(gZipBuffer, 0, gZipBuffer.Length);
                Array.Clear(buffer, 0, buffer.Length);
                gZipBuffer = new byte[0];
                buffer = new byte[0];
                gZipBuffer = null;
                buffer = null;
            }
            return String.Empty;
        }
        #endregion
      

    }

    /// <summary>
    /// Concreate Class for Compression/Decompression, with disose pattern
    /// </summary>
    public class CompressorAngular : IDisposable,ICompressor
    {
        #region CompressionBase64Angular
        /// &lt;summary&gt;
        /// Use this to decompress Base-64 string to UTF-8 string for Angular.
        /// &lt;/summary&gt;
        /// &lt;param name="compressedText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public  string DecompressBase64(string compressedText)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(compressedText);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// &lt;summary&gt;
        /// Use this to compress UTF-8 string to Base-64 string for Angular
        /// &lt;/summary&gt;
        /// &lt;param name="text"&gt;The string value to compress.&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public  string CompressBase64(string text)
        {
            try
            {
                byte[] encData_byte = new byte[text.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(text);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CompressorNonStatic()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    #region System Compressor Provider Factory

    /// <summary>
    /// All Harness One System Compressor/Decompressor Scheme
    /// </summary>
    public class HarnessOneCompressorProvider : CompressorNonStatic
    {

    }
    /// <summary>
    /// Supply Planning System Compressor/Decompressor Scheme
    /// </summary>
    public class SupplyPlanningCompressorProvider : CompressorNonStatic
    {

    }
    /// <summary>
    /// Yokoten System Compressor/Decompressor Scheme
    /// </summary>
    public class YokotenCompressorProvider : CompressorAngular
    {

    }
    /// <summary>
    /// Compressor Scheme of Different systems
    /// </summary>
    public enum SystemName
    {
        HarnessOne,
        SupplyPlanning,
        Yokoten
    }
    /// <summary>
    /// System Compressor Provider Factory
    /// </summary>
    public class SystemCompressor
    {
        SystemName systemName;
        public SystemCompressor(SystemName systemType)
        {
            systemName = systemType;
        }
        public ICompressor CompressorProvider
        {
            get
            {
                ICompressor returnValue = null;
                switch (systemName)
                {
                    case SystemName.HarnessOne:
                        returnValue = new HarnessOneCompressorProvider();
                        break;
                    case SystemName.SupplyPlanning:
                        returnValue = new SupplyPlanningCompressorProvider();
                        break;
                    case SystemName.Yokoten:
                        returnValue = new YokotenCompressorProvider();
                        break;
                    default:
                        break;
                }
                return returnValue;
            }
        }
    }

    #endregion
}