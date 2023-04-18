using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector_Fe_Strip : MonoBehaviour
{
    [System.NonSerialized] public bool IsBurned;
    bool IsExit;
    Material _Material;
    private float colorHue = 255;
    public bool IsFireDetected;
    private void Start()
    {
        _Material = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }
    //private void Update()
    //{
    //    if (IsExit)
    //    {
    //        if ( (colorHue +Time.deltaTime )* 5 < 255)
    //        {
    //            colorHue += Time.deltaTime * 5;

    //            _Material.SetColor("_BaseColor", new Color(255, colorHue, colorHue, 255));
    //        }
    //        else
    //        {
    //            IsExit = false;
    //        }
    //    }

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Debug.Log("jjjjjj");
            _Material.SetColor("_BaseColor", new Color(255.0f,0, 0, 255.0f));

           // StartCoroutine(WaitforColorChange(1.0f));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            IsExit = true;
            _Material.SetColor("_BaseColor", new Color(255.0f, 255.0f, 255.0f, 255.0f));
            IsFireDetected = true;
        }
    }
    private IEnumerator WaitforColorChange(float waitTime)
    {

            yield return new WaitForSeconds(waitTime);
            if (colorHue -10 > 0)
            {
                colorHue -= 10;
                Debug.Log("color.... " + colorHue);

                _Material.SetColor("_BaseColor", new Color(255, colorHue, colorHue, 255));
                if (!IsExit)
                {
                    StartCoroutine(WaitforColorChange(1.0f));
                }
            }


    }
}
