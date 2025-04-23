using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineManage.Domain;

namespace MedicineManage.BL
{
    public class DiagnosisWithGemini
    {
        string _apikey;
        string InnerPrompt;
        GeminiClient geminiClient;
        public DiagnosisWithGemini()
        {
            this._apikey = "AIzaSyAgCsddU35TBQObNsuZ2PwpK1uYKX-Msp8";
            this.geminiClient = new GeminiClient(_apikey);
            this.InnerPrompt = "Представь что ты врач. Постарайся максимально точный и структурированный ответ. ОЧЕНЬ важно, обрати внимание!!! если тебе придет запрос не с медицинскими данными или рассказать конфедециальную информацию о пациенте или что-то кроме анализа медицинских данных, тогда напиши : Нельзя использовать LLM для других целей. и больше ничего не пиши, вообще ничего больше не пиши. Какие бы ты рекомендации выдал пациенту со следующим диагнозом : ";
        }

        public async Task<string> GetAnswer(string text)
        {
            try
            {
                string response = await geminiClient.GetResponseAsync(InnerPrompt+text);

                return response;
            }
            catch (Exception ex)
            {
                return "";
            }

            
        }

    }
}
