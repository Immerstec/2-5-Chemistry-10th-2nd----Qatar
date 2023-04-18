using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringSystem : MonoBehaviour
{
    private LiquidSystem liquidSystem;
    private ParticleSystem pouringPS;
    private List<ParticleCollisionEvent> collisionEvents;
    [Tooltip("ML per single particle. This is calculated automatically by the Pour Per Second & Rate Over Time in LiquidSystemV2.")]
    public float mlpp = 0; // ML Per Particle
    public int colls = 0;

    private void Start()
    {

        liquidSystem = transform.parent.GetComponent<LiquidSystem>();
        pouringPS = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        //mlpp = liquidSystem.pourPerSecond / pouringPS.emission.rateOverTime.constant;
        mlpp = liquidSystem.pourPerSecond; // Changed to this because we will be using it as pour per particle instead of sec
    }

    private void OnParticleCollision(GameObject other)
    {

        int totalCollisions = pouringPS.GetCollisionEvents(other, collisionEvents);
        int i = 0;
      //  Debug.Log(i);

        while (i < totalCollisions)
        {
            if (collisionEvents[i].colliderComponent.CompareTag("Liquid"))
            {
                collisionEvents[i].colliderComponent.transform.parent.SendMessage("Fill", mlpp, SendMessageOptions.DontRequireReceiver);
                colls++;
                //Debug.Log("Fill "+ mlpp);
            }
            i++;
            //Debug.Log(i);
        }
    }
}
