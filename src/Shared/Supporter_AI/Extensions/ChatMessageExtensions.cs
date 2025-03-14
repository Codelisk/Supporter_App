using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging;
using OpenAI.Assistants;
using OpenAI.Chat;

namespace Supporter_AI.Extensions
{
    public static class ChatMessageExtensions
    {
        public static List<OpenAI.Assistants.MessageContent> ToMessageContent(
            this ChatMessageContent chatMessageContentParts
        )
        {
            List<OpenAI.Assistants.MessageContent> result = new();
            foreach (var item in chatMessageContentParts)
            {
                if (!string.IsNullOrEmpty(item.Text))
                {
                    result.Add(OpenAI.Assistants.MessageContent.FromText(item.Text));
                }
                //Todo add image
            }
            return result;
        }

        public static MessageRole GetRole(this ChatMessage chatMessage)
        {
            if (chatMessage is UserChatMessage)
            {
                return MessageRole.User;
            }
            else if (chatMessage is AssistantChatMessage)
            {
                return MessageRole.Assistant;
            }
            else if (chatMessage is ToolChatMessage)
            {
                return MessageRole.Assistant;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
