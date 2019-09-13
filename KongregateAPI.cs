﻿using UnityEngine;
using System.Collections;

public class KongregateAPI : MonoBehaviour {
	
	static KongregateAPI instance;
	static bool created = false;
	void Start() {
		if(created == false){
			DontDestroyOnLoad(gameObject);
			created = true;
		}
		else{
			Destroy(gameObject);
		}
		if(instance == null) {
			
			Application.ExternalEval("if(typeof(kongregateUnitySupport) != 'undefined'){kongregateUnitySupport.initAPI('" + gameObject.name + "', 'OnKongregateAPILoaded');};");
			
			instance = this;
			
		}
	}
	
	
	static bool isKongregate = false;
	static uint userId = 0;
	static string username = "Guest";
	static string gameAuthToken = "";
	
	void OnKongregateAPILoaded(string userInfoString) {
		
		isKongregate = true;
		string[] parameters = new string[3];
		parameters = userInfoString.Split("|"[0]);
		userId = uint.Parse(parameters[0]);
		username = parameters[1];
		gameAuthToken = parameters[2];
		
	}
	
	public static void SubmitStatistic(string stat, int val) {
		
		if(isKongregate) {
			
			Application.ExternalCall("kongregate.stats.submit",stat,val);
			
		}
	}
}