using UnityEngine;
using System.Collections;

public class MagiScript : MonoBehaviour 
{
	public GameObject bubble;
	public TextMesh counter;
	public GameObject taptext;
	public GameObject bg;
	SoundScript Sounds;
	int intcounter;
	float xPos;

	// Use this for initialization
	void Start () 
	{
		Sounds = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
		bubble.SetActive(false);
		intcounter=0;
		Time.timeScale = 0;
		Sounds.BGMusic.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		counter.text=""+intcounter;
		xPos = transform.position.x;
		if(transform.position.y>=9.3f){
			bubble.SetActive(true);
			bubble.transform.position=new Vector3(xPos,6.5f,0);
		}
		else{
			bubble.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Finish")
		{
			StartCoroutine(Die ());
		}
	}

	IEnumerator Die()
	{
		Sounds.BGMusic.Stop();
		Sounds.Splash.Play();
		yield return new WaitForSeconds(1);
		Application.LoadLevel(1);
	}

	void OnMouseDown()
	{
		Sounds.Score++;
		taptext.SetActive(false);
		Time.timeScale = 1;
		intcounter++;
		Sounds.Glub.Play ();
		rigidbody2D.velocity = new Vector2(Random.Range(-10,10), Random.Range(20,40));
		rigidbody2D.angularVelocity = Random.Range(-100,100);
	}
}
