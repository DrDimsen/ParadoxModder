using Stellaris;
using Stellaris.Traits;

namespace StellarisTests;

public class IDoubleTextWritterTests
{
    public ITextStrategy<double> writter;

    public IDoubleTextWritterTests()
    {
        this.writter = new TextDoubleStrategy();
    }

    [Fact]
    public void CreatingAWritterShouldSucceed()
    {
        Assert.True(writter != null);
    }
    
    [Fact]
    public void IfValueIsDefaultAndIsntRequiredReturnEmpty()
    {
        TraitProperty<double> prop  = new TraitProperty<double>(false, 5, "initial");
        var result = writter.Write(prop);
        Assert.Empty(result);
    }
    
    [Fact]
    public void IfFieldIsRequiredButNotChangedReturnText()
    {
        TraitProperty<double> prop  = new TraitProperty<double>(true, 5, "initial");
        var result = writter.Write(prop);
        Assert.Equal("initial = 5", result);
    }
    
    [Fact]
    public void IfFieldIsChangedReturnText()
    {
        TraitProperty<double> prop  = new TraitProperty<double>(false, 5, "initial");
        prop.SetValue(2);
        var result = writter.Write(prop);
        Assert.Equal("initial = 2", result);
    }
}