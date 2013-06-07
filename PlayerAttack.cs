using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class PlayerAttack : MonoBehaviour {
    public List<GameObject> targets;
    public float attackTimer;
    public float coolDown;
	public static bool isPlayerAttacking;
 
    // Use this for initialization
    void Start () {
		attackTimer = 0;
		coolDown =0.0f;
		isPlayerAttacking = false;
 
       GameObject[] enemyTargets = GameObject.FindGameObjectsWithTag("Enemy");
       if (enemyTargets != null)
       {
         foreach(GameObject go in enemyTargets)
         {
          targets.Add(go);
         }
       }
 
		// Use this next block with new "Enemy Tags" to add different enemies
		/*
       GameObject[] moreTargets = GameObject.FindGameObjectsWithTag("Enemy1");
       if (moreTargets != null)
       {
			foreach(GameObject go in moreTargets)
			{
			targets.Add(go);
       }
       } 
		*/
 
    }
 
    void Update () {
 
        if(attackTimer > 0)
            attackTimer -= Time.deltaTime;
 
        if(attackTimer < 0)
            attackTimer = 0;
 
    }

    public void Attack()
    {
		float distance = float.MaxValue;
		if (targets == null) return;
 
       foreach (GameObject target in targets)
       {
         if (target != null)
         {
          distance = Vector3.Distance(target.transform.position, transform.position);
 
          if (distance < 5.0f) 
          {
              EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
              if (eh != null)
              {
                  eh.AdjustCurrentHealth(-45);
              }

          }
        }
      }
		
   }
 
}
