using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckReachToLiquidBottom : MonoBehaviour
{
    GameObject Bubbles_1M;
    private LiquidSystem liquidSystem;
    bool bReachBottom;
    bool bEndUpdate;
    [SerializeField] GameObject PerfabBubbles_1M;
    [SerializeField] float dissolveSpeed;
    private void Update()
    {
        if (!bEndUpdate && bReachBottom)
        {
            if (gameObject.transform.localScale.x >= 0)
            {
                gameObject.transform.localScale -= (Time.deltaTime * dissolveSpeed) * Vector3.one;
                Bubbles_1M.gameObject.transform.localScale -= (Time.deltaTime * dissolveSpeed) * Vector3.one;
            }
            if (gameObject.transform.localScale.x <= 0.003)
            {
                gameObject.transform.gameObject.SetActive(false);
                Bubbles_1M.gameObject.SetActive(false);
                bEndUpdate = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LiquidTrigger")
        {
            liquidSystem = other.transform.parent.gameObject.transform.parent.GetComponent<LiquidSystem>();

            if (!gameObject.GetComponent<DroppedObjectDetector>().IsDropped && liquidSystem._molar > 0)
            {
                gameObject.GetComponent<DroppedObjectDetector>().IsDropped = true;
                Bubbles_1M = Instantiate(PerfabBubbles_1M, new Vector3(transform.position.x, transform.position.y , transform.position.z),Quaternion.Euler(-90.0f,0.0f,0.0f));
                AddTriggerToParticleSystem(other);
                bReachBottom = true;
            }
        }
    }
    void AddTriggerToParticleSystem(Collider Surface)
    {

        Bubbles_1M.GetComponent<ParticleSystem>().trigger.AddCollider(Surface);
    }
}
