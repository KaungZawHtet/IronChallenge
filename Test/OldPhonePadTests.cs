using App;
using App.Utils;

namespace Test;

public class OldPhonePadTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void OldPhonePad_ReturnE()
    {
        var expected = "E";
        var input = "33#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void OldPhonePad_ReturnB()
    {
        var expected = "B";
        var input = "227*#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void OldPhonePad_ReturnHELLO()
    {
        var expected = "HELLO";
        var input = "4433555 555666#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void OldPhonePad_ReturnWeird()
    {
        var expected = "TURING";
        var input = "8 88777444666*664#";
        var result = OldPhoneHelper.OldPhonePad(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}
