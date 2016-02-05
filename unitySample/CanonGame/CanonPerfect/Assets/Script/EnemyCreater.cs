using UnityEngine;
using System.Collections;

public class EnemyCreater : MonoBehaviour {
	

	///普通の敵
	[SerializeField] EnemyMove originalEnemy;
	
	///発生間隔に使う 
	float timer = 0;
	
	void Start () {
		
	}
	
	void Update () {
		//ゲームオーバーでは動かない
		if( GameOver.GameOverFlag )
		{
			return;
		}


		timer += Time.deltaTime;
		//1秒経過したら作成
		if( timer >= 1 )
		{

			timer = 0;
			//発生数
			int createEnemyNum = 3 ;
			

			//一定数作成
			for( int i = 0 ; i < createEnemyNum ; i++)
			{
				//敵のオブジェクト
				EnemyMove enemy = null;
				
				//発生高さ
				float Ypoint = 0;
				
				//普通の敵
				enemy = (EnemyMove)Instantiate( originalEnemy );
				//速度
				enemy.speed = Random.Range(0.5f,1.5f);
				//高さ
				Ypoint = Random.Range(-2.0f,5.0f);

				//点数増加でスピードアップ
				enemy.speed = enemy.speed ;
				enemy.transform.localPosition = new Vector3(10, Ypoint ,0);			}
		}
	}
}
