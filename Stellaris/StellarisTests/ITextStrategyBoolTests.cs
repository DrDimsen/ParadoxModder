using Stellaris;
using Stellaris.Traits;

namespace StellarisTests;

public class ITextStrategyBoolTests
{
    private ITextStrategy<bool> writter;
    public ITextStrategyBoolTests()
    {
        writter = new TextBoolStrategy();
    }

    [Fact]
    public void WriterShouldBeCreated()
    {
        Assert.True(writter != null);
    }

    [Fact]
    public void IfValueIsDefaultAndIsntRequiredReturnEmpty()
    {
        TraitProperty<bool> prop  = new TraitProperty<bool>(false, true, "initial");
        var result = writter.Write(prop);
        Assert.Empty(result);
    }

    [Fact]
    public void IfFieldIsRequiredButNotChangedReturnText()
    {
        TraitProperty<bool> prop  = new TraitProperty<bool>(true, true, "initial");
        var result = writter.Write(prop);
        Assert.Equal("initial = yes", result);
    }
    
    [Fact]
    public void IfFieldIsChangedReturnText()
    {
        TraitProperty<bool> prop  = new TraitProperty<bool>(false, true, "initial");
        prop.SetValue(false);
        var result = writter.Write(prop);
        Assert.Equal("initial = no", result);
    }
}