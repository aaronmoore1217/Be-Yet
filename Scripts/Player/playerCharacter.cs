using Godot;
using System;

public partial class playerCharacter : CharacterBody2D
{
    public int Speed { get; set; } = 400;
    public Vector2 ScreenSize;

    public override void _Ready(){
        ScreenSize = GetViewportRect().Size;
    }
    public override void _Process(double delta){
        
    }
}
