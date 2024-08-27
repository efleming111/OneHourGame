using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game;

public class CameraController : Script
{
    [ShowInEditor, Serialize]
    private Actor player;

    [ShowInEditor, Serialize]
    private float sensitivity = 5.0f;

    private Vector3 cameraRotation = Vector3.Zero;

    public override void OnStart()
    {
        base.OnStart();

        Screen.CursorVisible = false;
        Screen.CursorLock = CursorLockMode.Locked;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        cameraRotation.Y = Input.GetAxis("Mouse X") * sensitivity * Time.DeltaTime;
        cameraRotation.X = Input.GetAxis("Mouse Y") * sensitivity * Time.DeltaTime;

        Actor.Position = player.Position;
        Actor.EulerAngles += cameraRotation;
    }
}
