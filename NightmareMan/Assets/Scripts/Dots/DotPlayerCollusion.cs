using UnityEngine;
using System.Collections;

public class DotPlayerCollusion : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			// TODO alert the score manager
			Destroy(gameObject);
		}
	}
}
