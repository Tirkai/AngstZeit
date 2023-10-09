using Godot;
using System;

public partial class CreatureArmorController : Node
{
	public CreatureArmorAbsorptionStat creatureArmorAbsorptionStat;
	public CreatureArmorDurabilityStat creatureArmorDurabilityStat;

	public override void _EnterTree()
	{
		creatureArmorAbsorptionStat = GetNode<CreatureArmorAbsorptionStat>("%CreatureArmorAbsorptionStat");
		creatureArmorDurabilityStat = GetNode<CreatureArmorDurabilityStat>("%CreatureArmorDurabilityStat");
	}

	public void LossDurability(float value)
	{
		creatureArmorDurabilityStat.AccumulatedDamage += value;
	}

	public Damage CalculateDamageAbsorption(Damage damage)
	{
		float cumulativeDamage = damage.GetCumulativeDamageValue();
		float cumulativeBypassedDamage = cumulativeDamage - (creatureArmorAbsorptionStat.Value * creatureArmorDurabilityStat.GetDurabilityMultiplier());

		if (cumulativeBypassedDamage <= 0)
		{
			return new Damage();
		}

		float damageMultiplier = cumulativeBypassedDamage / cumulativeDamage;

		return Damage.CreateDamageWithMultiplier(damage, damageMultiplier);
	}
}
