using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingLeaderboard : MonoBehaviour {
    public Transform target;
    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position);
        float step = speed * Time.deltaTime;

        Debug.Log(transform.position.x + step);
        transform.position.Set(transform.position.x + step, transform.position.y, transform.position.z);
	}
}
