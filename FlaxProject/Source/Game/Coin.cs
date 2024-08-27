using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FlaxEngine;

namespace Game;

public class Coin : Script
{
    [ShowInEditor, Serialize]
    private AudioSource collectCoinSFX = null;

    [ShowInEditor, Serialize]
    private float turnSpeed = 1.0f;

    private BoxCollider trigger;
    private Float3 coinRotation = Float3.Zero;

    public override void OnStart()
    {
        base.OnStart();

        trigger = Actor.GetChild<BoxCollider>();
        trigger.TriggerEnter += OnTriggerEnter;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        coinRotation.Y += Time.DeltaTime * -turnSpeed;
        Actor.LocalEulerAngles += coinRotation;
    }

    public void OnTriggerEnter(PhysicsColliderActor collider)
    {
        if (collider.Tags.HasTag(Tags.Get("Player")))
        {
            Actor.GetChild<StaticModel>().IsActive = false;
            Actor.GetChild<BoxCollider>().IsActive = false;
            collider.AttachedRigidBody.GetScript<Player>().CollectCoins(1);
            collectCoinSFX.Play();
            Destroy(Actor, 2.0f);
        }
    }
}
