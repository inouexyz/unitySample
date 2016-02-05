using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Fadeout : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
		//1秒間(time)かけて値を0から１（fromからto）まで変化させる。
		//毎フレーム現在地をUpdateHandlerの引数に渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", 1f, "onupdate", "UpdateHandler"));
	}
	
	//値を受け取る
	void UpdateHandler(float value){
		GetComponent<Image>().color = new Color(0, 0, 0, value);
		if(value == 1)
		{
			//各ゲームでシーン遷移
			Debug.Log("シーン遷移");
			Application.LoadLevel("main");
		}
	}
}
