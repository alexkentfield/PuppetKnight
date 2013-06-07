using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	public Texture2D menuBackground;
	public GUIStyle menuStyle = new GUIStyle();
	public GUIStyle newGameButton = new GUIStyle();
	public GUIStyle loadGameButton = new GUIStyle();
	public GUIStyle settingsButton = new GUIStyle();


	void Start()
	{
		menuStyle.normal.background = menuBackground;
	}

	void OnGUI () {
		GUI.depth = -15;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),"", menuStyle);

			if (GUI.Button(new Rect(Screen.width * 0.06f,Screen.height * 0.3f,260,100),"",newGameButton))
			{
				Application.LoadLevel("PK_KnightTrials");
			}
			if (GUI.Button(new Rect(Screen.width * 0.06f,Screen.height * 0.5f,260,100),"",loadGameButton))
			{
				//load game
				//Application.LoadLevel("loadGame");
			}
			if (GUI.Button(new Rect(Screen.width * 0.06f,Screen.height * 0.72f,260,100),"",settingsButton))
			{
				//Application.LoadLevel("settingsScene");
			}
	}
}