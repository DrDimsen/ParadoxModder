using Stellaris;

namespace StellarisTests
{
    public class TraitCreationTests
    {
        private Trait trait;

        public TraitCreationTests()
        {
            trait = new Trait(TraitType.Species);
        }

        [Fact]
        public void DefaultTraitNameShouldBeNew_Trait()
        {
            Assert.Equal("New_Trait", trait.Name.Value);
        }

        [Fact]
        public void ChangingTraitNameShouldReflectNewValue()
        {
            trait.Name.Value = "Dragon";
            Assert.Equal("Dragon", trait.Name.Value);
        }

        [Fact]
        public void DefaultTraitCostShouldBeZero()
        {
            Assert.Equal(0, trait.Cost.Value);
        }

        [Fact]
        public void ChangingTraitCostShouldReflectNewValue()
        {
            trait.Cost.Value = 20;
            Assert.Equal(20, trait.Cost.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveRandomizedSetToTrue()
        {
            Assert.True(trait.Randomized.Value);
        }

        [Fact]
        public void ChangingRandomizedShouldReflectNewValue()
        {
            trait.Randomized.Value = false;
            Assert.False(trait.Randomized.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveValidForAllEthicsSetToTrue()
        {
            Assert.True(trait.Valid_For_All_Ethics.Value);
        }

        [Fact]
        public void ChangingValidForAllEthicsShouldReflectNewValue()
        {
            trait.Valid_For_All_Ethics.Value = false;
            Assert.False(trait.Valid_For_All_Ethics.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveEmptyModifiersList()
        {
            Assert.Empty(trait.Modifiers.Value);
        }

        [Fact]
        public void AddingModifierToTraitShouldIncreaseCount()
        {
            trait.Modifiers.Value.Add(new Modifier());
            Assert.Single(trait.Modifiers.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveEmptyOppositesList()
        {
            Assert.Empty(trait.Opposites.Value);
        }

        [Fact]
        public void AddingOppositeTraitShouldIncreaseCount()
        {
            trait.Opposites.Value.Add(new Trait(TraitType.Species));
            Assert.Single(trait.Opposites.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveInitialSetToTrue()
        {
            Assert.True(trait.Initial.Value);
        }

        [Fact]
        public void ChangingInitialShouldReflectNewValue()
        {
            trait.Initial.Value = false;
            Assert.False(trait.Initial.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveModificationSetToTrue()
        {
            Assert.True(trait.Modification.Value);
        }

        [Fact]
        public void ChangingModificationShouldReflectNewValue()
        {
            trait.Modification.Value = false;
            Assert.False(trait.Modification.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveImprovesLeadersSetToFalse()
        {
            Assert.False(trait.Improves_Leaders.Value);
        }

        [Fact]
        public void ChangingImprovesLeadersShouldReflectNewValue()
        {
            trait.Improves_Leaders.Value = true;
            Assert.True(trait.Improves_Leaders.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveAdvancedTraitSetToFalse()
        {
            Assert.False(trait.Advanced_Trait.Value);
        }

        [Fact]
        public void ChangingAdvancedTraitShouldReflectNewValue()
        {
            trait.Advanced_Trait.Value = true;
            Assert.True(trait.Advanced_Trait.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveForcedHappinessSetToFalse()
        {
            Assert.False(trait.Forced_Happiness.Value);
        }

        [Fact]
        public void ChangingForcedHappinessShouldReflectNewValue()
        {
            trait.Forced_Happiness.Value = true;
            Assert.True(trait.Forced_Happiness.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveImmortalLeadersSetToFalse()
        {
            Assert.False(trait.Immortal_Leaders.Value);
        }

        [Fact]
        public void ChangingImmortalLeadersShouldReflectNewValue()
        {
            trait.Immortal_Leaders.Value = true;
            Assert.True(trait.Immortal_Leaders.Value);
        }

        [Fact]
        public void DefaultPotentialCrossbreedingChanceShouldBeZero()
        {
            Assert.Equal(0, trait.PotentialCrossbreedingChance.Value);
        }

        [Fact]
        public void ChangingPotentialCrossbreedingChanceShouldReflectNewValue()
        {
            trait.PotentialCrossbreedingChance.Value = 0.5;
            Assert.Equal(0.5, trait.PotentialCrossbreedingChance.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveEmptyTriggeredPopModifierList()
        {
            Assert.Empty(trait.Triggered_Pop_Modifier.Value);
        }

        [Fact]
        public void AddingTriggeredPopModifierShouldIncreaseCount()
        {
            trait.Triggered_Pop_Modifier.Value.Add(new Triggered_Pop_Modifier());
            Assert.Single(trait.Triggered_Pop_Modifier.Value);
        }

        [Fact]
        public void DefaultAiWeightShouldBe100()
        {
            Assert.Equal(100, trait.Ai_Weight.Value);
        }

        [Fact]
        public void ChangingAiWeightShouldReflectNewValue()
        {
            trait.Ai_Weight.Value = 80;
            Assert.Equal(80, trait.Ai_Weight.Value);
        }

        [Fact]
        public void DefaultLeaderMinAgeShouldBeZero()
        {
            Assert.Equal(0, trait.Leader_Min_Age.Value);
        }

        [Fact]
        public void ChangingLeaderMinAgeShouldReflectNewValue()
        {
            trait.Leader_Min_Age.Value = 30;
            Assert.Equal(30, trait.Leader_Min_Age.Value);
        }

        [Fact]
        public void DefaultLeaderMaxAgeShouldBeZero()
        {
            Assert.Equal(0, trait.Leader_Max_Age.Value);
        }

        [Fact]
        public void ChangingLeaderMaxAgeShouldReflectNewValue()
        {
            trait.Leader_Max_Age.Value = 80;
            Assert.Equal(80, trait.Leader_Max_Age.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveEmptySlaveCostList()
        {
            Assert.Empty(trait.Slave_Cost.Value);
        }

        [Fact]
        public void AddingSlaveCostShouldIncreaseCount()
        {
            trait.Slave_Cost.Value.Add(new ResourceCost());
            Assert.Single(trait.Slave_Cost.Value);
        }

        [Fact]
        public void DefaultTraitShouldHaveEmptyAllowedArchetypesList()
        {
            Assert.Empty(trait.AllowedArchetypes.Value);
        }

        [Fact]
        public void AddingAllowedArchetypesShouldIncreaseCount()
        {
            trait.AllowedArchetypes.Value.Add("Archetype_X");
            Assert.Single(trait.AllowedArchetypes.Value);
        }
        
        [Fact]
        public void AddingLeaderModifierToLeaderTraitShouldSucceed()
        {
            var leaderTrait = new Trait(TraitType.Leader);
            var leaderModifier = new Modifier { Type = ModifierType.LeaderTraits };

            bool result = leaderTrait.AddModifierToProperty(leaderModifier, leaderTrait.Modifiers);

            Assert.True(result);
            Assert.Single(leaderTrait.Modifiers.Value);
        }

        [Fact]
        public void AddingSpeciesModifierToSpeciesTraitShouldSucceed()
        {
            var speciesTrait = new Trait(TraitType.Species);
            var speciesModifier = new Modifier { Type = ModifierType.SpeciesTraits };

            bool result = speciesTrait.AddModifierToProperty(speciesModifier, speciesTrait.Modifiers);

            Assert.True(result);
            Assert.Single(speciesTrait.Modifiers.Value);
        }

        [Fact]
        public void AddingLeaderModifierToSpeciesTraitShouldFail()
        {
            var speciesTrait = new Trait(TraitType.Species);
            var leaderModifier = new Modifier { Type = ModifierType.LeaderTraits };

            bool result = speciesTrait.AddModifierToProperty(leaderModifier, speciesTrait.Modifiers);

            Assert.False(result);
            Assert.Empty(speciesTrait.Modifiers.Value);
        }

        [Fact]
        public void AddingSpeciesModifierToLeaderTraitShouldFail()
        {
            var leaderTrait = new Trait(TraitType.Leader);
            var speciesModifier = new Modifier { Type = ModifierType.SpeciesTraits };

            bool result = leaderTrait.AddModifierToProperty(speciesModifier, leaderTrait.Modifiers);

            Assert.False(result);
            Assert.Empty(leaderTrait.Modifiers.Value);
        }
    }
}