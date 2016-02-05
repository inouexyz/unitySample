using UnityEngine;
using System.Collections;



//キャラの動き
public class CharaMove : MonoBehaviour {


	[SerializeField] Animator spriteChara;

	//作成座標===================
	public const float MIN_Y = -1.05f;
	public const float MAX_Y = 2.05f;

	public const float MIN_X = -2.55f;
	public const float MAX_X = 2.55f;
	//==========================
	bool isDead = false;
	//種類
	int kind = 0;

	///作成開始 
	public void Create()
	{
		//ランダムな種類に設定
		kindRandomSetting();

		isDead = false;

		//ランダムな場所
		transform.localPosition = 
			new Vector3(Random.Range(MIN_X , MAX_X ) ,  
			            Random.Range(MIN_Y , MAX_Y ) ,
			            -3 );



		spriteChara.transform.eulerAngles = new Vector3(0,0,0);
	}

	///死亡処理開始 
	public void DeadStart()
	{
		if( isDead == false )
		{
			iTween.MoveAdd( gameObject , 
			     iTween.Hash( "y" , -10 , "time" , 1.4f ,
			            "easetype",iTween.EaseType.linear ,"islocal", true));
			//回転も入れる
			iTween.RotateTo( spriteChara.gameObject, iTween.Hash("z", 360*4, "time", 1.4f,
	                                "easetype",iTween.EaseType.linear ));
			Invoke("DeadEnd", 1.5f);
			isDead = true;
		}
	}

	void DeadEnd()
	{
		//アニメーションを戻します
		spriteChara.SetBool("Return",true);
		for( int i = 0; i < DataBase.MAX_KIND  ; i++)
		{
			spriteChara.SetBool("Chara"+kind,false);
		}


		//点数が入ります
		SaveDataBase.AddSamurai_All(DataBase.Scores[kind-1]);


		SaveDataBase.AddSamurai_Kind(kind);

		gameObject.SetActive( false );
		iTween.Stop( gameObject );
	}



	//作成する種類を選択
	void kindRandomSetting()
	{

		//すべての確立の合計を算出
		int maxPar = 0;
		for( int i = 0; i < DataBase.MAX_KIND  ; i++)
		{
			maxPar += DataBase.kindPar[i];
		}
		//合計値を基に乱数作成
		int random = Random.Range(0,maxPar);
		//どのｷｬﾗの乱数にヒットしたか調査
		int nowPar = 0;
		//最終的に決定したｷｬﾗのインデックス
		int randomIndex = 0;


		//条件に合うインデックスを検索
		for( int i = 0; i < DataBase.MAX_KIND  ; i++)
		{
			if( random < DataBase.kindPar[i] + nowPar )
			{
				//ヒット
				randomIndex = i;
				break;
			}else
			{
				//条件外なら次の条件を探す
				nowPar += DataBase.kindPar[i];
			}
		}


		//種類決定！！
		kind = randomIndex + 1;
		//アニメーションを設定！
		spriteChara.SetBool("Return",false);
		spriteChara.SetBool("Chara"+kind,true);


	}
}

























