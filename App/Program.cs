using System.Text.RegularExpressions;
using App.Constants;
using App.Utils;

Regex regex = new Regex(CommonInfo.RegexPatternForInput);

while (true)
{
    try
    {
        Console.Write(Messages.InputInquiry);
        var input = Console.ReadLine() ?? string.Empty;

        if (!regex.IsMatch(input))
            throw new InvalidOperationException(Messages.InvalidChars);

        if (input.Last() != OldPhoneHelper.HashAsSend)
            throw new InvalidOperationException(Messages.InvalidLastChar);

        Console.WriteLine(string.Format(Messages.OutputResult, OldPhoneHelper.OldPhonePad(input)));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
