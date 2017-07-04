using UnityEngine;
using System.Collections;

public class MaterialButton : MonoBehaviour {

	public GameObject material;
	public Sprite normal;
	public Sprite hover;

	private static bool o;

	void Start () {
		o = false;
	}

	void FixedUpdate () {
		SpriteRenderer s = gameObject.GetComponent<SpriteRenderer>();
		s.sprite = normal;

		var v3 = Input.mousePosition;
		v3.z = 10.0f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		float mx = v3.x;
		float my = v3.y;

		float x = gameObject.transform.position.x;
		float y = gameObject.transform.position.y;
		float width = gameObject.GetComponent<BoxCollider2D> ().bounds.size.x;
		float height = gameObject.GetComponent<BoxCollider2D> ().bounds.size.y;

		if (mx > x - (width / 2) && mx < x + (width / 2)) {
			if(my > y - (height/2) && my < y + (height/2)){
				s.sprite = hover;
				if(Input.GetMouseButton(0) && !o){
					Instantiate(material);
					o = true;
				}else if(!Input.GetMouseButton(0)){
					o = false;
				}
			}
		}
	}
}
