using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text netScoreText;
    public RectTransform humanPBar;
    public RectTransform propertyPBar;
    public RectTransform ecoPBar;
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
        netScoreText.text = Mathf.RoundToInt(netScore).ToString();
        if(DiffController.levelselect == 1)
        {
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315*(PlayerPrefs.GetFloat("netHuman") / 20))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 20))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 20))), ecoPBar.offsetMax.y);
        } else if(DiffController.levelselect == 2)
        {
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netHuman") / 30))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 25))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 25))), ecoPBar.offsetMax.y);

        } else if(DiffController.levelselect == 3)
        {
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netHuman") / 15))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 35))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 25))), ecoPBar.offsetMax.y);
        }
        Debug.Log("VALUES");
        Debug.Log((PlayerPrefs.GetFloat("netHuman")));
        Debug.Log((PlayerPrefs.GetFloat("netLand")));
        Debug.Log((PlayerPrefs.GetFloat("netAnimal")));
        Debug.Log(humanPBar.offsetMax);
        Debug.Log(propertyPBar.offsetMax);
        Debug.Log(ecoPBar.offsetMax);

        //humanBar.

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[] getScores()
    {
        int[] val = new int[4];
        val[0] = netScore;
        val[1] = netLandScore;
        val[2] = netAnimalScore;
        val[3] = netHumanScore;
        return val;
    }
}
