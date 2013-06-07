using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	
	private int curLevel = 1;
	private int maxLevel;
	
	public int curExp = 1;
	private int maxExp = 100;
	
	void Start () {
		//maxLevel = 40;
	}
	
	void Update () {
		if(curExp >= maxExp)
		{
			curExp -= maxExp;
			curLevel++;
		}
	}
	
	void OnGUI ()
	{
		GUI.Box (new Rect(200, 30, 100, 20), curExp + " / " + maxExp);
		GUI.Box (new Rect(200, 90, 100, 20), "Level: " + curLevel);
	}
	
}
