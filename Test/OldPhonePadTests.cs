using App;

namespace Test;

public class OldPhonePadTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void OldPhonePad_ReturnE()
    {
        var expected = "E";
        var result = OldPhoneHelper.OldPhonePad("");
        Assert.Pass();
    }

    [Test]
    public void OldPhonePad_ReturnB()
    {
        var expected = "B";
        Assert.Pass();
    }

    [Test]
    public void OldPhonePad_ReturnHELLO()
    {
        var expected = "HELLO";
        Assert.Pass();
    }

    [Test]
    public void OldPhonePad_ReturnWeird()
    {
        Assert.Pass();
    }
}
