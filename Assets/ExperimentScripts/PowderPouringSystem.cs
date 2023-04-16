using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderPouringSystem : MonoBehaviour
{
    private PowderSystem powderSystem;
    private ParticleSystem pouringPS;
    private List<ParticleCollisionEvent> collisionEvents;
    [Tooltip("ML per single particle. This is calculated automatically by the Pour Per Second & Rate Over Time in LiquidSystemV2.")]
    public float mlpp = 0; // ML Per Particle
    public int colls = 0;
    public int totalCollided = 0;
    private void Start()
    {
        powderSystem = transform.parent.GetComponent<PowderSystem>();
        pouringPS = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        //mlpp = liquidSystem.pourPerSecond / pouringPS.emission.rateOverTime.constant;
        mlpp = powderSystem.pourPerSecond; // Changed to this because we will be using it as pour per particle instead of sec
    }
    private void OnParticleCollision(GameObject other)
    {
        int totalCollisions = pouringPS.GetCollisionEvents(other, collisionEvents);
        int i = 0;

        while (i < totalCollisions)
        {
            if (collisionEvents[i].colliderComponent.CompareTag("Liquid"))
            {
                collisionEvents[i].colliderComponent.transform.parent.SendMessage("PowderFill", mlpp, SendMessageOptions.DontRequireReceiver);
                colls++;
            }
            i++;
        }

        totalCollided += totalCollisions;
    }
}
