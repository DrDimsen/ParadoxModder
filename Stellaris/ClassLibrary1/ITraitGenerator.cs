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
 public TraitProperty<string> Name { get; set; } = new TraitProperty<string>(false, "New_Trait", true);
    public TraitProperty<int> Cost { get; set; } = new TraitProperty<int>(false, 0, true);
    public TraitProperty<bool> Initial { get; set; } = new TraitProperty<bool>(false, true, true);
    public TraitProperty<bool> Randomized { get; set; } = new TraitProperty<bool>(false, true, true);
    public TraitProperty<bool> Modification { get; set; } = new TraitProperty<bool>(false, true, true);
    public TraitProperty<bool> Improves_Leaders { get; set; } = new TraitProperty<bool>(false, false, true); 
    public TraitProperty<bool> Advanced_Trait { get; set; } = new TraitProperty<bool>(false, false, true);
    public TraitProperty<bool> Forced_Happiness { get; set; } = new TraitProperty<bool>(false, false, true);
    public TraitProperty<bool> Valid_For_All_Ethics { get; set; } = new TraitProperty<bool>(false, true, true);
    public TraitProperty<bool> Immortal_Leaders { get; set; } = new TraitProperty<bool>(false, false, true);
    public TraitProperty<double> PotentialCrossbreedingChance { get; set; } = new TraitProperty<double>(false, 0, true);
    public TraitProperty<List<Triggered_Pop_Modifier>> Triggered_Pop_Modifier { get; set; } = new TraitProperty<List<Triggered_Pop_Modifier>>(false, new List<Triggered_Pop_Modifier>(), true);
    public TraitProperty<List<Modifier>> Growing_Modifiers { get; set; } = new TraitProperty<List<Modifier>>(false, new List<Modifier>(), true);
    public TraitProperty<List<Modifier>> Assembling_Modifier { get; set; } = new TraitProperty<List<Modifier>>(false, new List<Modifier>(), true);
    public TraitProperty<List<Modifier>> Declining_Modifier { get; set; } = new TraitProperty<List<Modifier>>(false, new List<Modifier>(), true);
    public TraitProperty<List<Modifier>> Modifiers { get; set; } = new TraitProperty<List<Modifier>>(false, new List<Modifier>(), true);
    public TraitProperty<List<Modifier>> Self_Modifier { get; set; } = new TraitProperty<List<Modifier>>(false, new List<Modifier>(), true);
    public TraitProperty<List<Trait>> Opposites { get; set; } = new TraitProperty<List<Trait>>(false, new List<Trait>(), true);
    public TraitProperty<double> Ai_Weight { get; set; } = new TraitProperty<double>(false, 100, true);
    public TraitProperty<double> Leader_Min_Age { get; set; } = new TraitProperty<double>(false, 0, true);
    public TraitProperty<double> Leader_Max_Age { get; set; } = new TraitProperty<double>(false, 0, true);
    public TraitProperty<List<ResourceCost>> Slave_Cost { get; set; } = new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(), true);
    public TraitProperty<List<string>> AllowedArchetypes { get; set; } = new TraitProperty<List<string>>(false, new List<string>(), true);

        /*
        public string Icon { get; set; } // Alternative icon of this trait. gfx/interface/icons/traits/<trait key>.dds 
        public bool Allowed_Ethics { get; set; }  
        public string Custom_Tooltip { get; set; }                          
        public string Custom_Tooltip_With_Modifiers { get; set; }           
        public Prerequisites Prerequisites { get; set; }
        public string Allowed_ArchesTypes { get; set; }  
        public string Species_Class { get; set; }
        public PlanetTypes Allowed_Planet_Classes = ALL
        species_potential_add    always = yes
        species_possible_remove 	always = yes 
               
            leader_trait = { ... } 	all 	No.png 	A list of leader classes. Vanilla generic leader traits have leader_trait = all.
            leader_class = { ... } 	? 	A list of leader classes. Vanilla leader traits always have it the same as leader_trait. Actual difference between the two is unclear.
            ai_categories = { ... } 	No.png 	What kind of tasks the AI will consider this leader be suit of. Only relevant to scientists. Can be consist of any number of the following four: engineering, physics, society, survey.
            leader_potential_add 	always = yes 	A block of Conditions to determine can the trait be added to a leader upon leader generation. (Leader scope, FROM is the empire)
            trade_acceptance_weight 	1 	How much extra should the AI value leaders with this trait in trade (multiplied by 10) (not used in Vanilla) 
        */
    }

    public class Prerequisites
    {
    }

    public class ResourceCost
    {
        public ResourceTypes Type { get; set; } = ResourceTypes.Energy;
        public double Value { get; set; } = 0;
    }

    public enum ResourceTypes
    {
        Minerals,
        Energy,
        Food,
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

    public class Triggered_Pop_Modifier : Modifier
    {
        public List<Trigger> Triggers;
    }

    public class Trigger
    {
        public TriggerType Type;
        public Conditions Conditions;
        public double Value;
    }

    public enum Conditions
    {
        Equal,
        Smaller,
        Larger,
        NotEqual
    }

    public enum TriggerType
    {
    }


    public enum ModifierScope
    {
        Country,
        Planet,
        Ship,
        Federation,
        Megastructure,
        Pop,
        None,
        GalaticObject,
        Sector,
        Fleet,
        Army,
        Leader
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