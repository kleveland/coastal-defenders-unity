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
    }

    void PlusTaskOnClick()
    {
        Debug.Log("Clicked plus button");
        Debug.Log("startcount:" + startcount);
        if (count < startcount && count != resourcecount)
        {
            if ((pointsLeftText.pointsCount - ((int)(cost * 0.5))) >= 0)
            {
                pointsLeftText.pointsCount -= (int)(cost * 0.5);
                count++;
            }
        }
        else if (count != resourcecount)
        {
            if ((pointsLeftText.pointsCount - cost) >= 0)
            {
                pointsLeftText.pointsCount -= cost;
                count++;
            }
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
        if (count <= startcount && count != 0)
        {
            pointsLeftText.pointsCount += (int)(cost * 0.5);
        }
        else if (count != 0)
        {
            pointsLeftText.pointsCount += cost;
        }
        count--;
        if (count < 0)
        {
            count = 0;
        }
        Debug.Log(count);
    }
}
