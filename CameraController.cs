using Godot;
using System;
using System.Numerics;

public partial class CameraController : Node2D
{
	[Export] public int CameraModifier { get; set; }
	Godot.Vector2 vector;
	Godot.Vector2 CamPos;
	
	[Export] Camera2D Camera;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		vector = new Godot.Vector2(0.33f, 0.33f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CamPos = GetGlobalMousePosition() * vector;
		Camera.Position = new Godot.Vector2(
    		x: Mathf.Clamp(CamPos.X, -45, 45),
    		y: Mathf.Clamp(CamPos.Y, -45, 45)
		);

	}
}
