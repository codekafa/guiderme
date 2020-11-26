using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Infrastructure
{
    public interface IDocumentService
    {

        byte[] GetByteDocument(string filePath);

        string GetStringDocument(string filePath);
    }
}
