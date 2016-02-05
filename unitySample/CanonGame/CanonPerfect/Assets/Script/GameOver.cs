using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	

	///外部から設定できるフラグ 
	public static bool GameOverFlag = false; 
	///文字 
	[SerializeField] GameObject text ;
	[SerializeField] GameObject RetryButton;
	[SerializeField] GameObject TitleButton;

	// Use this for initialization
	void Start()
	{
		//最初はオフ
		GameOverFlag = false;
	}
	
	void Update()
	{

		if( GameOverFlag )
		{
			//全部表示
			text.gameObject.SetActive(true);
			RetryButton.gameObject.SetActive(true);
			TitleButton.gameObject.SetActive(true);

		}else
		{
			//非表示
			text.gameObject.SetActive(false);
			RetryButton.gameObject.SetActive(false);
			TitleButton.gameObject.SetActive(false);
		}
	}
	

	public void pushRetry()
	{
		GameOverFlag = false;
		Application.LoadLevel("main");
	}
	public void pushTitle()
	{
		GameOverFlag = false;
		Application.LoadLevel("title");
	}

}
