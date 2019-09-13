using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioSource Glub;
	public AudioSource BGMusic;
	public AudioSource Splash;
	public AudioSource Win;
	AudioSource[] aSources;
	static bool created = false;
	public int Score;
	// Use this for initialization
	void Start () {
		if(created == false){
			DontDestroyOnLoad(gameObject);
			created = true;
		}
		else{
			Destroy(gameObject);
		}
		aSources = GetComponents<AudioSource>();
		Glub = aSources[0];
		BGMusic = aSources[1];
		Splash = aSources[2];
		Win = aSources[3];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
