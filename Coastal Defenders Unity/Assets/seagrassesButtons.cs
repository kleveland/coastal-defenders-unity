﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class seagrassesButtons : MonoBehaviour
{
    public int pointsLeft = 100;
    public Text pointsLeftText;
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
            pointsLeftText.text = ("Points: " + pointsLeft);
        }
        else if (count == 1)
        {
            render.sprite = seagrasses[0];
            pointsLeftText.text = ("Points: " + pointsLeft);
        }
        else if (count == 2)
        {
            render.sprite = seagrasses[1];
            pointsLeftText.text = ("Points: " + pointsLeft);
        }
        else if (count == 3)
        {
            render.sprite = seagrasses[2];
            pointsLeftText.text = ("Points: " + pointsLeft);
        }
    }

    void PlusTaskOnClick()
    {
        Debug.Log("Clicked plus button");
        pointsLeft -= 10;
        count++;
        if (count >= seagrasses.Length)
        {
            count = 3;
            pointsLeft += 10;
        }
        Debug.Log(count);
    }

    void MinusTaskOnClick()
    {
        Debug.Log("Clicked minus button");
        pointsLeft += 10;
        count--;
        if (count < 0)
        {
            count = 0;
            pointsLeft -= 10;
        }
        Debug.Log(count);
    }
}
