using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LoadSaveDataList {
	// saving data in list

	public static void AddData<T>(T data, string fileName) {
		List<T> dataList = LoadData<T> (fileName);
		dataList.Add(data);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + fileName);
		bf.Serialize (file, dataList);
		file.Close ();
	}

	public static List<T> LoadData<T>(string fileName) {
		BinaryFormatter bf = new BinaryFormatter ();
		string filePath = Application.persistentDataPath + fileName;
		FileStream file = File.Exists (filePath) ? File.OpenRead (filePath) : File.Create (filePath);
		List<T> dataList = (List<T>) bf.Deserialize (file);
		file.Close();
		return dataList;
	}
}
