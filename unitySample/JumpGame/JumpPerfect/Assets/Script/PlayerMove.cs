using UnityEngine;
using System.Collections;

///ぴーちゃんのアニメーション　ジャンプの動きをします
public class PlayerMove : MonoBehaviour {

	///アニメーション 
	[SerializeField] Animator animeData;


	//地面の位置
	float minPoint = -2;

	//現在の行動
	int nowStatus = 0;

	//通常状態
	const int Normal = 0;
	//ジャンプ中
	const int Jump   = 1;
	//落下中
	const int Fall   = 2;
	//死亡中
	const int Dead   = 3;

	//ジャンプしている時間
	float JumpTimer = 0;
	//落下加算
	float fallTimer = 0;


	//

	// 最初に呼ばれる
	void Start () {
	
		nowStatus = Normal;

	}
	
	// 常に呼ばれる
	void Update () {
	
		//状態に応じて変化
		switch( nowStatus )
		{
			//ノーマルモード
			case Normal:
			{
				//絵を変えてる
				normalMode();
				break;
			}
			//じゃんぷモード
			case Jump:
			{
				
				JumpMode();
				break;
			}
			//落下モード
			case Fall:
			{
				fallMode();
				break;
			}
			//死亡モード
			case Dead:
			{
				//絵を変えてる
				DeadMode();
				break;
			}

		}
	}

	//ノーマルモード
	void normalMode()
	{
		if( Input.GetMouseButton(0))
		{
			//ボタン押したらジャンプモードへ
			nowStatus = Jump;
			JumpTimer = 0;

		}
	}

	//ジャンプモード
	void JumpMode()
	{
		//絵を変えてる
		animeData.SetBool("Jump",true);
		animeData.SetBool("Ground",false);
		//うえへいく
		//最大速度
		const int TopSpeed = 30;
		//スピードを減らす
		const int DownSpeed = 60;

		Vector3 point = transform.localPosition;
		//だんだん速度減少させる移動
		//最大速度-(ジャンプ経過時間×(原則スピード))　の値だけ上昇
		point.y += Time.deltaTime*(TopSpeed  - JumpTimer * (DownSpeed ));

		JumpTimer+= Time.deltaTime;

		if( Input.GetMouseButton(0) == false ||
		   JumpTimer >= 0.5f )
		{
			nowStatus = Fall;


		}

		transform.localPosition = point ;
	}


	//落下モードの処理
	void fallMode()
	{
		//位置が下がります
		Vector3 point = transform.localPosition;

		//固定の落下速度
		const int FirstDownSpeed = 2;
		//fallTimerの落下加算速度
		const int DownSpeed = 20;

		// 時間×（固定の落下速度 + 落下速度上昇分）
		point.y -= Time.deltaTime*(FirstDownSpeed +fallTimer*DownSpeed );

		//タッチ中は羽をパタパタさせて落下速度上昇を抑える
		if( Input.GetMouseButton (0) )
		{
			//絵を変えてる
			animeData.SetBool("Wing",true);

		}else
		{
			//絵を変えてる
			animeData.SetBool("Wing",false);
			animeData.SetBool("Jump",false);	
			//落下加算
			fallTimer += Time.deltaTime;
		}

		//着地
		if( point.y <= minPoint )
		{
			fallTimer = 0;
			point.y = minPoint;
			//おちたらノーマルモードへ
			nowStatus = Normal;
			//絵を変えてる
			animeData.SetBool("Wing",false);
			animeData.SetBool("Ground",true);
		}
		transform.localPosition = point ;
	}

	//しぼうモード
	void DeadMode()
	{
		//絵を変えてる
		animeData.SetBool("Dead",true);
		//位置が下がります
		Vector3 point = transform.localPosition;
		point.y -= Time.deltaTime*3;		
		//着地するまで
		if( point.y <= minPoint )
		{
			point.y = minPoint;
		}
		transform.localPosition = point ;
	}

	//死にました
	public void hitChara()
	{
		//
		nowStatus = Dead ;
		//1秒後ゲームオーバー
		Invoke( "DeadEnd" , 1.0f );
	}

	///ゲームオーバー 
	void DeadEnd()
	{
		GameOver.GameOverFlag = true;
		Sound.main.PlaySound(2);
	}


}