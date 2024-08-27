using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

public class PlayerHUD : Script
{
    [ShowInEditor, Serialize]
    private UIControl coins;

    public void UpdateScore(int value)
    {
        Debug.Log("Update Coins");
        coins.Get<Label>().Text = "Coins: " + value;
    }
}
