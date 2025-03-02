using App.Constants;

namespace App.Utils;

public static class OldPhoneHelper
{
    private const string starAsDelete = "*";
    private const string hashAsSend = "#";
    private const string space = " ";

    private static readonly Dictionary<char, char[]> numberDict = new()
    {
        { '1', new char[] { '&', '\'', ')' } },
        { '2', new char[] { 'A', 'B', 'C' } },
        { '3', new char[] { 'D', 'E', 'F' } },
        { '4', new char[] { 'G', 'H', 'I' } },
        { '5', new char[] { 'J', 'K', 'L' } },
        { '6', new char[] { 'M', 'N', 'O' } },
        { '7', new char[] { 'P', 'Q', 'R', 'S' } },
        { '8', new char[] { 'T', 'U', 'V' } },
        { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
    };

    private static char? RetrieveCharacter(string charGroup)
    {
        var distinctCharGroup = charGroup.Distinct().ToList();

        if (distinctCharGroup.Count() is not CommonInfo.RightDistrictCount)
            throw new InvalidOperationException(Messages.InvalidCharGroupErrorMessage);

        var key = charGroup.First();

        if (!numberDict.ContainsKey(key))
            return null;

        var targetIndex = (charGroup.Length - 1) % numberDict[key].Length;

        return numberDict[key][targetIndex];
    }

    public static string OldPhonePad(string input)
    {
        LinkedList<char> charLinkedList = new();
        var craftedInput = input.Aggregate(
            new List<string>(),
            (accumulator, next) =>
            {
                if (accumulator.Count == 0 || accumulator.Last().First() != next)
                {
                    accumulator.Add($"{next}");
                }
                else
                {
                    accumulator[accumulator.Count - 1] += next;
                }

                return accumulator;
            }
        );

        foreach (var item in craftedInput)
        {
            if (item == starAsDelete)
            {
                charLinkedList.RemoveLast();
            }
            else if (item == space)
            {
                continue;
            }
            else if (item == hashAsSend)
            {
                break; //  This treat hash as final send button by ignoring all input after send button.
            }
            else
            {
                if (RetrieveCharacter(item) is { } alpha)
                    charLinkedList.AddLast(alpha);
            }
        }
        return string.Concat(charLinkedList);
    }
}
