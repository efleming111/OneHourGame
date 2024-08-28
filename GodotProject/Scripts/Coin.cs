using Godot;
using System;
using System.Runtime.InteropServices;

public partial class Coin : Node3D
{
	[Export]
	private float turnSpeed = 1.0f;

	private float coinRotation = 0.0f;
	private AudioStreamPlayer player;

	public override void _Ready()
	{
		player = GetNode<AudioStreamPlayer>("CollectSFX");
	}

	public override void _Process(double delta)
	{
		Rotate(Vector3.Up, (float)delta * turnSpeed);

	}

	public void OnTriggerEntered(Node3D body)
	{
		GD.Print("Tigger Entered");
        //        if (collider.Tags.HasTag(Tags.Get("Player")))
        //        {
        //            Actor.GetChild<StaticModel>().IsActive = false;
        //            Actor.GetChild<BoxCollider>().IsActive = false;
        //            collider.AttachedRigidBody.GetScript<Player>().CollectCoins(1);
        //            collectCoinSFX.Play();
        //            Destroy(Actor, 2.0f);
        //        }
    }
}


//namespace Game;

//public class Coin : Script
//{
//    [ShowInEditor, Serialize]
//    private AudioSource collectCoinSFX = null;


