using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRecycler : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < endPoint.position.x)
        {
            float gap = endPoint.position.x - transform.position.x;
            transform.position = new Vector2(startPoint.position.x - gap, transform.position.y);
        }
	}
}
