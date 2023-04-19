using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    //[SerializeField] LiquidSystem liquidSystem_Beacker_1;
    //[SerializeField] LiquidSystem liquidSystem_Beacker_2;


    public int UINum = 7;/*1;*/

    // Update is called once per frame
    void Update()
    {

        switch (UINum)
        {
            case 1: //1.1 to 2.1
                //if (((liquidSystem_Beacker_1.available >= 100 && liquidSystem_Beacker_1._molar < 0.5f) || (liquidSystem_Beacker_2.available >= 100 && liquidSystem_Beacker_2._molar < 0.5f)))
                //{
                //    UIActivation(UINum);
                //    UINum++;
                //}
                //else if ((Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped))
                //{
                //    UIActivation(UINum);
                //    UINum++;
                //}
                break;
            case 2: //2.1 to 3.1
                //if (((liquidSystem_Beacker_1.available >= 100 && liquidSystem_Beacker_1._molar >= 0.5f) || (liquidSystem_Beacker_2.available >= 100 && liquidSystem_Beacker_2._molar >= 0.5f)))
                //{
                //    UIActivation(UINum);
                //    UINum++;
                //}
                //else if ((Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped))
                //{
                //    UIActivation(UINum);
                //    UINum++;
                //}
                break;
            case 3: //3.1 to 4.1

                break;
            case 4: //4.1 to 5.1

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
}
