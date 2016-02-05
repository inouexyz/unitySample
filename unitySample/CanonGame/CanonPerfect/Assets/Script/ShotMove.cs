using UnityEngine;
using System.Collections;

public class ShotMove : MonoBehaviour {
	///残り秒数　0になったら消滅 
	float lifeTimer = 0;
	//
	///爆発エフェクト 
	[SerializeField] GameObject BomObj;
	
	// Use this for initialization
	void Start () {
		//3秒存在
		lifeTimer = 3;	
	}
	
	// Update is called once per frame
	void Update () {

		lifeTimer -= Time.deltaTime;
		///残り0秒なら消滅処理
		if( lifeTimer <= 0 )
		{
			if( BomObj != null )
			{
				GameObject obj = Instantiate( BomObj );
				obj.transform.position = transform.position;
			}

			//消滅
			Destroy( gameObject );
		}
	}
	

	void OnCollisionEnter2D(Collision2D collision)
	{

		if( collision.gameObject.tag == "Enemy" )
		{

			EnemyMove Enemy = collision.gameObject.GetComponent<EnemyMove>();
			Enemy.HitEnemy();
		}

		lifeTimer -= 2;
		
	}

}
