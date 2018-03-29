using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInit : MonoBehaviour {

    private SolutionController[] solutionList;
	// Use this for initialization
	void Start () {
        solutionList = this.gameObject.GetComponentsInChildren<SolutionController>();
        for(int i=0; i<solutionList.Length; i++)
        {
            solutionList[i].count = Random.Range(0, 3);
            solutionList[i].startcount = solutionList[i].count;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
