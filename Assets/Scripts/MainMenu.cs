using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUIStyle menuStyle;

    public Settings settings;

    void OnStart()
    {
        settings = GameObject.Find("GameSettings").GetComponent<Settings>();
    }

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 80), "Achtung, Rebooted!", menuStyle );

        GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 20, 100, 80), "Number of players: ", menuStyle);

        settings.numberOfPlayers = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 20, 100, 80), settings.numberOfPlayers, 2, 8);

        GUI.Label(new Rect(Screen.width / 2 + 80, Screen.height / 2 + 20, 80, 80), settings.numberOfPlayers.ToString(), menuStyle);

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 60, 100, 40), "Play Game!", menuStyle))
        {
            Application.LoadLevel("Match");
        }
	}
}
