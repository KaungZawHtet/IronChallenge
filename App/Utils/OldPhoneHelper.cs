using System.Text;
using App.Constants;

namespace App.Utils;

public static class OldPhoneHelper
{
    private const char starAsDelete = '*';
    public const char hashAsSend = '#';
    private const char space = ' ';

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
        LinkedList<char> alphabetList = new();
        var segmentedInputList = input.Aggregate(
            new List<StringBuilder>(),
            (accumulator, next) =>
            {
                if (accumulator.Count == 0 || accumulator.Last()[0] != next)
                {
                    accumulator.Add(new StringBuilder($"{next}"));
                }
                else
                {
                    accumulator[accumulator.Count - 1].Append(next);
                }

                return accumulator;
            }
        );

        foreach (var currentSegmentedInput in segmentedInputList)
        {
            if (currentSegmentedInput[0] == starAsDelete)
            {
                alphabetList.RemoveLast();
            }
            else if (currentSegmentedInput[0] == space)
            {
                continue;
            }
            else if (currentSegmentedInput[0] == hashAsSend)
            {
                break; //  This treat hash as final send button by ignoring all input after send button.
            }
            else
            {
                if (RetrieveCharacter(currentSegmentedInput.ToString()) is { } alpha)
                    alphabetList.AddLast(alpha);
            }
        }
        return string.Concat(alphabetList);
    }
}
