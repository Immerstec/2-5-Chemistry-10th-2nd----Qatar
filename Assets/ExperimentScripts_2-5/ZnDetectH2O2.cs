using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZnDetectH2O2 : MonoBehaviour
{
    [SerializeField] Texture texture;
    LiquidSystem liquidSystem;
    bool IsDone;

    private void OnCollisionStay(Collision collision)
    {
        if (!IsDone && collision.gameObject.tag == "Liquid")
        {
            liquidSystem = collision.gameObject.transform.parent.GetComponent<LiquidSystem>();
            if (liquidSystem.available > 0)
            {
                IsDone = true;
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", texture);
            }
        }
    }
}
