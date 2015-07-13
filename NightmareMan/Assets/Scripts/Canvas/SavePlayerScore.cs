using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SavePlayerScore : MonoBehaviour {

	public Text playerName;

	public void SaveScore() {
		int playerScore = GameScoreManager.Instance.score;
		PlayerScore player = new PlayerScore (playerName.text, playerScore);
		LoadSaveDataList.AddData (player, "playerRanking.data");
		Application.LoadLevel ("Main menu");
	}

}
