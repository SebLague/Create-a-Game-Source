using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public enum FireMode {Auto, Burst, Single};
	public FireMode fireMode;

	public Transform[] projectileSpawn;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	public int burstCount;

	public Transform shell;
	public Transform shellEjection;
	MuzzleFlash muzzleflash;
	float nextShotTime;

	bool triggerReleasedSinceLastShot;
	int shotsRemainingInBurst;

	void Start() {
		muzzleflash = GetComponent<MuzzleFlash> ();
		shotsRemainingInBurst = burstCount;
	}

	void Shoot() {

		if (Time.time > nextShotTime) {
			if (fireMode == FireMode.Burst) {
				if (shotsRemainingInBurst == 0) {
					return;
				}
				shotsRemainingInBurst --;
			}
			else if (fireMode == FireMode.Single) {
				if (!triggerReleasedSinceLastShot) {
					return;
				}
			}

			for (int i =0; i < projectileSpawn.Length; i ++) {
				nextShotTime = Time.time + msBetweenShots / 1000;
				Projectile newProjectile = Instantiate (projectile, projectileSpawn[i].position, projectileSpawn[i].rotation) as Projectile;
				newProjectile.SetSpeed (muzzleVelocity);
			}

			Instantiate(shell,shellEjection.position, shellEjection.rotation);
			muzzleflash.Activate();
		}
	}

	public void OnTriggerHold() {
		Shoot ();
		triggerReleasedSinceLastShot = false;
	}

	public void OnTriggerRelease() {
		triggerReleasedSinceLastShot = true;
		shotsRemainingInBurst = burstCount;
	}
}
