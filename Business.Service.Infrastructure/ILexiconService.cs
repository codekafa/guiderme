using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service.Infrastructure
{
    public interface ILexiconService
    {
        string GetAlertSring(string key, string culture);

        string GetTextValue(string key, int page_code);
    }
}
