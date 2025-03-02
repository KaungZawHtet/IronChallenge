using System.Text;
using App.Constants;

namespace App.Utils;

public static class OldPhoneHelper
{
    private const char starAsDelete = '*';
    public const char hashAsSend = '#';
    private const char spaceAsInterval = ' ';

    //This way of keeping 0, 1, 2, 3 ... may be controversial and can say over-engineered in some perspectives. But for this moment, I choose to keep like this.
    private const char zero = '0';
    private const char one = '1';
    private const char two = '2';
    private const char three = '3';
    private const char four = '4';
    private const char five = '5';
    private const char six = '6';
    private const char seven = '7';
    private const char eight = '8';
    private const char nine = '9';

    private static readonly Dictionary<char, char[]> numberDict = new()
    {
        { one, new char[] { '&', '\'', '(' } },
        { two, new char[] { 'A', 'B', 'C' } },
        { three, new char[] { 'D', 'E', 'F' } },
        { four, new char[] { 'G', 'H', 'I' } },
        { five, new char[] { 'J', 'K', 'L' } },
        { six, new char[] { 'M', 'N', 'O' } },
        { seven, new char[] { 'P', 'Q', 'R', 'S' } },
        { eight, new char[] { 'T', 'U', 'V' } },
        { nine, new char[] { 'W', 'X', 'Y', 'Z' } },
        { zero, new char[] { ' ' } },
    };

    private static char? RetrieveCharacter(string charGroup)
    {
        var distinctCharGroup = charGroup.Distinct().ToList();

        if (distinctCharGroup.Count() is not CommonInfo.RightDistinctCount)
            throw new InvalidOperationException(Messages.InvalidCharGroupErrorMessage);

        var key = charGroup.First();

        if (!numberDict.ContainsKey(key))
            return null;

        var targetIndex = (charGroup.Length - 1) % numberDict[key].Length;

        return numberDict[key][targetIndex];
    }

    private static List<StringBuilder> SeparateSameCharSequenceIntoList(string input) =>
        input.Aggregate(
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

    private static LinkedList<char> ConvertSameCharSequenceListIntoAlphabetTrain(
        List<StringBuilder> segmentedInputList
    )
    {
        LinkedList<char> alphabetList = new();

        foreach (var currentSegmentedInput in segmentedInputList)
        {
            if (currentSegmentedInput[0] == starAsDelete && alphabetList.Any())
            {
                alphabetList.RemoveLast();
            }
            else if (currentSegmentedInput[0] == spaceAsInterval)
            {
                continue;
            }
            else if (currentSegmentedInput[0] == zero)
            {
                var zeroGroup = currentSegmentedInput.ToString();
                foreach (var item in zeroGroup)
                {
                    alphabetList.AddLast(numberDict[zero].First());
                }
            }
            else if (currentSegmentedInput[0] == hashAsSend)
            {
                break; //  This treats hash as final send button by ignoring all input after send button.
            }
            else
            {
                if (RetrieveCharacter(currentSegmentedInput.ToString()) is { } alpha)
                    alphabetList.AddLast(alpha);
            }
        }
        return alphabetList;
    }

    // Here, this is the main code challange function
    public static string OldPhonePad(string input)
    {
        var segmentedInputList = SeparateSameCharSequenceIntoList(input);
        return string.Concat(ConvertSameCharSequenceListIntoAlphabetTrain(segmentedInputList));
    }
}
