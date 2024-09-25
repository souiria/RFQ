using System;

namespace Common.Core.Contracts.Interfaces
{
    public interface ICompressor
    {
        string DecompressBase64(string compressedText);
        string CompressBase64(string text);
        void Dispose();
    }
}
