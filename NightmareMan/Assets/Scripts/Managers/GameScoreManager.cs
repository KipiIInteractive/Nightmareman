using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScoreManager : SingletonManager<GameScoreManager> {

	public int score = 0;
	public Text displayScoreText;
	public int foodReward = 10;

	int oldScore = 0;

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