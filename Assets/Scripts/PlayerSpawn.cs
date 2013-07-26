using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    Settings settings;
    GameObject player;

    void Awake()
    {
        settings = GameObject.Find("GameSettings").GetComponent<Settings>();
        player = GameObject.Find("Player");
    }

	// Use this for initialization
	void Start () {

        if(settings == null)
            settings = GameObject.Find("GameSettings").GetComponent<Settings>();

        player.GetComponent<MeshRenderer>().material = settings.toonShader;
        player.GetComponent<MeshRenderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
