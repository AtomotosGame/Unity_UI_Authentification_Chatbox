using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform [] TabButtons;
    public GameObject [] TabBodys;
    public Sprite ActiveBackground;
    public Sprite DeactiveBackground;
    
    public GameObject showHideGameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectButton (int num) {
        for (int i = 0 ; i < TabButtons.Length; i++ ) {
            TabButtons[i].GetComponent<Image> ().sprite  = DeactiveBackground;
            TabBodys[i].SetActive(false);
        }

        TabButtons[num].GetComponent<Image> ().sprite  = ActiveBackground;
        TabBodys[num].SetActive(true);
    }

    public void show () {
        showHideGameObject.SetActive(true);
    }

    public void hide () {
        showHideGameObject.SetActive(false);
    }
}
