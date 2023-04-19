using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckReachToLiquidSurface : MonoBehaviour
{
    GameObject Bubbles_1M;
    private LiquidSystem liquidSystem;
    bool bReachSurface;
    Vector3 Pos;
    bool bEndUpdate;
    [SerializeField] GameObject PerfabBubbles_1M;
    private void Update()
    {

        if (!bEndUpdate&&bReachSurface) {

            if (gameObject.transform.localScale.x >= 0)
            {
                gameObject.transform.localScale -= (Time.deltaTime / 30) * Vector3.one;
                Bubbles_1M.gameObject.transform.localScale -= (Time.deltaTime / 30) * Vector3.one;
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

        if (other.gameObject.tag == "Surface")
        {
            liquidSystem = other.gameObject.transform.parent.GetComponent<LiquidSystem>();
            if (!bReachSurface && liquidSystem._molar > 0.5f)
            {
                gameObject.GetComponent<DroppedObjectDetector>().IsDropped = true;
                
                Pos = other.ClosestPointOnBounds(transform.position);
                
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ; ;
                gameObject.transform.position = Pos;
                gameObject.transform.eulerAngles = new Vector3(0,0,20.0f);
                
                Bubbles_1M = Instantiate(PerfabBubbles_1M, new Vector3(transform.position.x, transform.position.y - 0.001f, transform.position.z), Quaternion.Euler(90.0f, 0.0f, 0.0f));
                AddTriggerToParticleSystem(other);
                
                bReachSurface = true;
            }
        }
    }
    void AddTriggerToParticleSystem(Collider Surface) {

        Bubbles_1M.GetComponent<ParticleSystem>().trigger.AddCollider(Surface);
    }

}
