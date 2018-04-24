using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text scoreText;
    private float netScore;
    // Use this for initialization
    void Awake()
    {
        netScore = 620f * Mathf.Log10(PlayerPrefs.GetFloat("netLand") + 1) + 620 * Mathf.Log10(PlayerPrefs.GetFloat("netAnimal") + 1) + 620f * Mathf.Log10(PlayerPrefs.GetFloat("netHuman") + 1);

        PlayerPrefs.SetFloat("netScore", Mathf.RoundToInt(netScore));
        scoreText.text = "Score: " + Mathf.RoundToInt(netScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
