using UnityEngine;
using System.Collections;
using UnityEditor;

public class Settings : MonoBehaviour {

    public int numberOfPlayers = 2;
    public Material toonShader;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (toonShader == null)
            toonShader = (Material)Resources.Load("Toony-Lighted Outline");
    }
}
