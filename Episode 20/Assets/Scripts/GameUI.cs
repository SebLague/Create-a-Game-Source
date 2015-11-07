using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {

	public Image fadePlane;
	public GameObject gameOverUI;

	void Start () {
		FindObjectOfType<Player> ().OnDeath += OnGameOver;
	}

	void OnGameOver() {
		StartCoroutine(Fade (Color.clear, Color.black,1));
		gameOverUI.SetActive (true);
	}

	IEnumerator Fade(Color from, Color to, float time) {
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp(from,to,percent);
			yield return null;
		}
	}

	// UI Input
	public void StartNewGame() {
		Application.LoadLevel ("Game");
	}
}
