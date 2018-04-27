using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text netScoreText;
    public Text subScoreText;
    public int[] defenseThresholds_1;
    public int[] defenseThresholds_2;
    public int[] defenseThresholds_3;
    public Image humanBar;
    public Image propertyBar;
    public Image ecosystemBar;
    private int netScore;
    private int netLandScore;
    private int netAnimalScore;
    private int netHumanScore;

    // Use this for initialization
    void Awake()
    {
        netLandScore = Mathf.RoundToInt(620f * Mathf.Log10(PlayerPrefs.GetFloat("netLand") + 1));
        netAnimalScore = Mathf.RoundToInt(620 * Mathf.Log10(PlayerPrefs.GetFloat("netAnimal") + 1));
        netHumanScore = Mathf.RoundToInt(620f * Mathf.Log10(PlayerPrefs.GetFloat("netHuman") + 1));
        netScore = netLandScore + netHumanScore + netAnimalScore;
        PlayerPrefs.SetFloat("netScore", netScore);
        netScoreText.text = "Your Score\n<size=86> " + Mathf.RoundToInt(netScore) + "</size>";

        subScoreText.text = "Land Score: " + Mathf.RoundToInt(netLandScore) + "\nHuman Score: " + Mathf.RoundToInt(netHumanScore) + "\nAnimal Score: " + Mathf.RoundToInt(netAnimalScore);
        //humanBar.

    }

    // Update is called once per frame
    void Update()
    {

    }
}
