namespace Aspiron.MVC.Contracts
{
    public interface ITranslationService
    {
        public bool SetLanguage(string language);
        public string GetLanguage();

        public Task<string> GetTranslationAsync(string? key, string? defaultValue = null);
        public Task<string> SetTranslationAsync(string key, string value, string language);
    }
}
