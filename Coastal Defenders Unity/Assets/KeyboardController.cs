using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour {

    private KeyboardKey[] keys;
    private string output;
    public Button slideButton;
    public Text initials;
    private RectTransform trans;
    private bool slide;

	// Use this for initialization
	void Start () {
        slide = true;
        trans = this.GetComponent<RectTransform>();
        output = "";
        keys = this.GetComponentsInChildren<KeyboardKey>();
        Debug.Log(keys[0].but);
        slideButton.onClick.AddListener(setSlide);
        for(int i=0; i<keys.Length; i++)
        {
            Debug.Log(keys[i].character);
            string tempStr = keys[i].character;
            keys[i].but.onClick.AddListener(() => { onClickOutput(tempStr); });
            Debug.Log(keys[i].character);
        }
	}

    void setSlide()
    {
        slide = !slide;
    }

    void onClickOutput(string val)
    {
        Debug.Log(output.Length+1);
        if(val.Equals("Back"))
        {
            output = output.Substring(0, output.Length - 1);
        } else if(val.Equals("Enter"))
        {

        } else if((output.Length+1) <= 2)
        {
            output += val;
        }
        Debug.Log(output);
        initials.text = output;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(trans.localPosition);
        if (slide && trans.localPosition.y >= -840)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y - 20);
        }
        else if (!slide && trans.localPosition.y <= -20)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y + 20);

        }
    }
}
