using Godot;
using System;
using System.Security.Cryptography;

public class Player : Sprite
{
    // Custom signal example that is emitted when the player moves
    [Signal]
    public delegate void Moved(float newX, float newY);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var timer = GetNode<Timer>("Clock");
        timer.WaitTime = 1;

        // 'timeout' is the callback event that is emitted
        // 'this' is the object that receives the signal
        // 'OnTimeout' is the method that will be called
        timer.Connect("timeout", this, "OnTimeout");
        timer.Start();

        // Connect player object to the custom signal
        this.Connect("Moved", this, "OnMoved");
    }

    private void OnTimeout()
    {
        float randX = (float)GD.RandRange(0, 500);
        float randY = (float)GD.RandRange(0, 500);
        this.Position = new Vector2(randX, randY);

        this.EmitSignal("Moved", randX, randY);
    }

    private void OnMoved(float newX, float newY)
    {
        GD.Print($"Moved to ({newX}, {newY})");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
