using Godot;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Player : RigidBody3D
{
    [Export]
    private Node3D cameraController = null;

    [Export]
    private float moveForce = 100.0f;

    [Export]
    private float jumpForce = 10.0f;

    private Vector3 movement = Vector3.Zero;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("ExitGame"))
        {
            GetTree().Quit();
        }

        // TODO prevent double jumping
        if (Input.IsActionJustPressed("Jump"))
        {
            ApplyImpulse(Vector3.Up * jumpForce);
        }

        // TODO move based on camera angle
        GD.Print(cameraController.Rotation * 57.2958f);

        movement.X = Input.GetAxis("MoveForward", "MoveBackward");
        movement.Z = Input.GetAxis("MoveRight", "MoveLeft");

        movement = movement.Normalized();




        ApplyTorque((float)delta * moveForce * movement);


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

//    [ShowInEditor, Serialize]
//    private RigidBody rigidBody;



//    private bool isJumping = false;

//    private int coins;
//    public int Coins
//    {
//        get { return coins; }
//    }

//    public override void OnStart()
//    {
//        rigidBody.CollisionEnter += OnCollisionEnter;
//    }

//    public override void OnUpdate()
//    {
//        base.OnUpdate();


//    }

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
//    public void CollectCoins(int amount)
//    {
//        if (amount < 0)
//        {
//            return;
//        }
//        coins += amount;
//        playerHUD.GetScript<PlayerHUD>().UpdateScore(coins);
//        if (coinManager.CollectedAllCoins(1))
//        {
//            Screen.CursorVisible = true;
//            Screen.CursorLock = CursorLockMode.None;
//            LoadNextLevel(3000);
//        }
//    }

//    public void SpendCoins(int amount)
//    {
//        if (!CanSpendCoins(amount))
//        {
//            return;
//        }
//        coins -= amount;
//        playerHUD.GetScript<PlayerHUD>().UpdateScore(coins);
//    }

//    public bool CanSpendCoins(int amount)
//    {
//        if (coins - amount < 0)
//        {
//            return false;
//        }
//        return true;
//    }

//    public void OnCollisionEnter(Collision collision)
//    {
//        isJumping = false;
//    }
//}
