using System.Text.RegularExpressions;
using App.Constants;
using App.Utils;

Regex regex = new Regex(CommonInfo.RegexPatternForInput);

while (true)
{
    try
    {
        Console.Write("Enter Number : ");
        var input = Console.ReadLine() ?? string.Empty;

        if (!regex.IsMatch(input))
            throw new InvalidOperationException(Messages.InvalidChars);

        if (input.Last() is not '#')
            throw new InvalidOperationException(Messages.InvalidLastChar);

        Console.WriteLine($"Output : {OldPhoneHelper.OldPhonePad(input)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
