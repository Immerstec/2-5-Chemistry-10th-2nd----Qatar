using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NalPowderDetectH2O2 : MonoBehaviour
{
    ParticleSystem _particleSystem;
    private List<ParticleCollisionEvent> collisionEvents;
    [System.NonSerialized] public bool IsDone;
    LiquidSystem liquidSystem;

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
                liquidSystem = collisionEvents[i].colliderComponent.transform.parent.GetComponent<LiquidSystem>();
                
                if (liquidSystem.available > 0) 
                {
                    if(!liquidSystem.gameObject.transform.GetChild(10).GetComponent<ParticleSystem>().isPlaying)
                        liquidSystem.gameObject.transform.GetChild(10).GetComponent<ParticleSystem>().Play();
                    

                    if(!liquidSystem.gameObject.GetComponent<Test_Tube>().IsDone)
                        liquidSystem.gameObject.GetComponent<Test_Tube>().IsDone = true;


                    if (!IsDone)
                        IsDone = true;
                }
            }
            i++;
        }
    }
}
