using UnityEngine;
using System.Collections;

///ゲームオーバーの挙動 
public class GameOver : MonoBehaviour {
	//これが恩になるとゲームオーバー
	public static bool GameOverFlag = false; 

	//ゲームオーバーの表示に使う=========================
	[SerializeField] GameObject text ;
	[SerializeField] GameObject RetryButton;
	[SerializeField] GameObject TitleButton;
	//================================================
	// Use this for initialization
	void Start()
	{
		GameOverFlag = false;
	}

	void Update()
	{
		if( GameOverFlag )
		{
			//全て表示
			text.gameObject.SetActive(true);
			RetryButton.gameObject.SetActive(true);
			TitleButton.gameObject.SetActive(true);
			Time.timeScale = 1.0f;

		}else
		{
			//全て非表示
			text.gameObject.SetActive(false);
			RetryButton.gameObject.SetActive(false);
			TitleButton.gameObject.SetActive(false);
		}
	}

	///リトライ 
	public void pushRetry()
	{
		GameOverFlag = false;
		Application.LoadLevel("main");
	}
	///タイトルへ 
	public void pushTitle()
	{
		GameOverFlag = false;
		Application.LoadLevel("title");
	}
}
