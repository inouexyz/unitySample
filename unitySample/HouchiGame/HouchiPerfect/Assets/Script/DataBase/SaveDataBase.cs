using UnityEngine;
using System.Collections;
using System;

///セーブデータ関連 
public class SaveDataBase  {

	//セーブデータの情報など=======
	//現在の侍数
	const string NOW_SAMURAI  = "NOW_SAMURAI";
	static int nowSamuraiNum = 0;


	//アプリを閉じた時間
	const string CLOSE_TIME   = "CLOSE_TIME";
	static long Close_Timer = 0;

	//合計侍数
	const string SAMURAI_ALL  = "SAMURAI_ALL";
	static long Samurai_All = 0;

	//手に入れた侍種類　二進数
	const string SAMURAI_KIND = "SAMURAI_KIND";
	static int Samurai_Kind = 0;


	public static void saveData()
	{
		//現在の侍数
		PlayerPrefs.SetInt(NOW_SAMURAI , nowSamuraiNum );
		Debug.Log("saveData nowSamuraiNum"+nowSamuraiNum);
		nowSamuraiNum = PlayerPrefs.GetInt(NOW_SAMURAI);
		Debug.Log("saveData nowSamuraiNum"+nowSamuraiNum);

		//アプリを閉じた時間
		PlayerPrefs.SetString(CLOSE_TIME , Close_Timer.ToString() );
		Debug.Log("saveData Close_Timer"+Close_Timer);
		//合計侍数
		PlayerPrefs.SetString(SAMURAI_ALL , Samurai_All.ToString() );
		Debug.Log("saveData Samurai_All"+Samurai_All);
		//手に入れた侍種類　二進数
		PlayerPrefs.SetInt(SAMURAI_KIND , Samurai_Kind );

	}

	public static void loadData()
	{
		//現在の侍数
		if( PlayerPrefs.HasKey(NOW_SAMURAI))
		{
			nowSamuraiNum = PlayerPrefs.GetInt(NOW_SAMURAI);
			Debug.Log("loadData nowSamuraiNum"+nowSamuraiNum);
		}
		if( PlayerPrefs.HasKey(CLOSE_TIME))
		{
			//アプリを閉じた時間
			Close_Timer = long.Parse( PlayerPrefs.GetString(CLOSE_TIME ));
		}
		if( PlayerPrefs.HasKey(SAMURAI_ALL))
		{
			//合計侍数
			Samurai_All = long.Parse( PlayerPrefs.GetString(SAMURAI_ALL));
		}
		if( PlayerPrefs.HasKey(SAMURAI_KIND))
		{
			//手に入れた侍種類　二進数
			Samurai_Kind= PlayerPrefs.GetInt(SAMURAI_KIND );
		}
	}

	public static void InitSaveData()
	{
		//現在の侍数
		nowSamuraiNum = 30;
		
		//アプリを閉じた時間
		Close_Timer = 0;
		//合計侍数
		Samurai_All = 0;
		//手に入れた侍種類　二進数
		Samurai_Kind= 0;
	}

	///現在はいかいしている侍の数
	public static int GetSamuraiNum()
	{
		return nowSamuraiNum;
	}
	public static void SetSamuraiNum(int num )
	{
		nowSamuraiNum = num;
	}

	///最後に閉じた時間
	public static long GetClose_Timer()
	{
		return Close_Timer;
	}
	public static void SetClose_Timer()
	{
		//現在時間を保存
		DateTime dtNow = DateTime.Now;
		Close_Timer = dtNow.Ticks ;
	}

	///ゲットした侍の数
	public static long GetSamurai_All()
	{
		return Samurai_All;
	}
	public static void AddSamurai_All(int num )
	{
		Samurai_All += num;
		//ステータス表示の更新
		UIStatus.getInstance().upDataText();
	}

	///ゲットした侍の数
	public static int GetSamurai_Kind()
	{
		return Samurai_Kind;
	}
	//二進数的な追加
	public static void AddSamurai_Kind(int num )
	{
		int pow = (int)System.Math.Pow ( 2 ,num );
		Samurai_Kind |= pow ;
	}
}








