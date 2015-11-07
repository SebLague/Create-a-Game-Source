using UnityEngine;
using System.Collections;

public class Crosshairs : MonoBehaviour {

	public LayerMask targetMask;
	public SpriteRenderer dot;
	public Color dotHighlightColour;
	Color originalDotColour;

	void Start() {
		Cursor.visible = false;
		originalDotColour = dot.color;
	}
	
	void Update () {
		transform.Rotate (Vector3.forward * -40 * Time.deltaTime);
	}

	public void DetectTargets(Ray ray) {
		if (Physics.Raycast (ray, 100, targetMask)) {
			dot.color = dotHighlightColour;
		} else {
			dot.color = originalDotColour;
		}
	}
}
