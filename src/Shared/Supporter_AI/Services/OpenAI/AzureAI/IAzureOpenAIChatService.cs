using System.ClientModel;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;

namespace Supporter_AI.Services.OpenAI.AzureAI
{
    /// <summary>
    /// Interface für den Zugriff auf OpenAI-Chatfunktionen über Azure AI.
    /// </summary>
    public interface IAzureOpenAIChatService
    {
        /// <summary>
        /// Erstellt einen neuen Assistenten mit den angegebenen Optionen.
        /// </summary>
        /// <param name="name">Der Name des Assistenten.</param>
        /// <param name="temperature">Die Temperatur für den Assistenten (Steuerung der Kreativität der Antworten).</param>
        /// <returns>Ein ClientResult-Objekt, das den Assistenten enthält.</returns>
        Task<ClientResult<Assistant>> CreateAssistant(string name, int temperature);

        /// <summary>
        /// Erstellt einen neuen Thread für eine Konversation zu einem bestimmten Thema.
        /// </summary>
        /// <param name="threadId">Die ID des Threads (wird zum Erstellen des Threads verwendet).</param>
        /// <returns>Ein ClientResult-Objekt, das den neu erstellten Thread enthält.</returns>
        Task<ClientResult<AssistantThread>> CreateThreadAsync(string threadId);

        /// <summary>
        /// Erstellt einen Run für den angegebenen Thread, um z.B. die Einstellungen zu ändern (z. B. Temperatur oder Assistenten).
        /// </summary>
        /// <param name="threadId">Die ID des Threads, in dem der Run erstellt werden soll.</param>
        /// <param name="assistantId">Die ID des Assistenten, der für den Run verwendet wird.</param>
        /// <param name="temp">Die Temperatur, die für den Run eingestellt werden soll (optional).</param>
        /// <returns>Ein ClientResult-Objekt, das den erstellten Run enthält.</returns>
        Task<ClientResult<ThreadRun>> CreateRunAsync(
            string threadId,
            string assistantId,
            float? temp
        );

        /// <summary>
        /// Sendet eine Chat-Nachricht (Frage) an einen Thread und erhält die Antwort des Assistenten.
        /// </summary>
        /// <param name="question">Die Frage oder Nachricht des Benutzers.</param>
        /// <param name="threadId">Die ID des Threads, an den die Nachricht gesendet wird.</param>
        /// <param name="assistantId">Die ID des Assistenten, der auf die Nachricht antworten soll.</param>
        /// <param name="temperature">Die Temperatur für die Antwort (optional, beeinflusst die Kreativität der Antwort).</param>
        /// <returns>Ein ClientResult-Objekt, das die Antwort des Assistenten enthält.</returns>
        Task<ClientResult<ThreadRun>> Chat(
            string question,
            string threadId,
            string assistantId,
            float? temperature
        );

        /// <summary>
        /// Sendet eine Frage an den Chat-Assistenten und erhält eine Antwort.
        /// </summary>
        /// <param name="question">Die Frage, die an den Assistenten gestellt wird.</param>
        /// <returns>Die Antwort des Assistenten als String.</returns>
        Task<string> Chat(string question);
    }
}
