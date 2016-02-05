using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///点数表示の制御 
public class UI_Score : MonoBehaviour {

	//点数
	public static int ScorePoint = 0;
	///点数ＵＩ 
	[SerializeField] Text ScoreText;

	void Start () {
		//初期化
		ScorePoint = 0;
		Time.timeScale = 1.0f;
	}
	
	void Update () {
		//点数の更新
		ScoreText.text = "ScorePoint:"+ ScorePoint;

		//timeScaleを点数が上がるごとに増やす
		//ことで難易度を上げていく
		Time.timeScale = 1.0f + (float)ScorePoint / 100 ;
	}
}
