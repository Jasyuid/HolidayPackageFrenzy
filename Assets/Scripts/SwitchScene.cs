using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	public string LevelName = "Menu";

	void Awake () {
		Application.LoadLevel(LevelName);
	}
}
