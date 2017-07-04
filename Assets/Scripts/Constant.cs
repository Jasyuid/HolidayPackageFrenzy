using UnityEngine;
using System.Collections;

public class Constant : MonoBehaviour {

	public int score;
	public int packages;

	void Awake(){
		DontDestroyOnLoad (this);
	}

	void Start () {
	
	}

	void Update () {
	
	}
}
