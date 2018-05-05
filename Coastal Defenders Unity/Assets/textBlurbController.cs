using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBlurbController : MonoBehaviour {

    public Text blurb;
    public Image button;
    public Sprite[] buttons = new Sprite[3];
	// Use this for initialization
	void Start () {
		switch(DiffController.levelselect)
        {
            case 1:
                blurb.text = "case1";
                button.sprite = buttons[0];
                break;
            case 2:
                blurb.text = "case2";
                button.sprite = buttons[1];
                break;
            case 3:
                blurb.text = "case3";
                button.sprite = buttons[2];
                break;
            default:
                blurb.text = "case1";
                button.sprite = buttons[0];
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
