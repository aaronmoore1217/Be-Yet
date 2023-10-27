using Godot;
using System;

public partial class playerCharacter : CharacterBody2D
{
    public int Speed { get; set; } = 400;
    public bool turnedRight = true;
    //runs on game ready
    public override void _Ready()
    {

    }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }

    public override void _Process(double delta)
    {

        Vector2 position = Vector2.Zero; // The player's movement vector.
        var playerAnimation = GetNode<AnimatedSprite2D>("playerAnimation");

        /* movement */
        {
            if (Input.IsActionPressed("right"))
            {
                turnedRight = true;
            }

            if (Input.IsActionPressed("left"))
            {
                turnedRight = false;
            }

            
        }

        if (turnedRight)
        {
            playerAnimation.FlipH = false;
        }
        else
        {
            playerAnimation.FlipH = true;
        }

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
        // simple way to flip animation, too simple, need to keep direction.
        // if (position.X < 0)
        // {
        //     playerAnimation.FlipH = true;
        // }
        // else
        // {
        //     playerAnimation.FlipH = false;
        // }
        // Position = new Vector2(
        //     x: Mathf.Clamp(Position.X, 0, ScreenSize.X-106),
        //     y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y-106)
        // );
    }
}
