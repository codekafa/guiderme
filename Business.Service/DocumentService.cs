using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Business.Service
{
    public class DocumentService : IDocumentService
    {
        public DocumentService(IHostingEnvironment env)
        {
        }

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
