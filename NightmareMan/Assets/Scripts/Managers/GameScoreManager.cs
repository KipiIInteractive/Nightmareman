using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScoreManager : MonoBehaviour {

	public static GameScoreManager Instance { get; set; }
	public int score = 0;
	public Text displayScoreText;
	public int foodReward = 10;

	int oldScore = 0;

	void Awake() {
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
	}
	
	void Update ()
	{
		if (score != oldScore) {
			displayScoreText.text = "Score : " + score;
			oldScore = score;
		}
	}

	public void EatFoodDot() {
		score += foodReward;
	}
}