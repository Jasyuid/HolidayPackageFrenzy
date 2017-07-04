using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	public static SoundEffects Instance;

	public AudioClip lifeUp;
	public AudioClip lifeDown;
	public AudioClip select;

	void Awake () {
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}
	
	public void lifeUpSound(){
		MakeSound (lifeUp);
	}

	public void lifeDownSound(){
		MakeSound (lifeDown);
	}

	public void selectSound(){
		MakeSound (select);
	}

	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
