using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	[SerializeField] AudioClip[] audios;
	AudioSource audiosource;
	public static Sound main ;

	void Start () {
		main = this;
		audiosource = GetComponent<AudioSource>();
	}

	public void PlaySound(int no)
	{
		audiosource.clip = audios[no];
		audiosource.Play();
	}
}
