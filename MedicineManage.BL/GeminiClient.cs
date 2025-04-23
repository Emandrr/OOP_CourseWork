using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedicineManage.BL
{
    public class GeminiClient
    {
        private readonly string _apiKey;
        private readonly string _modelName;
        private readonly HttpClient _httpClient;

        
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";

        /// <summary>
        /// Инициализирует новый экземпляр класса GeminiClient.
        /// </summary>
        /// <param name="apiKey">API ключ для доступа к Gemini API.</param>
        /// <param name="modelName">Название модели (по умолчанию "gemini-pro").</param>
        public GeminiClient(string apiKey, string modelName = "gemini-1.5-flash")
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _modelName = modelName ?? throw new ArgumentNullException(nameof(modelName));
            _httpClient = new HttpClient();
        }

        /// <summary>

        public async Task<string> GetResponseAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Prompt cannot be empty", nameof(prompt));
            }

            var requestUrl = $"{BaseUrl}{_modelName}:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = prompt
                        }
                    }
                }
            }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObject = JsonDocument.Parse(responseJson);

                // Извлекаем текст ответа из JSON структуры
                var textResponse = responseObject.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                return textResponse ?? "No response text found";
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error calling Gemini API: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error parsing Gemini API response: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}", ex);
            }
        }
    }
}
