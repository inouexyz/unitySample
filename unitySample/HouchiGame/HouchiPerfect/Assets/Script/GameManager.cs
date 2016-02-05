using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	//初回はすぐ判定
	float timer = 10;
	//作成可能なキャラ数
	void Start () {
	
		//ゲームのセーブロード
		SaveDataBase.loadData();

		int createChara = 0 ;
		
		//初回か？
		if( SaveDataBase.GetSamurai_All() == 0 )
		{
			//初期化
			SaveDataBase.InitSaveData();
			createChara = (int)SaveDataBase.GetSamuraiNum() ;
			//初回タイマー保存
			SaveDataBase.SetClose_Timer();
		}else
		{
			//アプリ終了前に徘徊している侍
			createChara = SaveDataBase.GetSamuraiNum();
		}


		CharacterManager.getInstance().characterAdd( createChara );
		//ステータス表示の更新
		UIStatus.getInstance().upDataText();
	}
	
	// Update is called once per frame
	void Update () {
	
		//10秒に一回差分を見て侍作成
		timer += Time.deltaTime;

		if( timer >= 10 )
		{
			int createChara = 0 ;

			//現在時間
			DateTime currentDate = DateTime.Now;
			//昔の時間
			long tick = SaveDataBase.GetClose_Timer();
			//差分
			long elapsedTicks = currentDate.Ticks - tick;
			TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
			//何分経過したかわかる
			int minute = (int)elapsedSpan.TotalMinutes ;

			if( minute >= 1 )
			{
				//1分で3人増えますよ
				createChara = minute * 3 ;
				//一回作ったらタイマー保存
				SaveDataBase.SetClose_Timer();
				CharacterManager.getInstance().characterAdd( createChara );
			}
		}

	}








	//アプリ終了
	void OnApplicationQuit () 
	{
		//はいかいしている侍　保存
		SaveDataBase.SetSamuraiNum(CharacterManager.getInstance().getCharaNum());
		SaveDataBase.saveData();
	}
}
















