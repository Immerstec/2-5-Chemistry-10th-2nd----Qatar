using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector_Powder : MonoBehaviour
{
    ParticleSystem particleSystem;
    [SerializeField] ParticleSystem particleSystem_BurnPowder;
    public bool IsFireDetected;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnParticleTrigger()
    {

        //Get all particles that entered a box collider
        List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        int enterCount = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

        if (enterCount > 0) {
            particleSystem_BurnPowder.Play();
            IsFireDetected = true;
        }

        
    }
}
