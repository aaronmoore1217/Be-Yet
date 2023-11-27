using Godot;
using System;

public partial class InventoryManager : Node2D
{
	[Export] private int Material1 = 0;
	[Export] private int Material2 = 0;
	[Export] private int Material3 = 0;
	[Export] private int Material4 = 0;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
