using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public GameObject mainMenuCanvas;
	public GUISkin skins;
	public Texture2D file,folder,back,drive;
	
	FileBrowser fb = new FileBrowser();
	
	void Start () {
		fb.guiSkin = skins;
		fb.fileTexture = file; 
		fb.directoryTexture = folder;
		fb.backTexture = back;
		fb.driveTexture = drive;
		fb.showSearch = true;
		fb.searchRecursively = true;
	}
	
	void OnGUI(){
		if (fb.draw ()) {
			if(fb.outputFile != null) {
				LevelConstructorManager.Instance.fileLevelPath = fb.outputFile.ToString();
			}
			DisableFileBrowser();
		}
	}
	
	public void EnableFileBrowser() {
		gameObject.SetActive (true);
	}

	public void DisableFileBrowser() {
		gameObject.SetActive (false);
	}
	
}
