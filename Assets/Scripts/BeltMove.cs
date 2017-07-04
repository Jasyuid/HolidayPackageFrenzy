using UnityEngine;
using System.Collections;

public class BeltMove : MonoBehaviour {

	private float speed = 10.0f;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();

		speed = gameController.speed;
	}

	void Update () {
		speed = gameController.speed;
		Vector3 pos = gameObject.transform.position;

		pos.x += speed * Time.deltaTime;

		if (pos.x > 300) {
			pos.x = -300;
		}

		gameObject.transform.position = pos;
	}
}
