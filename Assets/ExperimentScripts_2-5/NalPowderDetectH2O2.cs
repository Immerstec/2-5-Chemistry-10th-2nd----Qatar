using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NalPowderDetectH2O2 : MonoBehaviour
{
    ParticleSystem _particleSystem;
    private List<ParticleCollisionEvent> collisionEvents;
    [System.NonSerialized] public bool IsDone;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int totalCollisions = _particleSystem.GetCollisionEvents(other, collisionEvents);
        int i = 0;

        while (i < totalCollisions)
        {
            if (collisionEvents[i].colliderComponent.CompareTag("Liquid"))
            {

                if (collisionEvents[i].colliderComponent.transform.parent.GetComponent<LiquidSystem>().available > 0) 
                {
                    if(!collisionEvents[i].colliderComponent.transform.parent.GetChild(10).GetComponent<ParticleSystem>().isPlaying)
                        collisionEvents[i].colliderComponent.transform.parent.GetChild(10).GetComponent<ParticleSystem>().Play();

                    if (!IsDone)
                        IsDone = true;
                }
            }
            i++;
        }
    }
}
