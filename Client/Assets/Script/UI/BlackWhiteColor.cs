using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackWhiteColor : MonoBehaviour
{

    public GameObject Parent;
    public bool GreyColorFalg = true;

    //These are the Sliders that control the values. Remember to attach them in the Inspector window.

    void Start()
    {

    }

    void Update()
    {
       
    }

    public void ChangeBlackWhiteColor () {
        if (GreyColorFalg) {
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = Color.gray;
                GreyColorFalg = false;
            }
        } else {
            foreach (Transform child in transform)
            {
                child.GetComponent<Image>().color = new Color32(255,255,255,255);
                GreyColorFalg = true;
            }
        }
    }

}
