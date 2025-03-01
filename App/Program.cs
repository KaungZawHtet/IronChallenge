using App;

while (true)
{
    Console.WriteLine("Enter Number:");
    var number = Console.ReadLine();
    Console.WriteLine($"{OldPhoneHelper.OldPhonePad(number)}");
}
