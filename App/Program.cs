using App;
using App.Utils;

while (true)
{
    Console.WriteLine("Enter Number:");
    var input = Console.ReadLine() ?? string.Empty;
    Console.WriteLine($"Output : {OldPhoneHelper.OldPhonePad(input)}");
}
