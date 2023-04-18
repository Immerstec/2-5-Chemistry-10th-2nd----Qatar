using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeTime : MonoBehaviour
{
    [System.NonSerialized]public bool bNoticeTime;
    bool bEndUpdate;
    [SerializeField] LiquidSystem liquidSystem_Beaker;
    [SerializeField ] float TimeForWait=15;

    // Update is called once per frame
    void Update()
    {
        if (!bEndUpdate && liquidSystem_Beaker.available >= 25)
        {
            bEndUpdate = true;
            StartCoroutine(WaitAndPrint(TimeForWait));

        }
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bNoticeTime = true;
    }
}
