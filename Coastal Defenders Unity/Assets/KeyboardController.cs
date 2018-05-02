using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
            StartCoroutine(Upload(output,1000,200,300,500));
        } else if((output.Length+1) <= 2)
        {
            output += val;
        }
        Debug.Log(output);
        initials.text = output;
    }
    IEnumerator Upload(string initials, int total_score, int land_saved_score, int human_protection_score, int animal_protection_score)
    {
        WWWForm form = new WWWForm();
        form.AddField("initials", initials);
        form.AddField("total_score", total_score);
        form.AddField("land_saved_score", land_saved_score);
        form.AddField("human_protection_score", human_protection_score);
        form.AddField("animal_protection_score", animal_protection_score);

        UnityWebRequest www = UnityWebRequest.Post("localhost:4000/leaderboardpost", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slide && trans.localPosition.y >= -840)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y - 20);
        }
        else if (!slide && trans.localPosition.y <= -90)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y + 20);

        }
    }
}
