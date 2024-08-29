using Godot;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public partial class Coin : Node3D
{
    [Export]
    private Player player;

    [Export]
	private float turnSpeed = 1.0f;

	private float coinRotation = 0.0f;
	private AudioStreamPlayer coinCollectSFX;

	public override void _Ready()
	{
        coinCollectSFX = GetNode<AudioStreamPlayer>("CollectSFX");
	}

	public override void _Process(double delta)
	{
		Rotate(Vector3.Up, (float)delta * turnSpeed);

	}

	public void OnTriggerEntered(Node3D body)
	{
		if (body.IsInGroup("Player"))
		{
			Visible = false;
			GetNode<Area3D>("Area3D").SetDeferred("monitoring", false);
			player.CollectCoins(1);
			coinCollectSFX.Play();
			DestroyNodeInSeconds(2500);
			
        }
    }

    private async Task<bool> DestroyNodeInSeconds(int millisecond)
    {
        bool result = await Task.Run(() =>
        {
            Task.Delay(millisecond).Wait();
            return true;
        });
		Free();

        return result;
    }
}



