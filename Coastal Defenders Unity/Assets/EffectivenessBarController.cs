using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectivenessBarController : MonoBehaviour
{
    private float barDisplay;
    private float netLand, netHuman, netAnimal;
    public float minX;
    public float maxX;

    private float target;
    public RectTransform effBar;
    private Vector2 init;
    public float speed;
    //0 dune
    //1 oyster
    //2 bulkhead
    //3 floodgate
    //4 seagrass
    public SolutionController[] solutions;

    //values go land, human, animal
    public float[] bulkheadScores = new float[] { 5, 5, 1 };
    public float[] seagrassScores = new float[] { 2, 1, 3 };
    public float[] sandduneScores = new float[] { 3, 2, 4 };
    public float[] floodgateScores = new float[] { 4, 3, 2 };
    public float[] oysterScores = new float[] { 1, 2, 5 };
    // Use this for initialization
    void Awake()
    {
        effBar = this.GetComponent<RectTransform>();
    }

    private float returnEffectiveness()
    {
        netLand = solutions[0].count * sandduneScores[0] + solutions[1].count * oysterScores[0] + solutions[2].count * bulkheadScores[0] + solutions[3].count * floodgateScores[0] + solutions[4].count * seagrassScores[0];
        netHuman = solutions[0].count * sandduneScores[1] + solutions[1].count * oysterScores[1] + solutions[2].count * bulkheadScores[1] + solutions[3].count * floodgateScores[1] + solutions[4].count * seagrassScores[1];
        netAnimal = solutions[0].count * sandduneScores[2] + solutions[1].count * oysterScores[2] + solutions[2].count * bulkheadScores[2] + solutions[3].count * floodgateScores[2] + solutions[4].count * seagrassScores[2];
        PlayerPrefs.SetFloat("netLand", netLand);
        PlayerPrefs.SetFloat("netHuman", netHuman);
        PlayerPrefs.SetFloat("netAnimal", netAnimal);
        //Debug.Log("netLand:" + netLand + "\n netHuman:" + netHuman + "\n netAnimal:" + netAnimal);
        return ((.5f * (netLand / 25f)) + (.25f * (netHuman / 25f)) + (.25f * (netAnimal / 25f)));

    }

    // Update is called once per frame
    void Update()
    {
        float diffX = maxX - minX;
        barDisplay = returnEffectiveness();
        //Debug.Log("barDisplay: " + barDisplay);
        //600 is difference
        target = barDisplay * diffX + minX;

        //Debug.Log("Target:" + target);

        if (effBar.localPosition.x <= (target - speed / 2))
        {
            effBar.localPosition = new Vector2(effBar.localPosition.x + speed, effBar.localPosition.y);
        }
        else if (effBar.localPosition.x >= (target + speed / 2))
        {
            effBar.localPosition = new Vector2(effBar.localPosition.x - speed, effBar.localPosition.y);
        }

    }
}
