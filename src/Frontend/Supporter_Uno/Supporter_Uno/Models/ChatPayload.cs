using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Models;

public record ChatPayload(string question, string threadId, string assistantId, float? temperature);
