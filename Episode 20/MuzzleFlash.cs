using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

	public GameObject flashHolder;
	public Sprite[] flashSprites;
	public SpriteRenderer[] spriteRenderers;

	public float flashTime;

	void Start() {
		Deactivate ();
	}

	public void Activate() {
		flashHolder.SetActive (true);

		int flashSpriteIndex = Random.Range (0, flashSprites.Length);
		for (int i =0; i < spriteRenderers.Length; i ++) {
			spriteRenderers[i].sprite = flashSprites[flashSpriteIndex];
		}

		Invoke ("Deactivate", flashTime);
	}

	void Deactivate() {
		flashHolder.SetActive (false);
	}
}
