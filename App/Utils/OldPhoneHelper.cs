using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Constants;

namespace App.Utils;

public static class OldPhoneHelper
{
    public static readonly Dictionary<char, string[]> data = new()
    {
        { '1', new string[] { "&", "'", ")" } },
        { '2', new string[] { "A", "B", "C" } },
        { '3', new string[] { "D", "E", "F" } },
        { '4', new string[] { "G", "H", "I" } },
        { '5', new string[] { "J", "K", "L" } },
        { '6', new string[] { "M", "N", "O" } },
        { '7', new string[] { "P", "Q", "R", "S" } },
        { '8', new string[] { "T", "U", "V" } },
        { '9', new string[] { "W", "X", "Y", "Z" } },
        { '0', new string[] { " " } },
        { '>', new string[] { "#" } },
        { '*', [] },
    };

    public static string RetrieveCharacter(string charGroup)
    {
        var distinctCharGroup = charGroup.Distinct().ToList();

        if (distinctCharGroup.Count() is not CommonInfo.RightDistrictCount)
            throw new InvalidOperationException(Messages.InvalidCharGroupErrorMessage);

        var key = charGroup.First();

        if (!data.ContainsKey(key))
            throw new InvalidOperationException(Messages.KeyNotFoundErrorMessage);

        var targetIndex = (charGroup.Length - 1) % data[key].Length;

        return data[key][targetIndex];
    }

    public static string OldPhonePad(string input)
    {
        return input;
    }
}
