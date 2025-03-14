using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporer_Shared.Models.AI
{
    public record CreateAssistantsPayload(
        string name,
        int temperature,
        bool isFileSearch,
        bool isCodeInterpreter,
        string? instructions = null
    );
}
