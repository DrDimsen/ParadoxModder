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
        public string Name { get; set; } = "New_Trait";
        public int Cost { get; set; } = 0;
        public bool Initial { get; set; } = true;
        public bool Randomized { get; set; } = true;
        public bool Modification { get; set; } = true;
        public bool Improves_Leaders { get; set; } = false; // Implemeted Elsewhere
        public bool Advanced_Trait { get; set; } = false;
        public bool Forced_Happiness { get; set; } = false;
        public bool Valid_For_All_Ethics { get; set; } = true;
        public bool Immortal_Leaders { get; set; } = false;
        public double PotentialCrossbreedingChance { get; set; } = 0;
        public List<Triggered_Pop_Modifier> Triggered_Pop_Modifier { get; set; } = new List<Triggered_Pop_Modifier>();
        public List<Modifier> Growing_Modifiers { get; set; } = new List<Modifier>();
        public List<Modifier> Assembling_Modifier { get; set; } = new List<Modifier>();
        public List<Modifier> Declining_Modifier { get; set; } = new List<Modifier>();
        public List<Modifier> Modifiers { get; set; } = new List<Modifier>();
        public List<Modifier> Self_Modifier { get; set; } = new List<Modifier>();
        public List<Trait> Opposites { get; set; } = new List<Trait>();
        public double Ai_Weight { get; set; } = 100;
        public double Leader_Min_Age { get; set; } = 0;
        public double Leader_Max_Age { get; set; } = 0;

        public List<ResourceCost> Slave_Cost { get; set; } = new List<ResourceCost>();

        public List<string> AllowedArchetypes { get; set; } = new List<string>();
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