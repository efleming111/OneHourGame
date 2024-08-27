using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game;

/// <summary>
/// CoinManager Script.
/// </summary>
public class CoinManager : Script
{
    [ShowInEditor, Serialize]
    private PlayerHUD hud;

    [ShowInEditor, Serialize]
    private int coinsNeeded = 10;

    private int coinsCollected = 0;

    public bool CollectedAllCoins(int coin)
    {
        coinsCollected++;
        if (coinsCollected >= coinsNeeded)
        {
            hud.UpdateWinMessage();
            return true;
        }
        return false;
    }
}
