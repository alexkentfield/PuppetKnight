using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	
		public GameObject target;
		public float attackTime;
		public float coolDown;
	
	void Start () {
		attackTime = 0;
		coolDown = 2.0f;
	}
	
	void Update () {
		if(attackTime > 0)
			attackTime -= Time.deltaTime;
		
		if(attackTime < 0)
			attackTime = 0;
		
		if(attackTime == 0) {
			Attack();
			attackTime = coolDown;
		}
	}
	
 	private void Attack() {

		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
			
		if(distance < 5.0f) {
			if(direction > 0) { 
				PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
				ph.AdjustCurrentHealth(-10);
			}
		}
    }
}