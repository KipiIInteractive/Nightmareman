using UnityEngine;
using System.Collections;

public class LevelConstructorManager : MonoBehaviour {

	public TextAsset  levelWalls;
	public GameObject field; 
	public GameObject wall;
	public GameObject environment;

	void Start() {
		int[,] bitmap = ParseLevelTextAsset(levelWalls);
		GenerateMap (bitmap);
	}

	void GenerateMap(int [,] bitmap){
		int rows = bitmap.GetLength (0);
		int cols = bitmap.GetLength (1);
		
		float cubeSize = wall.transform.localScale.y;
		
		GameObject generatedEnvironment = Instantiate (environment);
		GameObject generatedField = Instantiate (field);
		
		SetParent (generatedEnvironment, generatedField);
		
		generatedField.transform.localScale = new Vector3 (rows, cols, 0);
		
		Vector3 currentPosition = generatedField.transform.position;
		currentPosition.z -= (cols * cubeSize) / 2f - cubeSize / 2;
		currentPosition.x -= (rows * cubeSize) / 2f - cubeSize / 2;
		
		currentPosition.y = cubeSize / 2;
		float startingZ = currentPosition.z;
		
		for (int i = 0; i < rows; i++) {
			currentPosition.z = startingZ;
			for (int k = 0; k < cols; k++) {
				switch (bitmap [i, k]) {
				case 1: 
					CreateNewWall (currentPosition, generatedEnvironment);
					break;
				}
				currentPosition.z += cubeSize;
			}
			currentPosition.x += cubeSize;
		}
	}

	int[,] ParseLevelTextAsset(TextAsset file) {
		string [] context = file.text.Split ("\n".ToCharArray());

		int rows = context.Length;
		int cols = context[0].Length; 

		int [,] levelBitmap = new int[rows, cols];
		for (int i = 0; i < rows; i++) {
			for(int k = 0; k < cols; k++) {
				levelBitmap[i, k] = (int) System.Char.GetNumericValue(context[i][k]);
			}
		}

		return levelBitmap;
	}

	void CreateNewWall(Vector3 currentPosition, GameObject generatedEnvironment) {
		GameObject newObject = Instantiate (wall, currentPosition, wall.transform.rotation) as GameObject;
		SetParent (generatedEnvironment, newObject);
	}

	void SetParent(GameObject parent, GameObject child) {
		child.transform.parent = parent.transform;
	}
}
