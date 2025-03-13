using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Contracts
{
    public interface ITranslationService
    {
        public bool SetLanguage(string language);
        public string GetLanguage();

        public Task<string> GetTranslation(string key, string? defaultValue = null);
        public Task<string> SetTranslation(string key, string language);
    }
}
