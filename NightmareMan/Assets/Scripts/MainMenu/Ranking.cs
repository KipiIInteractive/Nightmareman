using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ranking : MonoBehaviour {

	public void ShowRanking(){
		List<PlayerScore> data = (List<PlayerScore>) LoadSaveDataList.LoadData<PlayerScore> ("playerRanking.data");
		foreach (PlayerScore score in data) {
			print (score.playerName + " " + score.playerScore);
		}
	}
}
