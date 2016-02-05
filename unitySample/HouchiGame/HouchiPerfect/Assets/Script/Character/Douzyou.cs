using UnityEngine;
using System.Collections;

public class Douzyou : MonoBehaviour {
	
	int touchNum = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		touchCheck();
	}
	
	void touchCheck()
	{
		//タッチのチェック
		if( Input.GetMouseButtonDown(0) )
		{
			Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float distance = Vector2.Distance( point , transform.localPosition );
			
			if( distance <= 1.0f )
			{
				iTween.ShakeScale( gameObject , iTween.Hash( "y" , 0.3f , "time",0.3f , "islocal" , true ));
				
				touchNum++;
				if( touchNum >= 10 )
				{
					Sound.main.PlaySound(0);
					touchNum= 0;
					//キャラクター作成
					CharaMove chara = CharacterManager.getInstance().characterAddOne();
					
					Vector3 charapoint  = transform.localPosition;
					charapoint.z = -2;
					charapoint.y -= 2;
					chara.transform.localPosition = charapoint ;
					
					iTween.MoveTo( chara.gameObject ,
					              iTween.Hash("x",Random.Range(CharaMove.MIN_X , CharaMove.MAX_X ),
					            "y",Random.Range(CharaMove.MIN_Y , CharaMove.MAX_Y ),
					            "time",0.5f,"islocal",true,
					            "easetype",iTween.EaseType.easeOutBack ));
					
					Sound.main.PlaySound(4);
				}else
				{
					Sound.main.PlaySound(3);
				}
				
				
				
				
				
			}
		}
		
	}
	
	
}
