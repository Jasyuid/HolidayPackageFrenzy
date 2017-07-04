using UnityEngine;
using System.Collections;

public class PackageSpawner : MonoBehaviour {

	public GameObject package;
	private float spawntime = 10;
	private float time = 10;
	public Vector3 posi;

	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}

	void Update () {
		if (time >= spawntime) {
			time = 0;
			Vector3 pos = package.transform.position;
			pos = posi;
			package.transform.position = pos;
			Instantiate (package);
			spawntime = ((10/gameController.speed)*10) + ((Random.value)*((10/gameController.speed)*10));
		} else {
			time += Time.deltaTime;
		}

	}
}
