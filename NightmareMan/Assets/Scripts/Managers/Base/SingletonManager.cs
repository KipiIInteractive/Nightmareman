using UnityEngine;
using System.Collections;

public abstract class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T> {

	public static T Instance { get; private set; }

	protected void Awake () {
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = (T) FindObjectOfType(typeof(T));
		}
	}
}
