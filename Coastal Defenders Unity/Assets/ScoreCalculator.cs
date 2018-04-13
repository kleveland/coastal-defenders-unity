using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public SolutionController solutiontiers;
    //values go land, human, animal
    private int[] bulkScores = new int[] { 5, 5, 1 };
    private int[] seagrassScores = new int[] { 2, 1, 3 };
    private int[] sandduneScores = new int[] { 3, 2, 3 };
    private int[] sandbagScores = new int[] { 3, 1, 2 };
    public Text scoreText;

    // Use this for initialization
    void Awake()
    {
        int netLand = solutiontiers.bulkheadTier * bulkScores[0] + solutiontiers.seagrassTier * seagrassScores[0] + solutiontiers.sandduneTier * sandduneScores[0] + solutiontiers.sandbagTier * sandbagScores[0];
        int netHuman = solutiontiers.bulkheadTier * bulkScores[1] + solutiontiers.seagrassTier * seagrassScores[1] + solutiontiers.sandduneTier * sandduneScores[1] + solutiontiers.sandbagTier * sandbagScores[1];
        int netAnimal = solutiontiers.bulkheadTier * bulkScores[2] + solutiontiers.seagrassTier * seagrassScores[2] + solutiontiers.sandduneTier * sandduneScores[2] + solutiontiers.sandbagTier * sandbagScores[2];
        scoreText.text = ("Score:" + ( (.5*(netLand/15)) + (.25*(netHuman/15)) + (.25*(netAnimal/15)) ));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
