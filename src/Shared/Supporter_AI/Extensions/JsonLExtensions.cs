using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenAI.Chat;
using OpenAI.RealtimeConversation;
using Supporter_AI.Models;

namespace Supporter_AI.Extensions
{
    public static class JsonLExtensions
    {
        public static byte[] ToJsonlBinary(this List<TrainingData> daten)
        {
            StringBuilder sb = new StringBuilder();

            var jsonlObjekt = new { messages = new List<object>() };
            foreach (var eintrag in daten)
            {
                if (string.IsNullOrEmpty(eintrag.question))
                {
                    jsonlObjekt.messages.Add(new { role = "user", content = eintrag.question });
                }
                else if (string.IsNullOrEmpty(eintrag.answer))
                {
                    jsonlObjekt.messages.Add(new { role = "assistant", content = eintrag.answer });
                }
                else if (!string.IsNullOrEmpty(eintrag.question))
                {
                    jsonlObjekt.messages.Add(
                        new { role = "system", content = eintrag.systemMessage }
                    );
                }
                else
                {
                    throw new ArgumentNullException();
                }

                string jsonZeile = System.Text.Json.JsonSerializer.Serialize(jsonlObjekt);
                sb.AppendLine(jsonZeile);
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
