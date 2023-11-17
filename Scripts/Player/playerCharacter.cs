using Godot;
using System;

public partial class playerCharacter : CharacterBody2D
{
    [ExportCategory("Player Stats")]
    [Export] public int Speed { get; set; } = 400;

    [ExportCategory("Sprites")]
    [Export] AnimatedSprite2D playerAnimation;
    [Export] Sprite2D playerBody;
    //runs on game ready
    public override void _Ready()
    {
        
    }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
        GD.Print(inputDirection);
        switch (inputDirection)
        {
            //down left
            case ((float)-0.70710677, (float)-0.70710677):
                playerAnimation.RotationDegrees = 315;
                break;
            //up right
            case ((float)0.70710677, (float)0.70710677):
                playerAnimation.RotationDegrees = 135;
                break;
            //right down
            case ((float)0.70710677, (float)-0.70710677):
                playerAnimation.RotationDegrees = 45;
                break;
            //up left
            case ((float)-0.70710677, (float)0.70710677):
                playerAnimation.RotationDegrees = 225;
                break;
            //up
            case (0, 1):
                playerAnimation.RotationDegrees = 180;
                break;
            //down
            case (0, -1):
                playerAnimation.RotationDegrees = 0;
                break;
            
            //left
            case (-1, 0):
                playerAnimation.RotationDegrees = 270;
                break;
            //right
            case (1, 0):
                playerAnimation.RotationDegrees = 90;
                break;

        }

        //start and stop animation
        if (Velocity.Length() > 0)
        {
            Velocity = Velocity.Normalized() * Speed;
            playerAnimation.Play();
            playerAnimation.Visible = true;
            playerBody.Visible = false;
        }
        else
        {
            playerAnimation.Stop();
            playerAnimation.Visible = false;
            playerBody.Visible = true;
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
