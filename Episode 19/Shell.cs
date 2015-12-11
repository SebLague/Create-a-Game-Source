using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	public Rigidbody myRigidbody;
	public float forceMin;
	public float forceMax;

	float lifetime = 4;
	float fadetime = 2;

	void Start () {
		float force = Random.Range (forceMin, forceMax);
		myRigidbody.AddForce (transform.right * force);
		myRigidbody.AddTorque (Random.insideUnitSphere * force);

		StartCoroutine (Fade ());
	}
	
	IEnumerator Fade() {
		yield return new WaitForSeconds(lifetime);

		float percent = 0;
		float fadeSpeed = 1 / fadetime;
		Material mat = GetComponent<Renderer> ().material;
		Color initialColour = mat.color;

		while (percent < 1) {
			percent += Time.deltaTime * fadeSpeed;
			mat.color = Color.Lerp(initialColour, Color.clear, percent);
			yield return null;
		}

		Destroy (gameObject);
	}
}
