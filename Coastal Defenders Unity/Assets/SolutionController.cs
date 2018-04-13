using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class SolutionController : MonoBehaviour
{
    private PointsController pointsLeftText;
    private Text tierTracker;
    private Button plusButton;
    private Button minusButton;
    public string resourcename;
    public int resourcecount;
    private SpriteRenderer render;
    private Sprite[] resource;
    public int count = 0;
    public int cost;
    private Text costText;
    public int startcount;
    public int bulkheadTier, sandduneTier, sandbagTier, seagrassTier;
    //values go land, human, animal
    private int[] bulkScores = new int[] { 5, 5, 1 };
    private int[] seagrassScores = new int[] { 2, 1, 3 };
    private int[] sandduneScores = new int[] { 3, 2, 3 };
    private int[] sandbagScores = new int[] { 3, 1, 2 };
    private float effectiveness;
    //effectiveness bar display
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(-200, 600);
    public Vector2 size = new Vector2(250, 100);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void Awake()
    {
        Button[] buttons = this.GetComponentsInChildren<Button>();
        Text[] textinp = this.GetComponentsInChildren<Text>();
        tierTracker = textinp[1];
        costText = textinp[0];
        costText.text = cost.ToString();
        plusButton = buttons[0].GetComponent<Button>();
        minusButton = buttons[1].GetComponent<Button>();
        render = GameObject.FindGameObjectWithTag(resourcename).GetComponent<SpriteRenderer>();
        pointsLeftText = GameObject.FindGameObjectWithTag("Points").GetComponent<PointsController>();
        resource = new Sprite[resourcecount];
        for (int i = 0; i < resourcecount; i++)
        {
            resource[i] = Resources.Load<Sprite>("Solutions/" + resourcename + (i + 1));
        }
        plusButton.onClick.AddListener(PlusTaskOnClick);
        minusButton.onClick.AddListener(MinusTaskOnClick);
    }


    void Update()
    {
        if (count == 0)
        {
            render.sprite = null;
        }
        else if (count == 1)
        {
            render.sprite = resource[0];
        }
        else if (count == 2)
        {
            render.sprite = resource[1];
        }
        else if (count == 3)
        {
            render.sprite = resource[2];
        }
        tierTracker.text = count.ToString();
        if (resourcename == "wall")
        {
            bulkheadTier = count;
        }
        else if (resourcename == "sandbag")
        {
            sandbagTier = count;
        }
        else if (resourcename == "seagrass")
        {
            seagrassTier = count;
        }
        else if (resourcename == "sanddune")
        {
            sandduneTier = count;
        }
        barDisplay = returnEffectiveness();
    }

    void PlusTaskOnClick()
    {
        Debug.Log("Clicked plus button");
        Debug.Log("startcount:" + startcount);
        if (count < startcount && count != resourcecount && (pointsLeftText.pointsCount - ((int)(cost * 0.5))) >= 0)
        {
            pointsLeftText.pointsCount += (int)(cost * 0.5);
            count++;
        }
        else if (count != resourcecount && (pointsLeftText.pointsCount - cost) >= 0)
        {
            pointsLeftText.pointsCount -= cost;
            count++;
        }
        if (count >= resource.Length)
        {
            count = 3;
        }
        Debug.Log(count);
    }

    void MinusTaskOnClick()
    {
        Debug.Log("Clicked minus button");
        Debug.Log("startcount:" + startcount);
        if (count <= startcount && count != 0 && (pointsLeftText.pointsCount - ((int)(cost * 0.5))) >= 0)
        {
            pointsLeftText.pointsCount -= (int)(cost * 0.5);
            count--;
        }
        else if (count != 0 && count > startcount)
        {
            pointsLeftText.pointsCount += cost;
            count--;
        }
        if (count < 0)
        {
            count = 0;
        }
        Debug.Log(count);
    }

    private float returnEffectiveness()
    {
        float netLand = bulkheadTier * bulkScores[0] + seagrassTier * seagrassScores[0] + sandduneTier * sandduneScores[0] + sandbagTier * sandbagScores[0];
        float netHuman = bulkheadTier * bulkScores[1] + seagrassTier * seagrassScores[1] + sandduneTier * sandduneScores[1] + sandbagTier * sandbagScores[1];
        float netAnimal = bulkheadTier * bulkScores[2] + seagrassTier * seagrassScores[2] + sandduneTier * sandduneScores[2] + sandbagTier * sandbagScores[2];
        return effectiveness = (((.5f * (netLand / 15f)) + (.25f * (netHuman / 15f)) + (.25f * (netAnimal / 15f))));
    }

    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }
}
