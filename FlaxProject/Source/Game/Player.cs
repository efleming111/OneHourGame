using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

public class Player : Script
{
    [ShowInEditor, Serialize]
    private UICanvas playerHUD;

    [ShowInEditor, Serialize]
    private RigidBody rigidBody;

    [ShowInEditor, Serialize]
    private Actor cameraController;

    [ShowInEditor, Serialize]
    private float jumpForce = 10.0f;

    [ShowInEditor, Serialize]
    private float moveForce = 10.0f;

    private int coins;
    public int Coins
    {
        get { return coins; }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetKeyDown(KeyboardKeys.Escape))
        {
            Engine.RequestExit();
        }

        if (Input.GetKeyDown(KeyboardKeys.Spacebar))
        {
            rigidBody.AddForce(Vector3.Up * jumpForce, ForceMode.VelocityChange);
        }

        rigidBody.AddForce(Time.DeltaTime
            * moveForce
            * cameraController.Transform.Forward
            * Input.GetAxis("Vertical")
            , ForceMode.Acceleration);
        rigidBody.AddForce(Time.DeltaTime
            * moveForce
            * cameraController.Transform.Right
            * Input.GetAxis("Horizontal")
            , ForceMode.Acceleration);
    }

    public void CollectCoins(int amount)
    {
        if (amount < 0)
        {
            return;
        }
        coins += amount;
        playerHUD.GetScript<PlayerHUD>().UpdateScore(coins);
    }

    public void SpendCoins(int amount)
    {
        if (!CanSpendCoins(amount))
        {
            return;
        }
        coins -= amount;
        playerHUD.GetScript<PlayerHUD>().UpdateScore(coins);
    }

    public bool CanSpendCoins(int amount)
    {
        if (coins - amount < 0)
        {
            return false;
        }
        return true;
    }
}
