using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MnO2DetectH2O2 : MonoBehaviour
{

    ParticleSystem _particleSystem;
    LiquidSystem liquidSystem;
    bool IsDone;
    M2O2 m2O2;
    private void Start()
    {
        m2O2 = gameObject.transform.parent.GetComponent<M2O2>();
    }
    private void Update()
    {

        if (!IsDone && gameObject.tag == "Liquid" && liquidSystem.available > 0)
        {
            IsDone = true;
            m2O2.IsDone = true;
            liquidSystem.gameObject.GetComponent<Test_Tube>().IsDone =true;
            _particleSystem.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag != "Liquid" && collision.gameObject.tag == "Liquid")
        {
            liquidSystem = collision.gameObject.transform.parent.GetComponent<LiquidSystem>();
            _particleSystem = liquidSystem.gameObject.transform.GetChild(11).GetComponent<ParticleSystem>();

            if (liquidSystem)
            {
                gameObject.transform.SetParent(liquidSystem.gameObject.transform);
                gameObject.tag = "Liquid";
            }
        }
    }

}
