using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int score;
	public static int lives;
	public static int packages;
	public TextMesh scoreText;
	public TextMesh liveText;
	public TextMesh packageText;

	private int scorec;

	public int level;
	public float speed;

	public GameObject packagespawnerB;
	private bool first2 = true;

	private float packagesince;

	private Constant constant;

	void Start () {
		score = 0;
		lives = 2;
		packages = 0;
		level = 1;
		speed = 15.0f;
		first2 = true;
		packagesince = 20;
		scorec = 0;

		packagespawnerB.SetActive (false);

		GameObject constantObject = GameObject.FindWithTag ("GameManager");
		constant = constantObject.GetComponent <Constant> ();
	}

	void Update () {
		constant.score = score;
		constant.packages = packages;

		scoreText.text = "" + score;
		liveText.text = "Lives: " + lives;
		packageText.text = "Packages: " + packages;

		if (lives <= 0) {
			Application.LoadLevel("GameOverMenu");
		}

		if (level == 1) {
			speed = 10.0f;
		}
		if (packages >= 2 && level == 1) {
			level = 2;
			speed  = 13.0f;
			if(first2){
				packagespawnerB.SetActive(true);
				first2 = false;
			}
		}
		if (packages >= 5 && level == 2) {
			level = 3;
			speed  = 16.0f;
		}
		if (packages >= 10 && level == 3) {
			level = 4;
			speed  = 20.0f;
		}
		if (packages >= 20 && level == 4) {
			level = 5;
			speed = 24.0f;
		}
		if (level == 5) {
			if(packages - packagesince >= 3.0f){
				speed += 0.5f;
				packagesince = packages;
			}
		}

		if (score - scorec >= 500) {
			lives++;
			SoundEffects.Instance.lifeUpSound();
			scorec = score;
		}
	}

	public void AddScore(int s){
		score += s;
	}

	public void RemoveLive(){
		lives--;
	}

	public void AddPackage(){
		packages++;
	}	
}
