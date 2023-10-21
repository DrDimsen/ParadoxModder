using Stellaris.Modifiers;
using Stellaris.Resources;

namespace Stellaris.Traits;

public class Trait
{
    public TraitType TraitType { get; private set; }
    
    public TraitProperty<string> Name { get; set; } = new TraitProperty<string>(true, "New_Trait", "name");
    public TraitProperty<int> Cost { get; set; } = new TraitProperty<int>(false, 0,"cost");
    public TraitProperty<bool> Initial { get; set; } = new TraitProperty<bool>(false, true, "initial");
    public TraitProperty<bool> Randomized { get; set; } = new TraitProperty<bool>(false, true, "randomized");
    public TraitProperty<bool> Modification { get; set; } = new TraitProperty<bool>(false, true,"modification");
    public TraitProperty<bool> Improves_Leaders { get; set; } = new TraitProperty<bool>(false, false,"improves_leaders");
    public TraitProperty<bool> Advanced_Trait { get; set; } = new TraitProperty<bool>(false, false,"advanced_trait");
    public TraitProperty<bool> Forced_Happiness { get; set; } = new TraitProperty<bool>(false, false,"forced_happiness");
    public TraitProperty<bool> Valid_For_All_Ethics { get; set; } = new TraitProperty<bool>(false, true,"valid_for_all_ethics");
    public TraitProperty<bool> Immortal_Leaders { get; set; } = new TraitProperty<bool>(false, false, "immortal_leaders");

    public TraitProperty<double> PotentialCrossbreedingChance { get; set; } =
        new TraitProperty<double>(false, 0, "potential_crossbreeding_chance");

    public TraitProperty<List<Triggered_Pop_Modifier>> Triggered_Pop_Modifier { get; set; } =
        new TraitProperty<List<Triggered_Pop_Modifier>>(false, new List<Triggered_Pop_Modifier>(), "triggered_pop_modifier");

    public TraitProperty<List<Modifier>> Growing_Modifiers { get; set; } =
        new TraitProperty<List<Modifier>>(false, new List<Modifier>(),"growing_modifier" );

    public TraitProperty<List<Modifier>> Assembling_Modifier { get; set; } =
        new TraitProperty<List<Modifier>>(false, new List<Modifier>(), "assembling_modifier");

    public TraitProperty<List<Modifier>> Declining_Modifier { get; set; } =
        new TraitProperty<List<Modifier>>(false, new List<Modifier>(), "declining_modifier");

    public TraitProperty<List<Modifier>> Modifiers { get; set; } =
        new TraitProperty<List<Modifier>>(false, new List<Modifier>(),"modifier" );

    public TraitProperty<List<Modifier>> Self_Modifier { get; set; } =
        new TraitProperty<List<Modifier>>(false, new List<Modifier>(),"self_modifier");

    public TraitProperty<List<Trait>> Opposites { get; set; } =
        new TraitProperty<List<Trait>>(false, new List<Trait>(),"opposites");

    public TraitProperty<double> Ai_Weight { get; set; } = new TraitProperty<double>(false, 100, "ai_weight");
    public TraitProperty<double> Leader_Min_Age { get; set; } = new TraitProperty<double>(false, 0, "leader_age_min");
    public TraitProperty<double> Leader_Max_Age { get; set; } = new TraitProperty<double>(false, 0,"leader_age_max");

    public TraitProperty<List<ResourceCost>> Slave_Cost { get; set; } =
        new TraitProperty<List<ResourceCost>>(false, new List<ResourceCost>(),"slave_cost");

    public TraitProperty<List<string>> AllowedArchetypes { get; set; } =
        new TraitProperty<List<string>>(false, new List<string>(),"allowed_archetypes");

    public Trait(TraitType traitType)
    {
        TraitType = traitType;
    }

    public bool AddModifierToProperty(Modifier modifier, TraitProperty<List<Modifier>> traitProperty)
    {
        switch (TraitType)
        {
            case TraitType.Leader when modifier.Type == ModifierType.LeaderTraits:
                traitProperty.Value.Add(modifier);
                return true;
            case TraitType.Species when modifier.Type == ModifierType.SpeciesTraits:
                traitProperty.Value.Add(modifier);
                return true;
            default:
                return false;
        }
    }


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