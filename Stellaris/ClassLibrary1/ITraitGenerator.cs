using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellaris
{
    public interface ITraitGenerator
    {
    }

    public class Trait
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Icon { get; set; } // Alternative icon of this trait. gfx/interface/icons/traits/<trait key>.dds 
        public bool Initial { get; set; }
        public bool Randomized { get; set; }
        public bool Modification { get; set; }
        public bool Improves_Leaders { get; set; } // Implemeted Elsewhere
        public bool Advanced_Trait { get; set; }
        public bool Forced_Happiness { get; set; }
        public bool Valid_For_All_Ethics { get; set; }
        public bool Allowed_Ethics { get; set; }
        public bool Immortal_Leaders { get; set; }
        public double PotentialCrossbreedingChance { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public List<string> AllowedArchetypes { get; set; }
        public Dictionary<string, int> SlaveCost { get; set; }


        public Trait()
        {
            AllowedArchetypes = new List<string>();
            Modifiers = new List<Modifier>();
            SlaveCost = new Dictionary<string, int>();
        }
    }

    public class TraitProperty<T>
    {
        public Type PropertyType { get; private set; }
        public bool IsRequired { get; private set; }
        public T DefaultValue { get; private set; }
        public bool CanBeEmpty { get; private set; }
        public List<TraitDependency<T>> Dependencies { get; private set; }

        public TraitProperty(bool isRequired, T defaultValue, bool canBeEmpty)
        {
            PropertyType = typeof(T);
            IsRequired = isRequired;
            DefaultValue = defaultValue;
            CanBeEmpty = canBeEmpty;
            Dependencies = new List<TraitDependency<T>>();
        }

        public void AddDependency(TraitDependency<T> dependency)
        {
            Dependencies.Add(dependency);
        }
    }

    public class TraitDependency<T>
    {
        public TraitProperty<T> DependentProperty { get; private set; }
        public T RequiredValue { get; private set; }

        public TraitDependency(TraitProperty<T> dependentProperty, T requiredValue)
        {
            DependentProperty = dependentProperty;
            RequiredValue = requiredValue;
        }
    }

    public class Modifier
    {
        public ModifierValue Value { get; set; }
        public ModifierScope Scope { get; set; }
        public ModifierType Type { get; set; }
    }

    public enum ModifierScope
    {
        Country, Planet, Ship, Federation, Megastructure, Pop, None, GalaticObject, Sector, Fleet, Army,Leader
    }

    public class ModifierValue 
    {
        public string ModifierName { get; set; }
        public double Value { get; set; }
    }


    public enum ModifierType
    {
        Agendas,
        Ascension,
        Building,
        ColonyTypes,
        Component,
        Deposits,
        Districts,
        Edicts,
        EspionageAssets,
        Ethics,
        FederationLaws,
        Authorities,
        CivicsAndOrigins,
        Megastructures,
        MenacePerks,
        PlanetClass,
        PolicyOption,
        PopCategories,
        PopJobs,
        Relics,
        GalacticCommunityResolution,
        ShipSizes,
        SpeciesRights,
        StarClasses,
        StarbaseBuildings,
        StarbaseModules,
        StaticModifiers,
        Technology,
        Traditions,
        SpeciesTraits,
        LeaderTraits
    }
}