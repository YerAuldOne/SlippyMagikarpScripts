using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {
	SoundScript Sounds;
	public TextMesh Score;
	public TextMesh PScore;
	// Use this for initialization
	void Start () 
	{
		Sounds = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
		Sounds.Win.Play();
		PlayerPrefs.SetInt("Player Score", Sounds.Score);
		if(PlayerPrefs.GetInt("Player Score")>PlayerPrefs.GetInt("High Score"))
		{
			PlayerPrefs.SetInt("High Score", Sounds.Score);
		}
		Score.text = "High Score: "+PlayerPrefs.GetInt("High Score");
		PScore.text = "You Scored "+PlayerPrefs.GetInt("Player Score");
		KongregateAPI.SubmitStatistic("High Score", PlayerPrefs.GetInt("High Score"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
		PlayerPrefs.DeleteKey("Player Score");
		Sounds.Score = 0;
		Sounds.Win.Stop ();
		Application.LoadLevel(0);
	}
}
