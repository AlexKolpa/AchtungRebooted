using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Level : MonoBehaviour {

    private static readonly float crowdedness = 0.05f;

    public int maxConnectionCount;
    List<LevelConnection> connections = new List<LevelConnection>();
    public List<LevelConnection> Connections
    {
        get { return connections; }
    }

    List<Transform> spawnPoints = new List<Transform>();
    List<Transform> SpawnPoints
    {
        get { return spawnPoints; }
    }

    List<Transform> colliders = new List<Transform>();
    List<Transform> connectionObject = new List<Transform>();

    void Awake()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        Vector2 size = new Vector2(bounds.max.x - bounds.min.x, bounds.max.z - bounds.min.z);
        int numberOfObjects = (int)(crowdedness * size.magnitude) + connections.Count;
        int xSteps = (int)(size.x / size.y * numberOfObjects);
        int ySteps = 
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
