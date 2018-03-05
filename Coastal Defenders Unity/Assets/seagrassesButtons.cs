using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class seagrassesButtons : MonoBehaviour {

    public Button plusButton;
    public Button minusButton;
    public Sprite[] seagrasses;
    public SpriteRenderer render;
    private int count = 0;

    void Awake()
    {
        Button plusbtn = plusButton.GetComponent<Button>();
        Button minusbtn = minusButton.GetComponent<Button>();
        plusbtn.onClick.AddListener(PlusTaskOnClick);
        minusbtn.onClick.AddListener(MinusTaskOnClick);
        

    }

    void Update()
    {
        if (count == 0)
        {
            render.sprite = null;
        }
        else if (count == 1)
        {
            render.sprite = seagrasses[0];
        }
        else if (count == 2)
        {
            render.sprite = seagrasses[1];

        }
        else if (count == 3)
        {
            render.sprite = seagrasses[2];

        }
    }

    void PlusTaskOnClick()
    {
        Debug.Log("Clicked plus button");
        count++;
      
        if (count >= seagrasses.Length)
        {
            count = 3;
    
       
            
        }  
        Debug.Log(count);

    }
    void MinusTaskOnClick()
    {
        Debug.Log("Clicked minus button");
        count--;
        if (count < 0)
        {
            count = 0;
            
        }

        Debug.Log(count);
    }
}
