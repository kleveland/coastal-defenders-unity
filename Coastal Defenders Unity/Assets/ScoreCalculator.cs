using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text netScoreText;
    public Text subScoreText;
    private float netScore;
    private float netLandScore;
    private float netAnimalScore;
    private float netHumanScore;
    // Use this for initialization
    void Awake()
    {
        netLandScore = 620f * Mathf.Log10(PlayerPrefs.GetFloat("netLand") + 1);
        netAnimalScore = 620 * Mathf.Log10(PlayerPrefs.GetFloat("netAnimal") + 1);
        netHumanScore = 620f * Mathf.Log10(PlayerPrefs.GetFloat("netHuman") + 1);
        netScore = netLandScore + netHumanScore + netAnimalScore;

        PlayerPrefs.SetFloat("netScore", Mathf.RoundToInt(netScore));
        netScoreText.text = "Your Score\n<size=86> " + Mathf.RoundToInt(netScore)+"</size>";

        subScoreText.text = "Land Score: " + Mathf.RoundToInt(netLandScore) + "\nHuman Score: " + Mathf.RoundToInt(netHumanScore) + "\nAnimal Score: " + Mathf.RoundToInt(netAnimalScore);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
