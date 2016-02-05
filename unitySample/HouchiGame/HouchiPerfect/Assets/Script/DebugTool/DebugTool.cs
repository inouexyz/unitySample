using UnityEngine;
using System.Collections;


public class DebugTool : MonoBehaviour {


	void OnGUI()
	{


		float baseY = 0;
		float baseAdd = 0;

		baseAdd += 20;
		if(GUI.Button(new Rect(10 , baseY+ baseAdd , 210,20), "データリセット")) {
			SaveDataBase.InitSaveData();
			SaveDataBase.saveData();
			Application.LoadLevel( "main" );			
		}
		baseAdd += 20;
		if(GUI.Button(new Rect(10 , baseY+ baseAdd , 210,20), "デバックオフ ")) {
			Destroy( gameObject );
		}
	}

}













