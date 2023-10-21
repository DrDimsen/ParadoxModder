using Stellaris;
using Stellaris.Traits;

namespace StellarisTests;

public class IStringTextWritterTests
{
    public ITextStrategy<string> writter;

    public IStringTextWritterTests()
    {
        this.writter = new TextStringStrategy();
    }

    [Fact]
    public void CreatingAWritterShouldSucceed()
    {
        Assert.True(writter != null);
    }
    
    [Fact]
    public void IfValueIsDefaultAndIsntRequiredReturnEmpty()
    {
        TraitProperty<string> prop  = new TraitProperty<string>(false, "5", true, "initial");
        var result = writter.Write(prop);
        Assert.Empty(result);
    }
    
    [Fact]
    public void IfFieldIsRequiredButNotChangedReturnText()
    {
        TraitProperty<string> prop  = new TraitProperty<string>(true, "hello", true, "initial");
        var result = writter.Write(prop);
        Assert.Equal("initial = hello", result);
    }
    
    [Fact]
    public void IfFieldIsChangedReturnText()
    {
        TraitProperty<string> prop  = new TraitProperty<string>(false, "123", true, "initial");
        prop.SetValue("hello");
        var result = writter.Write(prop);
        Assert.Equal("initial = hello", result);
    }
}