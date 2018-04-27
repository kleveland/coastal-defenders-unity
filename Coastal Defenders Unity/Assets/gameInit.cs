using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInit : MonoBehaviour {

    private SolutionController[] solutionList;
    private PointsController points;
    // Use this for initialization
    void Start ()
    {
        Debug.Log("DIFFICULTY");
        Debug.Log(DiffController.levelselect);
        points = GameObject.FindGameObjectWithTag("Points").GetComponent<PointsController>();
        solutionList = this.gameObject.GetComponentsInChildren<SolutionController>();
        switch(DiffController.levelselect)
        {
            case 1:
                points.pointsCount = 120;
                break;

            case 2:
                points.pointsCount = 100;
                break;

            case 3:
                points.pointsCount = 80;
                break;

            default:
                points.pointsCount = 120;
                break;
        }

        solutionList[0].count = Random.Range(0, 2);
        solutionList[1].count = Random.Range(0, 2);
        solutionList[2].count = Random.Range(0, 1);
        solutionList[3].count = Random.Range(0, 1);
        solutionList[4].count = Random.Range(1, 2);
        solutionList[0].startcount = solutionList[0].count;
        solutionList[1].startcount = solutionList[1].count;
        solutionList[2].startcount = solutionList[2].count;
        solutionList[3].startcount = solutionList[3].count;
        solutionList[4].startcount = solutionList[4].count;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
