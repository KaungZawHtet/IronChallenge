using App.Utils;

namespace Test;

public class OldPhonePadTests
{
    [Test]
    [Description("This unit test checks whether E from code challenge is ok.")]
    public void OldPhonePad_ReturnE()
    {
        var expected = "E";
        var input = "33#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether B from code challenge is ok.")]
    public void OldPhonePad_ReturnB()
    {
        var expected = "B";
        var input = "227*#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether HELLO from code challenge is ok.")]
    public void OldPhonePad_ReturnHELLO()
    {
        var expected = "HELLO";
        var input = "4433555 555666#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether TURING from code challenge is ok.")]
    public void OldPhonePad_ReturnTURING()
    {
        var expected = "TURING";
        var input = "8 88777444666*664#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether double send buttons is ok.")]
    public void OldPhonePad_IgnoringAllAfterSend()
    {
        var expected = "E";
        var input = "33#33#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether including both of space internal and 0 is ok.")]
    public void OldPhonePad_AllSpaceStarZeroInclude()
    {
        var expected = "HEE HEE";
        var input = "4433 3304433 33#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether including only one star and send button is ok.")]
    public void OldPhonePad_OnlyStar()
    {
        var expected = string.Empty;
        var input = "*#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether including only one send button is ok.")]
    public void OldPhonePad_OnlySend()
    {
        var expected = string.Empty;
        var input = "#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description(
        "This unit test checks whether removing back multiple chars with multiple stars is ok."
    )]
    public void OldPhonePad_MultipleStarToRemoveChars()
    {
        var expected = "K";
        var input = "223344***55#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [Description("This unit test checks whether multiple stars input is ok.")]
    public void OldPhonePad_OnlyMultipleStars()
    {
        var expected = string.Empty;
        var input = "***#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}
