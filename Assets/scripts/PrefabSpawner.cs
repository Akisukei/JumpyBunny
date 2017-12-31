using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour {

    private float nextSpawnTime = 0;

    public Transform[] prefabs;
    public float spawnRate = 1;
    public float randomDelay = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > nextSpawnTime)
        {
            if(prefabs.Length > 0) {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
            }
           
            nextSpawnTime = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
	}
}
