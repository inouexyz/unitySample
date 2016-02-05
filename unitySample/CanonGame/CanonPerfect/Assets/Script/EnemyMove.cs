using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	///最初に受け取っておく Rigidbody2D
	Rigidbody2D rigid;
	
	///現在の状態 
	int mode = 0;
	///通常 
	const int NORMAL = 0;
	///落下中 
	const int FALL = 1;
	///エフェクト 
	[SerializeField] GameObject BomObj;
	
	///落下から消滅するまでの時間 
	float fallLifeTime = 0;
	
	/// 移動スピード
	public float speed = 0;
	///体力 
	[SerializeField] int life = 1;
	/// 絵の情報　ダメージを受けたときに　色を変えたりするのに使う
	SpriteRenderer sprite;
	/// 色が変わってる時間
	float redTimer = 0;
	
	// Use this for initialization
	void Start () {

		//必要な情報の取得 
		rigid = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//ゲームオーバーでは動かない
		if( GameOver.GameOverFlag )
		{
			return;
		}

		//動き
		switch( mode )
		{	
			//通常状態
		case NORMAL:
		{
			//右へ移動
			Vector3 point = transform.localPosition;
			point.x -= Time.deltaTime * speed;
			transform.localPosition = point ;
			
			//一定距離までこられたらゲームオーバー
			if( point.x <= -7 )
			{
				GameOver.GameOverFlag = true;
			}
			

			break;
		}
			//落下中
		case FALL:
		{
			//落下時間経過
			fallLifeTime -= Time.deltaTime;
			if(fallLifeTime <= 0  )
			{
				//爆発エフェクトの作成
				GameObject obj = Instantiate( BomObj );
				obj.transform.position = transform.position;				
				//消滅
				Destroy( gameObject );
				
			}
			break;
		}
		}
		//色を変える処理
		if( redTimer > 0 )
		{
			colorMove();
		}
	}
	

	//ダメージを受けたときの色かえ
	void colorMove()
	{
		redTimer-= Time.deltaTime;
		
		sprite.color = new Color(1,1-redTimer , 1-redTimer );
		
		if( redTimer <= 0 )
		{
			redTimer = 0;
		}
	}
	

	///弾丸などがぶつかったとき
	public void HitEnemy()
	{
		//通常時のみ判定
		if( mode == NORMAL )
		{
			//体力が減る
			life--;
			//色が変わる
			sprite.color = new Color(1,0,0);
			redTimer = 1;
			
			//体力がなくなった
			if( life <= 0 )
			{
				//落下中処理へ
				UI_Score.main.scoreAdd();
				//重力が発生
				rigid.isKinematic = false;
				mode = FALL ;
				//4秒後消滅
				fallLifeTime = 4;
			}
		}
	}
	
	//何かしらの物体がぶつかったら呼び出される
	void OnCollisionEnter2D(Collision2D collision)
	{
		//落下中の敵がぶつかった
		if( collision.gameObject.tag == "Enemy" )
		{
			EnemyMove Enemy = collision.gameObject.GetComponent<EnemyMove>();
			//ダメージ処理
			Enemy.HitEnemy();
		}
		
		//地面に激突
		if( collision.gameObject.tag == "ground" )
		{
			if( mode == FALL )
			{
				//落下中時間減少
				fallLifeTime -= 2;
			}
		}
		
	}
	
}
