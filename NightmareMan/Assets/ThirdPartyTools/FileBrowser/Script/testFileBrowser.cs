using UnityEngine;
using System.Collections;

public class testFileBrowser : MonoBehaviour {
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
		if(fb.draw() && fb.outputFile != null){
			Debug.Log (fb.outputFile.ToString());
		}
	}

}
