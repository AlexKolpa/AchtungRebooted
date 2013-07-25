using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public int numberOfPlayers = 2;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
