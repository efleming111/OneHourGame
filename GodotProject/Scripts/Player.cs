using Godot;
using System;
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

        forwardVector = Input.GetAxis("MoveForward", "MoveBackward") * (camera.GlobalPosition - GlobalPosition);
        rightVector = Input.GetAxis("MoveLeft", "MoveRight") * Vector3.Up.Cross((camera.GlobalPosition - GlobalPosition));
        forwardVector.Y = 0;
        rightVector.Y = 0;

        ApplyForce((float)delta * moveForce * forwardVector.Normalized());
        ApplyForce((float)delta * moveForce * rightVector.Normalized());
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
