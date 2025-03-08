using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Models;

public record AISettings(
    string Model,
    string Description,
    string Instructions,
    double? Temperature,
    double? NucleusSamplingFactor
);
