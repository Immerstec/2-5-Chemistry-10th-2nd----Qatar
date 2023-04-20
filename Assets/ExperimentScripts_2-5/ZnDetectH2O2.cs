using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZnDetectH2O2 : MonoBehaviour
{
    [SerializeField] Texture texture;
    LiquidSystem liquidSystem;
    bool IsDone;
    Zn zn;
    private void Start()
    {
        zn = gameObject.transform.parent.GetComponent<Zn>();
    }
    private void Update()
    {

        if (!IsDone && gameObject.tag == "Liquid" && liquidSystem.available > 0)
        {
            IsDone = true;
            zn.IsDone = true;
            liquidSystem.gameObject.GetComponent<Test_Tube>().IsDone = true;
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", texture);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag != "Liquid" && collision.gameObject.tag == "Liquid")
        {
            liquidSystem = collision.gameObject.transform.parent.GetComponent<LiquidSystem>();
            if (liquidSystem)
            {
                gameObject.transform.SetParent(liquidSystem.gameObject.transform);
                gameObject.tag = "Liquid";
            }

        }
    }

}
