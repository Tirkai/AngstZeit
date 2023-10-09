using Godot;
using System;

public partial class CreatureArmorDurabilityStat : CreatureBaseStat
{
	[Export]
	public float AccumulatedDamage = 0;
	public float GetDurabilityMultiplier()
	{
		if (Value <= 0 || AccumulatedDamage >= Value)
        {
			return 0;
		}

		float result = 1 - AccumulatedDamage / Value;

		return result;
	}
}
