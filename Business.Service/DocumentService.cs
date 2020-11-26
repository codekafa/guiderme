using Business.Service.Infrastructure;
using System;

namespace Business.Service
{
    public class DocumentService : IDocumentService
    {
        public byte[] GetByteDocument(string filePath)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            return bytes;
        }

        public string GetStringDocument(string filePath)
        {
            string text = System.IO.File.ReadAllText(filePath);
            return text;
        }
    }
}
