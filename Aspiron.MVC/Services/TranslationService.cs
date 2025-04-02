using Aspiron.MVC.Contracts;

namespace Aspiron.MVC.Services
{
    public class TranslationService : ITranslationService
    {
        public string GetLanguage()
        {
            return "ENG";
        }

        public Task<string> GetTranslation(string key, string? defaultValue = null)
        {
            return Task.FromResult(defaultValue ?? "N/A");
        }

        public bool SetLanguage(string language)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetTranslation(string key, string value, string language)
        {
            throw new NotImplementedException();
        }
    }
}
