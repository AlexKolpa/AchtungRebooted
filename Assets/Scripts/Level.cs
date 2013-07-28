using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Level : MonoBehaviour {

    private static readonly float crowdedness = 0.05f;
    public float scale = 1.0f;
    public bool rebuild = false;

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
        ConstructLevel();
    }

    void ConstructLevel()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        Vector2 size = new Vector2(bounds.max.x - bounds.min.x, bounds.max.z - bounds.min.z);
        
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                float value = Mathf.PerlinNoise(x / size.x * scale, y / size.y * scale);
                if (value > 1 - crowdedness)
                {

                }                
            }
        }
    }



    // Use this for initialization
    void Start()
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
