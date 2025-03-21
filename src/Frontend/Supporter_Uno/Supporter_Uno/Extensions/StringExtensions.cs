using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Extensions;

internal static class StringExtensions
{
    public static List<string> SplitText(this string text, int maxLength)
    {
        var parts = new List<string>();
        for (int i = 0; i < text.Length; i += maxLength)
        {
            parts.Add(text.Substring(i, Math.Min(maxLength, text.Length - i)));
        }
        return parts;
    }
}
