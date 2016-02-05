using UnityEngine;
using System.Collections;

///エフェクトの動き 
public class Effect : MonoBehaviour {

	float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	

		timer += Time.deltaTime;
		//0.4秒で削除
		if( timer >= 0.4f)
		{
			Destroy(gameObject);
		}


	}
}
