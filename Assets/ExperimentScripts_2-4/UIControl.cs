using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Oculus.Interaction
{
    public class UIControl : MonoBehaviour
    {
        // Start is called before the first frame update\
        //part_1
        [SerializeField] LiquidSystem liquidSystem_Beacker_1;
        [SerializeField] LiquidSystem liquidSystem_Beacker_2;
        [SerializeField] GameObject Mg_Strip_1;
        [SerializeField] GameObject Mg_Strip_2;
        //part_2
        [SerializeField] GameObject Fizzy_C_Tablet_1;
        [SerializeField] GameObject Fizzy_C_Tablet_2;
        [SerializeField] GameObject Mg_Strip_Part_2;
        [SerializeField] LiquidSystem liquidSystem_Beacker_1_Part_2;
        [SerializeField] LiquidSystem liquidSystem_Beacker_2_Part_2;
        //[SerializeField] GameObject Part_1_2;
        [SerializeField] GameObject Part_2_2;
        //part_3
        [SerializeField] GameObject Fe_Strip;
        [SerializeField] GameObject Spatula_Spoon_Powder;
        [SerializeField] GameObject Powder_For_Test;
        //Part_4
        [SerializeField] LiquidSystem liquidSystem_Beacker_Part4;
        [SerializeField] NoticeTime _NoticeTime;
        [SerializeField] GameObject Spatula_Spoon_Powder_Part_4;
        [SerializeField] GameObject Powder_For_Test_Part_4;

        public int UINum = 7;/*1;*/

        // Update is called once per frame
        void Update()
        {

            switch (UINum)
            {
                case 1:
                    if (((liquidSystem_Beacker_1.available >= 100 && liquidSystem_Beacker_1._molar < 0.5f) || (liquidSystem_Beacker_2.available >= 100 && liquidSystem_Beacker_2._molar < 0.5f)))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    else if ((Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 2:
                    if (((liquidSystem_Beacker_1.available >= 100 && liquidSystem_Beacker_1._molar >= 0.5f) || (liquidSystem_Beacker_2.available >= 100 && liquidSystem_Beacker_2._molar >= 0.5f)))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    else if ( (Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 3:
                    if ( (Mg_Strip_1.GetComponent<GrabbedObjectDetector>().Isgrabbed && Mg_Strip_2.GetComponent<GrabbedObjectDetector>().Isgrabbed)|| (Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped) )
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 4:
                    if (Mg_Strip_1.GetComponent<DroppedObjectDetector>().IsDropped && Mg_Strip_2.GetComponent<DroppedObjectDetector>().IsDropped)
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 5:
                    //Set Condetion for "Start Part_2"
                    UIActivation(UINum);
                    UINum++;
                    break;
                case 6:
                    //Set Condetion for "Turn on Bunsen burner"
                    UIActivation(UINum);
                    UINum++;
                    break;
                case 7: //2.2 to 3.2
                    if (Mg_Strip_Part_2.GetComponent<FireDetector>().IsBurned) 
                    {
                        Part_2_2.gameObject.SetActive(true);
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 8: //3.2 to 4.2  //Pour water
                    if (((liquidSystem_Beacker_1_Part_2.available >= 250 && liquidSystem_Beacker_1_Part_2._molar < 0.5f) || (liquidSystem_Beacker_2_Part_2.available >= 250 && liquidSystem_Beacker_2_Part_2._molar < 0.5f)))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 9: // 4.2 to 5.2
                    if (liquidSystem_Beacker_1_Part_2.GetComponent<IceCubeDetector>().PutIceNum >= 3 || liquidSystem_Beacker_2_Part_2.GetComponent<IceCubeDetector>().PutIceNum >= 3) 
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 10: // 5.2 to 6.2
                        if (liquidSystem_Beacker_1_Part_2.GetComponent<IceCubeDetector>().DissolvedIceNum >= 3 || liquidSystem_Beacker_2_Part_2.GetComponent<IceCubeDetector>().DissolvedIceNum >= 3)
                        {
                            UIActivation(UINum);
                            UINum++;
                        }
                    break;
                case 11:// 6.2 to 7.2 //Pour hot water
                    if (((liquidSystem_Beacker_1_Part_2.available >= 250 && liquidSystem_Beacker_1_Part_2._molar > 0.5f) || (liquidSystem_Beacker_2_Part_2.available >= 250 && liquidSystem_Beacker_2_Part_2._molar > 0.5f)))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    else if ((Fizzy_C_Tablet_1.GetComponent<DroppedObjectDetector>().IsDropped && Fizzy_C_Tablet_2.GetComponent<DroppedObjectDetector>().IsDropped))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 12:// 7.2 to 8.2
                    if ( (Fizzy_C_Tablet_1.GetComponent<GrabbedObjectDetector>().Isgrabbed && Fizzy_C_Tablet_2.GetComponent<GrabbedObjectDetector>().Isgrabbed) || (Fizzy_C_Tablet_1.GetComponent<DroppedObjectDetector>().IsDropped && Fizzy_C_Tablet_2.GetComponent<DroppedObjectDetector>().IsDropped))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 13: // 8.2 to 9.2
                    if ((Fizzy_C_Tablet_1.GetComponent<DroppedObjectDetector>().IsDropped && Fizzy_C_Tablet_2.GetComponent<DroppedObjectDetector>().IsDropped))
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 14: // 9.2 to 1.3
                    //Set Condetion for "Start Part_3"
                    UIActivation(UINum);
                    UINum++;
                    break;
                case 15:// 1.3 to 2.3
                    //Set Condetion for "Turn on Bunsen burner"
                    UIActivation(UINum);
                    UINum++;
                    break;
                case 16: // 2.3 to 3.3
                    if (Fe_Strip.GetComponent<GrabbedObjectDetector>().Isgrabbed|| Fe_Strip.GetComponent<FireDetector_Fe_Strip>().IsFireDetected) {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 17: // 3.3 to 4.3
                    if (Fe_Strip.GetComponent<FireDetector_Fe_Strip>().IsFireDetected) {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 18: // 4.3 to 5.3
                    if (Spatula_Spoon_Powder.GetComponent<FireDetector_Powder>().IsFireDetected || Powder_For_Test.GetComponent<FireDetector_Powder>().IsFireDetected)
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 19: // 5.3 to 1.4
                    //Set Condetion for "Start Part_4"
                    UIActivation(UINum);
                    UINum++;
                    break;
                case 20: // 1.4 to 2.4
                    if (liquidSystem_Beacker_Part4.available >= 25)
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 21: // 2.4 to 3.4
                    if (_NoticeTime.bNoticeTime)
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
                    break;
                case 22: // 3.4 to 4.4
                    if (Spatula_Spoon_Powder_Part_4.GetComponent<DetectH202>().IsH202Detected || Powder_For_Test_Part_4.GetComponent<DetectH202>().IsH202Detected)
                    {
                        UIActivation(UINum);
                        UINum++;
                    }
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