using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


 

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LevelSpawn : MonoBehaviour {

    private static readonly float defaultSize = 5f;

    Settings gameSettings;
    public GameObject level;

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

        ConstructWorld(gameSettings.numberOfPlayers);
    }


	// Use this for initialization
	void Start () {                
	}

    void ConstructWorld(int players = 2)
    {
        int levelAmount = players * 2 + 2;

        float levelRadius = players * defaultSize;
        float levelDistance = levelRadius;

        GameObject levels = new GameObject("Levels");

        bool[, ,] isTaken = new bool[levelAmount / 2, levelAmount / 2, levelAmount / 2];

        List<Level> levelList = new List<Level>();
        for (int i = 0; i < levelAmount; i++)
        {
            int x = Random.Range(0, levelAmount / 2);
            int y = Random.Range(0, levelAmount / 2);
            int z = Random.Range(0, levelAmount / 2);

            while (isTaken[x, y, z])
            {
                x = Random.Range(0, levelAmount / 2);
                y = Random.Range(0, levelAmount / 2);
                z = Random.Range(0, levelAmount / 2);
            }

            isTaken[x, y, z] = true;

            Vector3 position = new Vector3(x, y, z);
            position.Scale(new Vector3(levelDistance,levelDistance / 2, levelDistance));
            Vector3 offset = Random.insideUnitSphere;
            offset.Scale(new Vector3(2, 0.5f, 2));
            position += offset;

            GameObject inst = Instantiate(level, position, Quaternion.identity) as GameObject;
            inst.name = "Level";
            inst.transform.parent = levels.transform;
            Level levelScript = inst.AddComponent<Level>();            
            ConstructLevelGround(inst, levelRadius);
            levelScript.maxConnectionCount = Random.Range(1, levelAmount);
            levelList.Add(levelScript);
        }

        ConstructLinks(levelList);
    }

    void ConstructLevelGround(GameObject levelInst, float levelRadius)
    {   
        //TODO: Adjust Mesh
        Vector3[] verts = levelInst.GetComponent<MeshFilter>().mesh.vertices;

        float x = Random.Range(0.3f, 0.6f);
        float z = Random.Range(0.3f, 0.6f);

        Vector3 scale = new Vector3(x, 0, z);
        scale.Normalize();
        scale *= levelRadius;
        scale.y = 0.5f;
		
        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].Scale(scale);
        }

        levelInst.GetComponent<MeshFilter>().mesh.vertices = verts;
        levelInst.GetComponent<BoxCollider>().size = scale;
    }

    /// <summary>
    /// Links the separate levels. Each level can use this data 
    /// </summary>
    /// <param name="levelList"></param>
    void ConstructLinks(List<Level> levelList)
    {
        List<Level> levelWithFreeConnections = new List<Level>(levelList.ToArray());

        while (levelWithFreeConnections.Count > 0)
        {
            Level lev1 = levelWithFreeConnections[Random.Range(0, levelWithFreeConnections.Count)];
            Level lev2 = levelWithFreeConnections[Random.Range(0, levelWithFreeConnections.Count)];
			
			if(lev1 == lev2)
				continue;
			
            LevelConnection connection = new LevelConnection(lev1, lev2);
            lev1.Connections.Add(connection);
            lev2.Connections.Add(connection);

            if (lev1.maxConnectionCount == lev1.Connections.Count)
                levelWithFreeConnections.Remove(lev1);

            if (lev2.maxConnectionCount == lev2.Connections.Count)
                levelWithFreeConnections.Remove(lev2);

            if (levelWithFreeConnections.Count == 1)
                break;
        }
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
