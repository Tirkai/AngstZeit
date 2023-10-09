using Godot;
using System;

public partial class DefenceLayer : Node
{
	// Called when the node enters the scene tree for the first time.
	public virtual Damage Calculate(Damage damage)
	{
		return damage;
	}

	public virtual void ConsumeResource(float value)
	{
	}
}
