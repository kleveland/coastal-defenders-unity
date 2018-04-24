using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectivenessBar : MonoBehaviour
{
    private float barDisplay;
    //public Vector2 pos = new Vector2(-200, 600);
    //public Vector2 size = new Vector2(250, 100);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    public SolutionController[] solutions;

    //values go land, human, animal
    public int[] bulkScores = new int[] { 5, 5, 1 };
    public int[] seagrassScores = new int[] { 2, 1, 3 };
    public int[] sandduneScores = new int[] { 3, 2, 4 };
    public int[] sandbagScores = new int[] { 3, 1, 2 };
    public int[] oysterScores = new int[] { 1, 2, 5 };
    // Use this for initialization
    void Awake()
    {

    }

    void OnGUI()
    {
        //draw the background
        /*
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
        */
    }

    // Update is called once per frame
}
