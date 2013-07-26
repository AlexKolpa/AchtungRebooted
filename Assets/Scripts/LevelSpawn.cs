using UnityEngine;
using System.Collections;
using UnityEditor;


 

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LevelSpawn : MonoBehaviour {

    Settings gameSettings;

    void Awake()
    {
        GameObject settings = GameObject.Find("GameSettings");
        if(settings == null)
        {
            settings = new GameObject("GameSettings");
            settings.AddComponent<Settings>();

            if (Selection.activeTransform != null)
                settings.transform.parent = Selection.activeTransform;
        }

        gameSettings = settings.GetComponent<Settings>();
    }


	// Use this for initialization
	void Start () {
        
        ConstructWorld();
	}

    void ConstructWorld()
    {
        int playerAmount = gameSettings.numberOfPlayers;

        int levelAmount = playerAmount * 2 + 2;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        for (int i = 0; i < levelAmount; i++)
        {            
            GameObject cubeInst = Instantiate(cube, Random.insideUnitSphere * 10, Quaternion.identity) as GameObject;
            cubeInst.GetComponent<MeshRenderer>().material = gameSettings.toonShader;
            cubeInst.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        Destroy(cube);
    }

    // Update is called once per frame
    void Update()
    {
		
	}

    #if UNITY_EDITOR
    [ContextMenu("Construct levels")]
    void Construct()
    {
        ConstructWorld();
    }
    #endif
}
