using Godot;
using System;

public partial class ArmorDefenceLayer : DefenceLayer
{
	public CreatureArmorController creatureArmorController;

	public override void _EnterTree()
	{
		creatureArmorController = GetNode<CreatureArmorController>("%CreatureArmorController");
	}
	
	// Called when the node enters the scene tree for the first time.
	public override Damage Calculate(Damage damage)
	{
		if(creatureArmorController == null){
			GD.Print("Error: CreatureArmorController not found");
			return damage;
		} 

		Damage newDamage = creatureArmorController.CalculateDamageAbsorption(damage);
		
		return newDamage;
	}

	public override void ConsumeResource(float value)
	{
		creatureArmorController.LossDurability(value);
	}

}
