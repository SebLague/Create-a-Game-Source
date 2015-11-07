using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public Transform weaponHold;
	public Gun startingGun;
	Gun equippedGun;

	void Start() {
		if (startingGun != null) {
			EquipGun(startingGun);
		}
	}

	public void EquipGun(Gun gunToEquip) {
		if (equippedGun != null) {
			Destroy(equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponHold.position,weaponHold.rotation) as Gun;
		equippedGun.transform.parent = weaponHold;
	}

	public void OnTriggerHold() {
		if (equippedGun != null) {
			equippedGun.OnTriggerHold();
		}
	}

	public void OnTriggerRelease() {
		if (equippedGun != null) {
			equippedGun.OnTriggerRelease();
		}
	}

	public float GunHeight {
		get {
			return weaponHold.position.y;
		}
	}
}