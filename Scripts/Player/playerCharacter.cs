using Godot;
using System;

public partial class playerCharacter : CharacterBody2D
{
    public int Speed { get; set; } = 400;
    public bool turnedRight = true;
    AnimatedSprite2D playerAnimation;
    //runs on game ready
    public override void _Ready()
    {
        playerAnimation = GetNode<AnimatedSprite2D>("playerAnimation");
    }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
        
        if (Input.IsActionPressed("right"))
        {
            turnedRight = true;
        }
        if (Input.IsActionPressed("left"))
        {
            turnedRight = false;
        }

        //start and stop animation
        if (Velocity.Length() > 0)
        {
            Velocity = Velocity.Normalized() * Speed;
            playerAnimation.Play();
        }
        else
        {
            playerAnimation.Stop();
        }

        //turning
        if (turnedRight)
        {
            playerAnimation.FlipH = false;
        }
        else
        {
            playerAnimation.FlipH = true;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }

    public override void _Process(double delta)
    {
        
    }
}
