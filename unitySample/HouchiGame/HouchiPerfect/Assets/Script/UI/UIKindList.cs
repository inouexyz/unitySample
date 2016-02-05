using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIKindList : MonoBehaviour {

	[SerializeField] Image CollectionListBase;

	[SerializeField] GameObject ScrollBase;
	[SerializeField] ScrollObj ScrollObjOriginal;
	ScrollObj[]scrollObjList;

	///Chara1_1～Chara12_1 までを入れます 
	[SerializeField] Sprite[] spriteList;


	const int clostPoint = -600;
	// Use this for initialization
	void Start () {
		Vector3 point = CollectionListBase.transform.localPosition;
		point.y = clostPoint ;
		CollectionListBase.transform.localPosition = point;

		scrollObjList = new ScrollObj[DataBase.MAX_KIND ];

		ListCreate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenWindow()
	{
		iTween.MoveTo( CollectionListBase.gameObject , iTween.Hash("y", 400 ,"time",0.5f,"islocal",true,
		                                                           "easetype",iTween.EaseType.easeOutBack));
		ListUpdate();

		Sound.main.PlaySound(0);

	}

	public void CloseWindow()
	{
		iTween.MoveTo( CollectionListBase.gameObject , iTween.Hash("y", clostPoint ,"time",0.5f,"islocal",true,
		                                                           "easetype",iTween.EaseType.easeOutBack));

		Sound.main.PlaySound(1);

	}


	//初回リスト作成
	void ListCreate()
	{

		for( int i = 0; i < DataBase.MAX_KIND  ; i++)
		{
			scrollObjList[i] = (ScrollObj)Instantiate(ScrollObjOriginal);
			scrollObjList[i].transform.parent = ScrollBase.transform;
			scrollObjList[i].transform.localScale = new Vector3(1,1,1);
			//テクスチャーを設定
			scrollObjList[i].SpriteSetting(spriteList[i]);

		}
		ListUpdate();
	}

	void ListUpdate()
	{
		int kind = SaveDataBase.GetSamurai_Kind();
		for( int i = 0; i < DataBase.MAX_KIND  ; i++)
		{
			int val = kind & (int)System.Math.Pow ( 2 , i );
			if( val >= 1 )
			{
				scrollObjList[i].OnWindow(i);
			}else
			{
				scrollObjList[i].OffWindow();
			}
		}
	}


}













