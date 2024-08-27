using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

public class PlayerHUD : Script
{
    [ShowInEditor, Serialize]
    private UIControl coins;

    [ShowInEditor, Serialize]
    private UIControl winMessage;

    public void UpdateScore(int value)
    {
        coins.Get<Label>().Text = "Coins: " + value;
    }

    public void UpdateWinMessage()
    {
        winMessage.IsActive = true;
    }
}
