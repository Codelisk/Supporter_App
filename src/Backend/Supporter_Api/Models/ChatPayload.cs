namespace Supporter_Api.Models
{
    public record ChatPayload(
        string question,
        string threadId,
        string assistantId,
        float? temperature
    );
}
