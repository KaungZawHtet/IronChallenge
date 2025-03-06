using System.Text;
using App.Constants;

namespace App.Utils;

public static class OldPhoneHelper
{
    private const char StarAsDelete = '*';
    public const char HashAsSend = '#';
    private const char SpaceAsSeparator = ' ';

    //This way of keeping 0, 1, 2, 3 ... may be controversial and can say over-engineered in some perspectives. But for this moment, I choose to keep like this.
    private const char Zero = '0';
    private const char One = '1';
    private const char Two = '2';
    private const char Three = '3';
    private const char Four = '4';
    private const char Five = '5';
    private const char Six = '6';
    private const char Seven = '7';
    private const char Eight = '8';
    private const char Nine = '9';

    private static readonly Dictionary<char, char[]> NaturalNumberDict = new()
    {
        { One, new char[] { '&', '\'', '(' } },
        { Two, new char[] { 'A', 'B', 'C' } },
        { Three, new char[] { 'D', 'E', 'F' } },
        { Four, new char[] { 'G', 'H', 'I' } },
        { Five, new char[] { 'J', 'K', 'L' } },
        { Six, new char[] { 'M', 'N', 'O' } },
        { Seven, new char[] { 'P', 'Q', 'R', 'S' } },
        { Eight, new char[] { 'T', 'U', 'V' } },
        { Nine, new char[] { 'W', 'X', 'Y', 'Z' } },
    };

    private static char? RetrieveCharacter(string charGroup)
    {
        var distinctCharGroup = charGroup.Distinct().ToList();

        if (distinctCharGroup.Count() is not CommonInfo.RightDistinctCount)
            throw new InvalidOperationException(Messages.InvalidCharGroupErrorMessage);

        var key = charGroup.First();

        if (!NaturalNumberDict.ContainsKey(key))
            return null;

        var targetIndex = (charGroup.Length - 1) % NaturalNumberDict[key].Length; // Circular indexing

        return NaturalNumberDict[key][targetIndex];
    }

    private static List<StringBuilder> SeparateSameCharSequenceIntoList(string input) =>
        input.Aggregate(
            new List<StringBuilder>(),
            (accumulator, next) =>
            {
                if (accumulator.Count is 0 || accumulator.Last()[0] != next)
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
            if (currentSegmentedInput[0] is StarAsDelete && alphabetList.Any())
            {
                var ZeroGroup = currentSegmentedInput.ToString();
                foreach (var item in ZeroGroup)
                {
                    if (!alphabetList.Any())
                        break;
                    alphabetList.RemoveLast();
                }
            }
            else if (currentSegmentedInput[0] is SpaceAsSeparator)
            {
                continue;
            }
            else if (currentSegmentedInput[0] is Zero)
            {
                var zeroGroup = currentSegmentedInput.ToString();
                foreach (var item in zeroGroup)
                {
                    alphabetList.AddLast(SpaceAsSeparator);
                }
            }
            else if (currentSegmentedInput[0] is HashAsSend)
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
