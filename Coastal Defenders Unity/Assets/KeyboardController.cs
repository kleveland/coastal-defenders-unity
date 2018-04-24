using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    private KeyboardKey[] keys;
    private string output;

	// Use this for initialization
	void Start () {
        output = "";
        keys = this.GetComponentsInChildren<KeyboardKey>();
        Debug.Log(keys[0].but);
        for(int i=0; i<keys.Length; i++)
        {
            Debug.Log(keys[i].character);
            string tempStr = keys[i].character;
            keys[i].but.onClick.AddListener(() => { onClickOutput(tempStr); });
            Debug.Log(keys[i].character);
        }
	}

    void onClickOutput(string val)
    {
        if(val.Equals("Back"))
        {
            output = output.Substring(0, output.Length - 1);
        } else if(val.Equals("Enter"))
        {

        } else
        {
            output += val;
        }
        Debug.Log(output);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
