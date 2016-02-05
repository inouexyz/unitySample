using UnityEngine;
using System.Collections;

public class DataBase  {

	///侍の最大種類 
	public const int MAX_KIND = 5;

	///侍の名前
	public static string[] SAMURAI_NAMES = 
	{"Unity侍","普通侍","三度笠侍","バカ殿","達人侍"};

	///各侍の出現率　多いほど出現しやすい 
	public static int[] kindPar = { 1000, 500, 400 , 300 , 200  };
	///各侍の点数 
	public static int[] Scores  = { 1   ,  3 ,5 ,10 ,20 };


}
