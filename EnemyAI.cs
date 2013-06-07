using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	private Transform myTransform;
	
	void Awake(){
		myTransform = transform;
	}

	void Start () {

		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		maxDistance = 10;
	}
	
	void Update () {

		Debug.DrawLine(target.position, myTransform.position, Color.red); 
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		if(Vector3.Distance(target.position, myTransform.position) < maxDistance)
		{
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	
		}
	}
		
}