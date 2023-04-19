using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    //[SerializeField] LiquidSystem liquidSystem_Beacker_1;
    //[SerializeField] LiquidSystem liquidSystem_Beacker_2;
    [SerializeField] CheckTestTubesFill checkTestTubesFill;

    public int UINum = 1;

    // Update is called once per frame
    void Update()
    {

        switch (UINum)
        {
            case 1: //1.1 to 2.1
                if (checkTestTubesFill.NumFilledTubes >=1)
                {
                       UIActivation(UINum);
                       UINum++;
                }
                break;
            case 2: //2.1 to 3.1
                if (checkTestTubesFill.NumFilledTubes >= 2)
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 3: //3.1 to 4.1
                if (checkTestTubesFill.NumFilledTubes >= 3)
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 4: //4.1 to 5.1
                if (checkTestTubesFill.NumFilledTubes >= 4)
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 5: //5.1 to 6.1

                break;
            case 6: //6.1 to 7.1

                break;
            case 7: //7.1 to 8.1

                break;

        }


    }

    void UIActivation(int _UINum)
    {
        gameObject.transform.GetChild(_UINum).gameObject.SetActive(false);
        gameObject.transform.GetChild(_UINum + 1).gameObject.SetActive(true);
    }


}
