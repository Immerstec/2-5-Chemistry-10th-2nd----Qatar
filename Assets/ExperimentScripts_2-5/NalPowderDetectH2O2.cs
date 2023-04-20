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
    private void Update()
    {

        if (liquidSystem && !liquidSystem.gameObject.transform.GetChild(10).GetComponent<ParticleSystem>().isPlaying && liquidSystem.available > 0 && liquidSystem.gameObject.GetComponent<PowderReceiver>().currentPowder > 0)
        {

            liquidSystem.gameObject.transform.GetChild(10).GetComponent<ParticleSystem>().Play();

            if (!IsDone)
            {

                liquidSystem.gameObject.GetComponent<Test_Tube>().IsDone = true;
                IsDone = true;

            }
        }
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
            }
            i++;
        }
    }
}
