using UnityEngine;
using System.Collections;

public class LevelConstructorManager : MonoBehaviour {

	public TextAsset  fileLevel;
	public GameObject field; 
	public GameObject wall;
	public GameObject environment;
	public GameObject spawnPoint;
	public GameObject enemyScatterPoint;
	public GameObject teleportEnter;
	public GameObject teleportExit;
	public GameObject enemyFollowDots;
	public GameObject PlayerFood;

	void Start() {
		char[,] bitmap = ParseLevelTextAsset(fileLevel);
		GenerateMap (bitmap);
	}

	void GenerateMap(char [,] bitmap){
		int rows = bitmap.GetLength (0);
		int cols = bitmap.GetLength (1);
		
		float cubeSize = wall.transform.localScale.y;
		
		GameObject generatedEnvironment = Instantiate (environment);
		GameObject generatedField = Instantiate (field);
		field.isStatic = true;

		SetParent (generatedEnvironment, generatedField);
		
		generatedField.transform.localScale = new Vector3 (rows, cols, 0);
		
		Vector3 currentPosition = generatedField.transform.position;
		currentPosition.z -= (cols * cubeSize) / 2f - cubeSize / 2;
		currentPosition.x -= (rows * cubeSize) / 2f - cubeSize / 2;
		
		currentPosition.y = cubeSize / 2;
		float startingZ = currentPosition.z;

		GameObject staticObjects = new GameObject("ImmutableObjects");
		SetParent (generatedEnvironment, staticObjects);

		for (int i = 0; i < rows; i++) {
			currentPosition.z = startingZ;
			for (int k = 0; k < cols; k++) {
				switch (bitmap [i, k]) {
				case '0':
					CreateBlock (currentPosition, staticObjects, PlayerFood);
					break;
				case '1': // wall
					CreateBlock (currentPosition, staticObjects, wall, true);
					break;
				case '2': // player spawn point
					CreateBlock (currentPosition, generatedEnvironment, spawnPoint);
					SpawnPlayerManager.Instance.spawnPoint = spawnPoint.transform;
					break;
				case '3': // enemy spawn point
					CreateBlock (currentPosition, generatedEnvironment, spawnPoint);
					SpawnEnemyManager.Instance.spawnPoint = spawnPoint.transform;
					break;
				case '4': // for scatter
					CreateBlock (currentPosition, generatedEnvironment, enemyScatterPoint);
					break;
				case '5': // teleport enter
					CreateBlock (currentPosition, generatedEnvironment, teleportEnter);
					break;
				case '6': // teleport exit
					CreateBlock (currentPosition, generatedEnvironment, teleportExit);
					break;
				case '7': // enemy follow dots
					CreateBlock (currentPosition, generatedEnvironment, enemyFollowDots);
					break;
				}
				currentPosition.z += cubeSize;
			}
			currentPosition.x += cubeSize;
		}
	}

	char[,] ParseLevelTextAsset(TextAsset file) {
		string [] context = SplitByLines(file.text);

		int rows = context.Length;
		int cols = context[0].Length; 

		char [,] levelBitmap = new char[rows, cols];
		for (int i = 0; i < rows; i++) {
			for(int k = 0; k < cols; k++) {
				levelBitmap[i, k] = context[i][k];
			}
		}

		return levelBitmap;
	}

	GameObject CreateBlock(Vector3 position, GameObject environment, GameObject prefab, 
	                 bool isStatic = false, string objectTag = "Untagged") 
	{
		GameObject newObject = Instantiate (prefab, position, wall.transform.rotation) as GameObject;
		newObject.tag = objectTag;
		newObject.isStatic = isStatic;
		SetParent (environment, newObject);
		return newObject;
	}

	string [] SplitByLines(string text) {
		return text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None);
	}

	void SetParent(GameObject parent, GameObject child) {
		child.transform.parent = parent.transform;
	}
}
