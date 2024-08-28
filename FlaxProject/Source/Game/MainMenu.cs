using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

public class MainMenu : Script
{
    [ShowInEditor, Serialize]
    private UIControl playGame;

    [ShowInEditor, Serialize]
    private UIControl exitGame;

    [ShowInEditor, Serialize]
    private SceneReference nextScene;

    public override void OnStart()
    {
        Screen.CursorVisible = true;
        Screen.CursorLock = CursorLockMode.None;
    }

    public override void OnUpdate()
    {
        if (playGame.Get<Button>().IsPressed)
        {
            Level.ChangeSceneAsync(nextScene);
        }

        if (exitGame.Get<Button>().IsPressed)
        {
            Engine.RequestExit();
        }
    }
}
