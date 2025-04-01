using Aspiron.MVC.Contracts;
using Aspiron.MVC.Domain;
using System.Text.Json;

namespace Aspiron.MVC.Repositories
{
    public class ConfigFileRepository : IConfigRepository
    {
        private string _configDirectory;

        public ConfigFileRepository(string configDirectory) 
        {
            _configDirectory = configDirectory;
        }

        public Task<List<ConfigListItem>> GetAllAsync()
        {
            // Get all files that match the pattern
            var files = Directory.GetFiles(_configDirectory, $"*.v*.json");

            var result = new List<ConfigListItem>();

            foreach (var file in files)
            {
                // Read the JSON content from the file
                var json = System.IO.File.ReadAllText(file);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                // Deserialize the JSON content into a BaseBrowserPageModel object
                var pageConfig = JsonSerializer.Deserialize<BaseBrowserPageModel>(json, options);

                // Create a ConfigListItem with the filename as key and name
                var configListItem = new ConfigListItem
                {
                    Key = Path.GetFileName(file),
                    Name = Path.GetFileName(file)
                };

                result.Add(configListItem);
            }

            return Task.FromResult(result);
        }

        public async Task<BaseBrowserPageModel> GetConfigValueAsync(string operationName)
        {
            // Get all files that match the pattern
            var files = Directory.GetFiles(_configDirectory, $"{operationName}.v*.json");

            if (files.Length == 0)
            {
                return new BaseBrowserPageModel { };
            }

            // Extract version numbers and find the highest one
            var highestVersionFile = files
                .Select(file => new
                {
                    FilePath = file,
                    Version = int.Parse(Path.GetFileNameWithoutExtension(file)
                        .Split('.')
                        .Last()
                        .Substring(1)) // Remove the 'v' prefix
                })
                .OrderByDescending(file => file.Version)
                .First();

            // Read the JSON content from the file with the highest version
            var json = await System.IO.File.ReadAllTextAsync(highestVersionFile.FilePath);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Deserialize the JSON content into a BaseBrowserPageModel object
            var pageConfig = JsonSerializer.Deserialize<BaseBrowserPageModel>(json, options);

            return pageConfig;
        }

        public async Task<bool> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            try
            {
                // Serialize to JSON
                var json = JsonSerializer.Serialize(pageModel, options);

                // Ensure the directory exists
                if (!Directory.Exists(_configDirectory))
                {
                    Directory.CreateDirectory(_configDirectory);
                }

                // Save to file
                var filePath = Path.Combine(_configDirectory, $"{operationName}.v{pageModel.Version}.json");
                await System.IO.File.WriteAllTextAsync(filePath, json);

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
