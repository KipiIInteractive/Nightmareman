using UnityEngine;
using System.Collections;

public class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T> {

	public static T Instance { get; private set; }

	void Awake () {
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = (T) FindObjectOfType(typeof(T));
		}
	}
}
