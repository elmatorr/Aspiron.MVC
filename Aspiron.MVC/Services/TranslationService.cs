using Aspiron.MVC.Contracts;

namespace Aspiron.MVC.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ICacheProvider _cacheProvider;
        private string _language = "ENG";

        public TranslationService(ICacheProvider cache)
        {
            _cacheProvider = cache;
        }

        public string GetLanguage()
        {
            return _language;
        }

        public Task<string> GetTranslationAsync(string? key, string? defaultValue = null)
        {
            // TODO implement cache

            if (string.IsNullOrEmpty(key))
            {
                return Task.FromResult("");
            }

            // Simulate a translation lookup, proof of concept that translation is working
            if (key == "Id")
            {
                return Task.FromResult("Key field");
            }

            return Task.FromResult(defaultValue ?? "N/A");
        }

        public bool SetLanguage(string language)
        {
            if (string.IsNullOrEmpty(language))
            {
                _language = language;
                return true;
            }
            return false;
        }

        public Task<string> SetTranslationAsync(string key, string value, string language)
        {
            throw new NotImplementedException();
        }
    }
}
