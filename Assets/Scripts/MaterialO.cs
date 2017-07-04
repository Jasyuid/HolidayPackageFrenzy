using UnityEngine;
using System.Collections;

public class MaterialO : MonoBehaviour {
	
	private int kill;

	void Start () {
		if (gameObject.name == "Peanut(Clone)") gameObject.name = "Peanut";
		else if (gameObject.name == "Tissue(Clone)") gameObject.name = "Tissue";
		else if (gameObject.name == "Wrap(Clone)") gameObject.name = "Wrap";
		else if (gameObject.name == "Red(Clone)") gameObject.name = "Red";
		else if (gameObject.name == "Green(Clone)") gameObject.name = "Green";
		else if (gameObject.name == "Fragile(Clone)") gameObject.name = "Fragile";

		kill = 0;
		
	}

	void Update () {
		var v3 = Input.mousePosition;
		v3.z = 10.0f;
		v3 = Camera.main.ScreenToWorldPoint(v3);

		Vector3 pos = gameObject.transform.position;
		pos.x = v3.x;
		pos.y = v3.y;
		pos.z = -1;
		gameObject.transform.position = pos;

		if (kill >= 2) OnKill ();
		if (!Input.GetMouseButton (0)) kill += 1;

	}

	void OnKill(){
		Destroy (gameObject);
	}
}
