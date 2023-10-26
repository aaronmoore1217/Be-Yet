using Godot;
using System;

public partial class playerCharacter : CharacterBody2D
{
    public int Speed { get; set; } = 400;
    public Vector2 ScreenSize;

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }
    public override void _Process(double delta)
    {
        var position = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("right"))
        {
            position.X += 1;
        }

        if (Input.IsActionPressed("left"))
        {
            position.X -= 1;
        }

        if (Input.IsActionPressed("down"))
        {
            position.Y += 1;
        }

        if (Input.IsActionPressed("up"))
        {
            position.Y -= 1;
        }

        var playerAnimation = GetNode<AnimatedSprite2D>("playerAnimation");

        if (position.Length() > 0)
        {
            position = position.Normalized() * Speed;
            playerAnimation.Play();
        }
        else
        {
            playerAnimation.Stop();
        }
        Position += position * (float)delta;
        if (position.X < 0)
        {
            playerAnimation.FlipH = true;
        }
        else
        {
            playerAnimation.FlipH = false;
        }
        // Position = new Vector2(
        //     x: Mathf.Clamp(Position.X, 0, ScreenSize.X-106),
        //     y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y-106)
        // );
    }
}
