using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector : MonoBehaviour
{

    [System.NonSerialized] public bool IsBurned;
    bool IsExit;
    private void Update()
    {
        if (IsExit) { 
        
            transform.GetChild(0).gameObject.transform.localScale -= (Time.deltaTime/200) * Vector3.one;
            if (transform.GetChild(0).gameObject.transform.localScale.x<0.0001)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                IsExit = false;
                IsBurned = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.transform.localScale = 0.05f * Vector3.one;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            IsExit = true;
        }        
    }
}
