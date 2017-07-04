using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public TextMesh scoreText;
	public TextMesh packageText;
	public TextMesh paraText;

	private Constant constant;

	void Start () {
		GameObject constantObject = GameObject.FindWithTag ("GameManager");
		constant = constantObject.GetComponent <Constant> ();
	}

	void Update () {
		scoreText.text = "Score: " + constant.score;
		packageText.text = "Packages: " + constant.packages;

		if (constant.packages < 30) {
			paraText.text = "Santa is FURIOUS";
		}
		if (constant.packages >= 30) {
			paraText.text = "Santa is not pleased...";
		}
		if (constant.packages >= 40) {
			paraText.text = "Santa yawns at your achievment";
		}
		if (constant.packages >= 50) {
			paraText.text = "Santa is mildly impressed";
		}
		if (constant.packages >= 60) {
			paraText.text = "Santa is happy";
		}
		if (constant.packages >= 70) {
			paraText.text = "Santa is FLOWING WITH JOY";
		}
	}
}
