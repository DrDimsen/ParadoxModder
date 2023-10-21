using Stellaris;
using Stellaris.Traits;

namespace StellarisTests;

public class IIntTextWritterTests
{
    public ITextStrategy<int> writter;

    public IIntTextWritterTests()
    {
        this.writter = new TextIntStrategy();
    }

    [Fact]
    public void CreatingAWritterShouldSucceed()
    {
        Assert.True(writter != null);
    }
    
    [Fact]
    public void IfValueIsDefaultAndIsntRequiredReturnEmpty()
    {
        TraitProperty<int> prop  = new TraitProperty<int>(false, 5, true, "initial");
        var result = writter.Write(prop);
        Assert.Empty(result);
    }
    
    [Fact]
    public void IfFieldIsRequiredButNotChangedReturnText()
    {
        TraitProperty<int> prop  = new TraitProperty<int>(true, 5, true, "initial");
        var result = writter.Write(prop);
        Assert.Equal("initial = 5", result);
    }
    
    [Fact]
    public void IfFieldIsChangedReturnText()
    {
        TraitProperty<int> prop  = new TraitProperty<int>(false, 5, true, "initial");
        prop.SetValue(2);
        var result = writter.Write(prop);
        Assert.Equal("initial = 2", result);
    }
}