using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Level : MonoBehaviour {

    public int maxConnectionCount;
    List<LevelConnection> connections = new List<LevelConnection>();
    public List<LevelConnection> Connections
    {
        get { return connections; }
    }

    public Level()
    {
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
