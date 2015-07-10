using UnityEngine;
using System.Collections;

public class EnemyMovementManager : SingletonManager<EnemyMovementManager> {

	public GameObject [] scatterPoints;

	new void Awake() {
		base.Awake ();
		scatterPoints = GameObject.FindGameObjectsWithTag ("EnemyMovementPoint");
	}

	public Transform GetRandomChasePoint() {
		int index = Random.Range (0, scatterPoints.Length);
		return scatterPoints [index].transform;
	}

}
