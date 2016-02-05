using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {
	[SerializeField] Image Black;

	void Start () 
	{
		Black.gameObject.SetActive( false );
	}

	///ボタンを押したとき 
	public void GameStartButton()
	{
		if( Black.gameObject.activeSelf == false )
		{
			//1秒間(time)かけて値を0から１（fromからto）まで変化させる。
			//毎フレーム現在地をUpdateHandlerの引数に渡す
			Black.gameObject.SetActive( true );
			iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", 1f, "onupdate", "UpdateHandler"));
		}
	}

	//値を受け取る
	void UpdateHandler(float value)
	{
		Black.color = new Color(0, 0, 0, value);
		if(value >= 1)
		{
			//各ゲームでシーン遷移
			//Debug.Log("シーン遷移");
			Application.LoadLevel("main");
		}
	}
}

