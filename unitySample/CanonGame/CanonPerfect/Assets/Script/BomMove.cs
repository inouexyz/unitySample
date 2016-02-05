using UnityEngine;
using System.Collections;

public class BomMove : MonoBehaviour {
	//①
	float timer = 0;
	
	void Start () 
	{
		timer = 1;
	}
	
	void Update ()
	{
		//②
		timer -= Time.deltaTime;
		///残り0秒なら消滅処理
		if( timer <= 0 )
		{
			//消滅
			Destroy( gameObject );
		}
	}
}
