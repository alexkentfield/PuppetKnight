using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Swiper : MonoBehaviour
{
    float halfScreenWidth;
 	public PlayerAttack pAttack;
	public AudioClip swordAudio;
	public AudioClip swordAudio2;
	
	public struct TouchBegin
	{
		public Vector2 position;
		public int fingerId;
	}
	
	List<TouchBegin> touchBegins = new List<TouchBegin>();
 
    void Start()
    {
        halfScreenWidth =  Screen.width / 2;
		
    }
 
    void Update()
    {		
		//PlayerAttack.isPlayerAttacking = false;
		if (PlayerHealth.alive)
		{
		foreach (Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Began)
			{
				TouchBegin info;
				info.position = t.position;
				info.fingerId = t.fingerId;
				touchBegins.Add(info);
			}
			else if (t.phase == TouchPhase.Ended)
			{
				foreach (TouchBegin tBegin in touchBegins)
				{
					// Find matching touch begin for this particular touch
					if (t.fingerId == tBegin.fingerId)
					{
						// See if the touch ended on the right hand side of the screen
						if (t.position.x > halfScreenWidth)
						{
							// Finger swipe down
							//if (t.position.y > tBegin.position.y)
							if(Input.GetKeyUp(KeyCode.F))
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("OverheadSwing");
								StartCoroutine(myDelay(0.7f));
								AudioSource.PlayClipAtPoint(swordAudio2, transform.position);
								pAttack.Attack();
							}
							else if (Input.GetKeyUp(KeyCode.R))
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("SideSwing");
								StartCoroutine(myDelay(0.7f));
								AudioSource.PlayClipAtPoint(swordAudio, transform.position);
								pAttack.Attack();
							}
							if (t.position.x >= tBegin.position.x + 2)
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("SideSwing", PlayMode.StopAll);
								pAttack.Attack();
								PlayerAttack.isPlayerAttacking = false;
							}
							if (t.position.x <= tBegin.position.x - 2)
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("SideSwing", PlayMode.StopAll);
								pAttack.Attack();
								PlayerAttack.isPlayerAttacking = false;
							}

						}
						// Touch on left hand side of screen
						else
						{
							// Finger swipe down
							if (t.position.y > tBegin.position.y)
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("Block");
								StartCoroutine(myDelay(0.7f));
								pAttack.Attack();

							}
							else
							{
								PlayerAttack.isPlayerAttacking = true;
								animation.Play("Block");
								StartCoroutine(myDelay(0.7f));
								pAttack.Attack();

							}
						}
						touchBegins.Remove(tBegin);
						break;
					}
				}
			}
			else if (t.phase == TouchPhase.Canceled)
			{
				foreach (TouchBegin tBegin in touchBegins)
				{
					// Find matching touch begin for this particular touch
					if (t.fingerId == tBegin.fingerId)
					{

						touchBegins.Remove(tBegin);
						break;
					}
				}
			}
		}
		}
		
	}
	
	public static IEnumerator myDelay( float delayAmount )
	{
		
		yield return new WaitForSeconds(delayAmount);
		PlayerAttack.isPlayerAttacking = false;
	}
}