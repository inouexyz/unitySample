using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollObj : MonoBehaviour {

	[SerializeField] Text CharaName;
	[SerializeField] Image CharaPict;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	///スプライトをセット 
	public void SpriteSetting(Sprite tex )
	{
		CharaPict.sprite = tex;
	}

	///手に入れたことがある 
	public void OnWindow(int kind )
	{
		//CharaPict.mainTexture;
		CharaPict.gameObject.SetActive( true );
		CharaName.text = DataBase.SAMURAI_NAMES[kind];
	}

	///まだ手に入れてない 
	public void OffWindow()
	{
		CharaPict.gameObject.SetActive( false );
		CharaName.text = "?????";
	}
}
