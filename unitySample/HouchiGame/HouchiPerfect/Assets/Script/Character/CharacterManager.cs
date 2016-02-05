using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class CharacterManager : MonoBehaviour {

	//外部アクセス用
	static CharacterManager main;

	//オリジナルのキャラクター
	[SerializeField] CharaMove OriginalChara;

	//キャラクターリスト
	List<CharaMove> charaList;		
	//キャラのマックス数
	const int CHARA_MAX = 100;


	// Use this for initialization
	void Awake () 
	{
		main = this;

		charaList = new List<CharaMove>();

		//初期キャラクター作成
		for( int i = 0 ; i < CHARA_MAX ; i++)
		{
			CharaMove data = Instantiate( OriginalChara );

			data.transform.parent = transform;
			data.transform.localScale = new Vector3(1,1,1);
			data.transform.localPosition = Vector3.zero;
			data.gameObject.SetActive( false );
			charaList.Add(data);
		}


		DateTime currentDate = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () 
	{

		touchCheck();

	}
	///外部からアクセスできるようにする 
	public static CharacterManager getInstance()
	{
		return main;
	}

	void touchCheck()
	{
		//タッチのチェック
		if( Input.GetMouseButton(0) )
		{
			Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			for( int i = 0 ; i < CHARA_MAX ; i++)
			{
				if( charaList[i].gameObject.activeSelf )
				{
					float distance = Vector2.Distance( point , charaList[i].gameObject.transform.localPosition );
					
					if( distance <= 0.5f )
					{
						charaList[i].DeadStart();
						Sound.main.PlaySound(2);

					}
				}
			}
		}
	}





	//キャラクターが増えます
	public void characterAdd(int num )
	{
		for( int i = 0 ; i < CHARA_MAX ; i++)
		{
			//ONではないキャラクターを探す
			if( charaList[i].gameObject.activeSelf == false )
			{
				num--;
				charaList[i].gameObject.SetActive( true );
				//作成
				charaList[i].Create();

				//作成完了しました
				if( num <= 0 )
				{
					break;
				}
			}
		}
	}

	/// 一人だけ作成　戻り値で作成キャラを得る
	public CharaMove characterAddOne()
	{
		for( int i = 0 ; i < CHARA_MAX ; i++)
		{
			//ONではないキャラクターを探す
			if( charaList[i].gameObject.activeSelf == false )
			{
				charaList[i].gameObject.SetActive( true );
				//作成
				charaList[i].Create();
				
				return charaList[i];
			}
		}
		return null;
	}

	public int getCharaNum()
	{			
		int num = 0;
		for( int i = 0 ; i < CHARA_MAX ; i++)
		{
			if( charaList[i].gameObject.activeSelf )
			{
				num++;
			}
		}
		return num;
	}
}









