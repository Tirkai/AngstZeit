using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class CreatureDamageController : Node
{
	[Export]
	public DefenceLayer[] defenceLayers;

	public void OnTakeDamage(Damage damage){
		var calculatedDamage = damage;

		foreach (var layer in defenceLayers){
			var cumulativeDamageBeforeCalculation = calculatedDamage.GetCumulativeDamageValue();
			calculatedDamage = layer.Calculate(calculatedDamage);
			layer.ConsumeResource(cumulativeDamageBeforeCalculation);
		}

		GD.Print(string.Format("Take Damage {0}", calculatedDamage.GetCumulativeDamageValue()));
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var damage = new Damage
		{
			slash = 50,
		};

		for (int i = 0; i < 10; i++){
			OnTakeDamage(damage);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
