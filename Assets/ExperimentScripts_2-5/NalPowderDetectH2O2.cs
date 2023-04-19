using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NalPowderDetectH2O2 : MonoBehaviour
{
    ParticleSystem _particleSystem;
    [SerializeField] LiquidSystem liquidSystem;


    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();

    }

    private void OnParticleTrigger()
    {

        ////Get all particles that entered a box collider
        //List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        //int enterCount = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);
        ////int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents(_particleSystem, gameObject, collisionEvents);
        //if (liquidSystem.available > 0 && enterCount > 0)
        //{


        //}
    }
}
