using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_AI.Models
{
    public record TrainingData(string? systemMessage, string? question, string? answer);
}
