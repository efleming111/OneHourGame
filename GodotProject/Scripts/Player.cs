using Godot;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Player : RigidBody3D
{
    [Export]
    private Node3D camera = null;

    [Export]
    private float moveForce = 100.0f;

    [Export]
    private float jumpForce = 10.0f;

    private Vector3 forwardVector = Vector3.Zero;
    private Vector3 rightVector = Vector3.Zero;
    private bool isJumping = false;

    private int coins;
    public int Coins
    {
        get { return coins; }
    }

    public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("ExitGame"))
        {
            GetTree().Quit();
        }

        if (Input.IsActionJustPressed("Jump") && !isJumping)
        {
            ApplyImpulse(Vector3.Up * jumpForce);
            isJumping = true;
        }

        forwardVector = Input.GetAxis("MoveForward", "MoveBackward") * (camera.GlobalPosition - GlobalPosition);
        rightVector = Input.GetAxis("MoveLeft", "MoveRight") * Vector3.Up.Cross((camera.GlobalPosition - GlobalPosition));
        forwardVector.Y = 0;
        rightVector.Y = 0;

        ApplyForce((float)delta * moveForce * forwardVector.Normalized());
        ApplyForce((float)delta * moveForce * rightVector.Normalized());
    }

    public void OnCollisionEntered(Node3D body)
    {
        isJumping = false;
    }

    public void CollectCoins(int amount)
    {
        if (amount < 0)
        {
            return;
        }
        coins += amount;
        //playerHUD.GetScript<PlayerHUD>().UpdateScore(coins);
        //if (coinManager.CollectedAllCoins(1))
        //{
        //    Screen.CursorVisible = true;
        //    Screen.CursorLock = CursorLockMode.None;
        //    LoadNextLevel(3000);
        //}
    }
}



//public class Player : Script
//{
//    [ShowInEditor, Serialize]
//    private SceneReference nextLevel;

//    [ShowInEditor, Serialize]
//    private CoinManager coinManager;

//    [ShowInEditor, Serialize]
//    private UICanvas playerHUD;









//    private async Task<bool> LoadNextLevel(int millisecond)
//    {
//        bool result = await Task.Run(() =>
//        {
//            Task.Delay(millisecond).Wait();
//            return true;
//        });

//        Level.ChangeSceneAsync(nextLevel);

//        return result;
//    }

