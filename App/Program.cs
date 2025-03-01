using App;

while (true)
{
    Console.WriteLine("Enter Number:");
    var number = Console.ReadLine() ?? string.Empty;
    Console.WriteLine($"{OldPhoneHelper.OldPhonePad(number)}");
}
