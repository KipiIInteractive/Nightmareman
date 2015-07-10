using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameObject player = other.gameObject;
			player.GetComponent<NightmareHealth>().TakeDamage();
		}
	}
}
