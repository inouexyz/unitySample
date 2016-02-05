using UnityEngine;
using System.Collections;

///敵キャラの動き 
public class MissileMove : MonoBehaviour {

	//右に移動する場合はtrue
	bool moveRight = false ;
	///爆発のエフェクト
	[SerializeField] GameObject BomEf;
	///アイテムならtrue 
	[SerializeField] bool Item = false;
	
	void Start () {
		//高さを設定
		Vector3 point = transform.localPosition;
		point.y = Random.Range(4.4f,-2.0f);
		
		//右へ行くか左へ行くか設定==================
		Vector3 scale = transform.localScale ;
		if( Random.Range(0,2) == 0 )
		{
			moveRight = true;
		}else
		{
			moveRight = false ;
		}
		
		if(moveRight)
		{
			//右へ行くので左側からスタート
			point.x = -9;
			scale.x *= -1;
		}else
		{
			//左へ行くので右側からスタート
			point.x = 9;
			scale.x *= 1;
		}
		//=====================================
		transform.localPosition = point ;
		transform.localScale = scale ;
	}
	
	void Update () {
	
		//移動===========================
		Vector3 point = transform.localPosition;

		if( moveRight )
		{
			point.x += Time.deltaTime*5;
		}else
		{
			point.x -= Time.deltaTime*5;
		}
		//===============================

		//一定距離まで移動で消滅============
		float max= 14f;
		if( moveRight )
		{
			if( point.x >= max )
			{
				Destroy(gameObject);
			}
		}
		else
		{
			if( point.x <= -max )
			{
				Destroy(gameObject);
			}
		}
		//================================
		transform.localPosition = point ;
	}

	//ぶつかったときよばれます
	void OnTriggerEnter2D (Collider2D col)
	{
		//アイテムの場合
		if( Item )
		{
			PlayerMove pl = col.gameObject.GetComponent<PlayerMove>();
			if( pl != null )
			{
				//点数が加算
				UI_Score.ScorePoint += 10;

				//効果音　アイテムゲット
				Sound.main.PlaySound(1);

			}
		}else
		{
			//エフェクトを発生　爆発
			GameObject Bom = (GameObject)Instantiate( BomEf );
			Bom.transform.localPosition = transform.localPosition;

			//効果音　爆発
			Sound.main.PlaySound(0);

			//プレイヤーとぶつかったらゲームオーバー
			PlayerMove pl = col.gameObject.GetComponent<PlayerMove>();
			if( pl != null )
			{
				pl.hitChara();
			}
		}
		//消滅
		transform.localScale = new Vector3(0,0,0);
		Destroy( gameObject );
	}



}
