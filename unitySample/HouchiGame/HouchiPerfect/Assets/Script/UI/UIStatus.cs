using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour {

	static UIStatus main;
	[SerializeField] Text scoreText;
	// Use this for initialization
	void Awake () 
	{
		main = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static UIStatus getInstance()
	{
		return main;
	}

	public void upDataText()
	{
		//合計数
		scoreText.text = SaveDataBase.GetSamurai_All() + "侍";
	}


}




