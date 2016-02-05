using UnityEngine;
using System.Collections;

///ミサイルの生成を行います 
public class CreateMissile : MonoBehaviour {

	///敵キャラ　アイテムの登録 
	[SerializeField] GameObject[] missiles;
	//作成までの時間
	float timer = 0;
	//作成までの時間マックス
	float maxTimer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//ゲームオーバー中は動かない
		if( GameOver.GameOverFlag )
		{
			return;
		}

		timer += Time.deltaTime;

		///一定時間で作成
		if( timer >= maxTimer)
		{
			//点数加算
			UI_Score.ScorePoint++;

			//だんだんゲームを早く
			Time.timeScale = 1 + (float)UI_Score.ScorePoint / 250 ;

			//次作成までの時間はランダム
			maxTimer = Random.Range(0.8f,1.5f);
			timer = 0;

			//キャラ作成
		 	GameObject.Instantiate( missiles[ Random.Range(0,missiles.Length) ] );

		}
	}
}
