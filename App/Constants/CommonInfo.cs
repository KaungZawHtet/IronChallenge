using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Constants;

public static class CommonInfo
{
    public const int RightDistinctCount = 1;

    public const string RegexPatternForInput = @"^[0-9 *#]*$"; //By using this regex pattern, we only allow number, space, * and #
}
