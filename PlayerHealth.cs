using UnityEngine;
using System.Collections;
 
public class PlayerHealth : MonoBehaviour {
      
	public GUIStyle PlayercurhealthplaceH;
    public GUIStyle Playercurhealthtext;
    public int MaxHealth = 100;
    public int CurHealth = 100;
    public float HealthBarLength;
	public static bool alive = true;
	
	public int Money = 0;
 
 
	void Start(){
 
    HealthBarLength = Screen.width / 3; 
 
    }
 
    public void Update() {

		if (CurHealth <= 0)
		{
			animation.Play("Death", PlayMode.StopAll);
		}
	}
  
    void OnGUI(){

		//Heath bar
		//This is where you put the background image
		GUI.Box(new Rect(Screen.width * 0.23f, Screen.height * 0.62f, Screen.width / 2, Screen.height / 3) ,"", PlayercurhealthplaceH);

        //This is where you put the foreground image, the green bar by itself.
		GUI.Box(new Rect(Screen.width * 0.315f, Screen.height * 0.73f, HealthBarLength, 40), "", Playercurhealthtext);
		
		GUI.Box(new Rect(0, 100, 200, 40) ,"Gold: " + Money); 
 
    }
 
   public void AdjustCurrentHealth(int Adj) {
 
       CurHealth += Adj;
 
       if (CurHealth <0)
         CurHealth = 0;
       if(CurHealth > MaxHealth)
         CurHealth = MaxHealth;
       if(MaxHealth < 1)
         MaxHealth = 1;
 
       HealthBarLength = (Screen.width / 3) * (CurHealth/(float)MaxHealth);
     }
	
	void OnTriggerEnter(Collider other)
	{
		switch(other.gameObject.tag)
		{
		case "Heal":
			AdjustCurrentHealth(25);
			break;
		case "Hurt":
			AdjustCurrentHealth(-25);
			break;
		case "Money":
			Money += 25;
			break;
		}
		Destroy(other.gameObject);
	}
 

}