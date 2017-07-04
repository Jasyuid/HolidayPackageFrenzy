using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Package : MonoBehaviour {

	float speed = 10.0f;
	int num;
	int needNum;
	private bool finished;

	public List<GameObject> needs = new List<GameObject>();
	public List<GameObject> stickers = new List<GameObject>();
	public GameObject peanut, tissue, wrap, red, green, fragile;
	public GameObject peanuts, tissues, wraps, reds, greens, fragiles;

	public Sprite finishedS1, finishedS2;

	private bool o, p;
	private int tim;

	private GameController gameController;

	void Start () {
		finished = false;
		needNum = (int)Random.Range(2, 5);
		num = needNum;

		o = false;
		p = true;
		tim = 5;

		for (int i = 0; i < needNum; i++) {
			switch(Random.Range(0, 6)){
			case 0: needs.Add(peanut);
				GameObject peanutS = Instantiate(peanuts);
				stickers.Add(peanutS);
				break;
			case 1: needs.Add(tissue);
				GameObject tissueS = Instantiate(tissues);
				stickers.Add(tissueS);
				break;
			case 2: needs.Add(wrap);
				GameObject wrapS = Instantiate(wraps);
				stickers.Add(wrapS);
				break;
			case 3: needs.Add(red);
				GameObject redS = Instantiate(reds);
				stickers.Add(redS);
				break;
			case 4: needs.Add(green);
				GameObject greenS = Instantiate(greens);
				stickers.Add(greenS);
				break;
			case 5: needs.Add(fragile);
				GameObject fragileS = Instantiate(fragiles);
				stickers.Add(fragileS);
				break;
			}
		}

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();

		speed = gameController.speed;

	}

	void Update () {
		speed = gameController.speed;
		Vector3 pos = gameObject.transform.position;
		pos.x += speed * Time.deltaTime;
		if (pos.x > 175)
			OnKill ();
		gameObject.transform.position = pos;

		for (int i = 0; i < stickers.Count; i++) {
			Vector3 posS = stickers[i].transform.position;
			posS = new Vector3(pos.x + 10*i - 15, pos.y, pos.z + 1);
			stickers[i].transform.position = posS;
		}

		if (needs.Count <= 0 && !finished) {
			finished = true;
			if(Random.Range(0, 2) == 0){
				gameObject.GetComponent<SpriteRenderer>().sprite = finishedS1;
			}else{
				gameObject.GetComponent<SpriteRenderer>().sprite = finishedS2;
			}
		}

		if (!Input.GetMouseButton (0))
			o = true;
		else
			o = false;

		if (!p) {
			tim--;
		}
		if (tim <= 0) {
			p = true;
			tim = 8;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (o && p) {
			if(needs.Count > 0){

				for(int i = 0; i < needNum; i++){
				if(needs[i].name == other.gameObject.name){
					needs.Remove(needs[i]);
					Destroy(stickers[i]);
					stickers.Remove(stickers[i]);
					gameController.AddScore(2);
					o = false;
					p = false;
					return;
				}
				}

			}
			o = false;
		}
	}

	void OnKill(){
		if (finished) {
			gameController.AddScore (num * 10);
			gameController.AddPackage();
		} else if (!finished) {
			SoundEffects.Instance.lifeDownSound();
			gameController.RemoveLive();
			for(int i = 0; i < stickers.Count; i++){
				Destroy(stickers[i]);
			}

		}
		Destroy (gameObject);
	}
}
