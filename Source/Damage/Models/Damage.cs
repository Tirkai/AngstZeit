using Godot;
using System;

public partial class Damage : Node
{

	public static Damage CreateDamageWithMultiplier(Damage damage, float multiplier)
	{	
		return new Damage() {
			slash = damage.slash * multiplier,
			puncture = damage.puncture * multiplier,
			impact = damage.impact * multiplier,
			fire = damage.fire * multiplier,
			cold = damage.cold * multiplier,
			lightning = damage.lightning * multiplier,
			acid = damage.acid * multiplier,
		};
	}

	[Export]
	public float slash = 0;

	[Export]
	public float puncture = 0;

	[Export]
	public float impact = 0;

	[Export]
	public float fire = 0;

	[Export]
	public float cold = 0;

	[Export]
	public float lightning = 0;

	[Export]
	public float acid = 0;

	public float GetCumulativeDamageValue()
	{
		var result = slash + puncture + impact + fire + cold + lightning + acid;

		return result;
	}
}
