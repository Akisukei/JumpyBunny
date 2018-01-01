using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {

    private float nextSpawnTime = 0;
    private float startTime;

    public Transform[] prefabs;
    public AnimationCurve spawnCurve;
    public float curveLengthInSecs = 30f;
    public float jitter = 0.25f;

    // Use this for initialization
    void Start () {
        this.startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > nextSpawnTime)
        {
            if(prefabs.Length > 0) {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
            }

            float curvePositionX = (Time.time - startTime) / curveLengthInSecs;
            if(curvePositionX > 1f)
            {
                curvePositionX = 1f;
            }

            nextSpawnTime = Time.time + spawnCurve.Evaluate(curvePositionX) + Random.Range(-jitter, jitter);
        }
	}
}
