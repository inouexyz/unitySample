using UnityEngine;
using System.Collections;
//UIを操作する場合はこれを追加
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

	///スコア表示のText 
	[SerializeField] Text ScoreText;
	/// 連続ヒット表示
	[SerializeField] Text ChainText;
	
	/// 外部アクセスできるように設定
	public static UI_Score main;
	
	/// 点数
	int Score = 0;
	///連続ヒット数 
	static int Chain = 0;
	
	///連続ヒット持続時間 
	float ChainTimer = 0;
	
	void Start () {
		
		//初期化
		main = this;
		
		Score = 0;
		Chain = 0;
		ChainText.gameObject.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {

		if( ChainTimer > 0 )
		{
			//連続ヒット数時間が減る
			ChainTimer-= Time.deltaTime;
			if( ChainTimer <= 0 )
			{
				//連続ヒット初期化
				Chain = 0;
				ChainTimer = 0;
				ChainText.gameObject.SetActive( false );
				
			}
		}
	}
	

	///スコア加算 
	public void scoreAdd()
	{
		//連続ヒット加算
		Chain++;
		//連続ヒット数分点数加算
		Score += Chain;
		//
		ChainTimer = 1.0f;
		
		ScoreText.text = "Score:"+Score.ToString() ;
		ChainText.text = "ChainVal:"+Chain.ToString() ;
		ChainText.gameObject.SetActive( true );
		
	}
	
	///現在の点数を取得 
	public int getScore()
	{
		return Score;
	}
	
}
