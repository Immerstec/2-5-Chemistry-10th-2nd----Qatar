using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Tube : MonoBehaviour
{
    bool IsFilled;
    LiquidSystem liquidSystem;
    CheckTestTubesFill checkTestTubesFill;
    private void Start()
    {
     
        liquidSystem = GetComponent<LiquidSystem>();
        checkTestTubesFill = gameObject.transform.parent.GetComponent<CheckTestTubesFill>();
    }

    private void Update()
    {
        if (!IsFilled && liquidSystem.available > 50) 
        {
            IsFilled = true;
            checkTestTubesFill.NumFilledTubes++;
        }
    }
}
