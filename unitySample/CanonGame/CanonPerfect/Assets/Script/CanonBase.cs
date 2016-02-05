using UnityEngine;
using System.Collections;

public class CanonBase : MonoBehaviour {

	///砲身 
	[SerializeField] GameObject CanonCylinder;
	///カメラ 
	[SerializeField] Camera cam;
	///弾丸のオリジナル 
	[SerializeField] GameObject BulletOriginal;
	///タッチしたかどうか 
	bool firstTouch = false;
	///発射方向 
	float nowAngle = 0;
	
	void Start () {
		
	}
	
	///発射間隔に使う 
	float timer = 0;
	
	void Update () {
		//ゲームオーバーなら動かない
		if( GameOver.GameOverFlag )
		{
			return;
		}

		//タッチしたとき
		if( Input.GetMouseButton( 0 ))
		{
			//初めてタッチ
			firstTouch = true;
			
			//タッチした場所
			Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
			
			Vector2 Cylinder = CanonCylinder.transform.position;
			
			//ターゲットとの角度を求める
			float rad = Mathf.Atan2( target.y - Cylinder.y ,  target.x - Cylinder.x);
			nowAngle = rad * 180 / Mathf.PI-90;
			//砲身の角度を変えます
			CanonCylinder.transform.eulerAngles = new Vector3(0,0,nowAngle);
			
			
		}
		
		//タッチをしないと発射しない
		if( firstTouch )
		{
			//1秒に一発発射
			timer += Time.deltaTime;
			if( timer >= 1 )
			{
				timer = 0;
				CrateBullet();		
			}
		}
		
	}
	

	///弾丸の作成 
	void CrateBullet()
	{
		//発射音ならす
		Sound.main.PlaySound(0);

		GameObject Bullet = (GameObject)Instantiate( BulletOriginal );
		
		//角度設定
		Vector3 point = CanonCylinder.transform.position;
		float angle = nowAngle +90;
		float rotatedX = Mathf.Cos(angle*Mathf.PI/180) * 2;
		
		float rotatedZ = Mathf.Sin(angle*Mathf.PI/180) * 2 ;
		
		//初期位置は　発射方向に向かってちょっと動かした場所にします=======
		point.x += rotatedX;
		point.y += rotatedZ;
		
		Bullet.transform.position = point ;
		//==========================================================
		
		Vector3 point2 = Bullet.transform.position ;
		
		///発射先 
		Vector3 pointTarget = new Vector3(rotatedX*20,rotatedZ*20,0);
		
		//指定位置とターゲットの位置を設定（ターゲット座標ーコントロール座標）
		Vector3 anglePoint = Vector3.Normalize( pointTarget - point2 );
		//ターゲットを指定位置に飛ばす
		Bullet.transform.GetComponent<Rigidbody2D>().AddForce (anglePoint * ( 1000 ) );
		
	}
	
	
}
