using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LoadSaveData {

	public static void SaveData<T>(T data, string fileName) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + fileName);
		bf.Serialize (file, data);
		file.Close ();
	}

	public static T LoadData<T>(string fileName) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.OpenRead(Application.persistentDataPath + fileName);
		T data = (T) bf.Deserialize (file);
		file.Close();
		return data;
	}
}
