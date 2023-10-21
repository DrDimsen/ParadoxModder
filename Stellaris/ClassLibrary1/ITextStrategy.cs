using Stellaris.Traits;

namespace Stellaris;

public interface ITextStrategy<T>
{
    string Write(TraitProperty<T> property);
}