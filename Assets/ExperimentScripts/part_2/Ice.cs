using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [System.NonSerialized] public bool IsUsed;

    bool bIsdissolved;

    private LiquidSystem liquidSystem;
    bool bReachBottom;
    [SerializeField] float dissolveSpeed;
    private Wobble Wobble;
    private IceCubeDetector _IceCubeDetector;



    private void Update()
    {
        if ( bReachBottom)
        {
            if (Wobble.ShakeCheck() > 0.001f || liquidSystem._molar > 0.5)
            {
                gameObject.transform.localScale -= (Time.deltaTime * dissolveSpeed *5) * Vector3.one;
              //  Debug.Log("vel: " + Wobble.ShakeCheck());
            }
            else
            {
                gameObject.transform.localScale -=(Time.deltaTime * dissolveSpeed) * Vector3.one;

            }
            if (gameObject.transform.localScale.x < 0.01f)
            {
                _IceCubeDetector.DissolvedIceNum++;
                gameObject.SetActive(false);
     

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LiquidTrigger")
        {
            if (liquidSystem == null)
            {
                liquidSystem = other.transform.parent.gameObject.transform.parent.GetComponent<LiquidSystem>();
                Wobble = liquidSystem.gameObject.transform.GetChild(6).GetComponent<Wobble>();
                _IceCubeDetector = liquidSystem.gameObject.GetComponent<IceCubeDetector>();

                _IceCubeDetector.PutIceNum++;

                float molar = liquidSystem._molar - 0.02f;
                liquidSystem._molar = Mathf.Max(0.01f, molar);
            }
            if (liquidSystem._molar > 0)
            {
                bReachBottom = true;
            }
        }
    }



}
