using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrayScale : MonoBehaviour
{

    public Transform parent;
    public Material GrayScaleMaterial;
    public Color32 ActiveColor;
    public Color32 DeactiveColor;
    public bool GraySaleFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GreyScale () {
        if (GraySaleFlag) {
            foreach (Transform child in parent) {
                child.GetComponent <Image>().material = GrayScaleMaterial;
                child.Find("ItemDetail").GetComponent <Image>().material = GrayScaleMaterial;
                child.Find("InfoBtn").GetComponent <Image>().material = GrayScaleMaterial;
                child.Find("SM").GetComponent <Image>().material = GrayScaleMaterial;
                child.Find("Title").GetComponent <Text>().color = DeactiveColor;
            }
            GraySaleFlag = false;
        } else {{
            foreach (Transform child in parent) {
                child.GetComponent <Image>().material = null;
                child.Find("ItemDetail").GetComponent <Image>().material = null;
                child.Find("InfoBtn").GetComponent <Image>().material = null;
                child.Find("SM").GetComponent <Image>().material = null;
                child.Find("Title").GetComponent <Text>().color = ActiveColor;
            }
            GraySaleFlag = true;
        }}
    }
}
