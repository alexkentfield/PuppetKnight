using UnityEngine;
using System.Collections;
 
public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int curHealth = 100;
 
    public float healthBarLength;
 	public Level addExp;
 
    void Start () {
    healthBarLength = Screen.width / 4;
    }
 
 
    void Update () {
    AdjustCurrentHealth(0);
 
		if (curHealth <= 0)
		{
			addExp.curExp += 150;
			Destroy(gameObject);	
		}
    }
 
 
    void OnGUI(){
    GUI.Box(new Rect(10, 300, 150, 20), curHealth + "/" + maxHealth);   
    }
 
 
    public void AdjustCurrentHealth(int adj) {
      curHealth += adj;    
 
       if(curHealth < 0)
         curHealth = 0;

       if(maxHealth > 100)
         maxHealth = 100;
		
       if(curHealth > maxHealth)
         curHealth = maxHealth;
 
       healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}