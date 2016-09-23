using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private float moveSpeed;
	private float xClamp = 16, yClamp = 8.5f;

	private void Update () {
		Move ();
		ClampMovement ();
		if (Input.GetKeyDown(KeyCode.Space)) {
			SpawnProjectile();
		}
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "enemy") {
			ReloadLevel ();	
		}
	}

	private void Move () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Vector3 movementVector = new Vector3 (h, v, 0).normalized;
		transform.Translate (movementVector * moveSpeed, Space.World);
	}

	private void ClampMovement () {
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (temp.x, -xClamp, xClamp);
		temp.y = Mathf.Clamp (temp.y, -yClamp, yClamp);
		transform.position = temp;
	}

	private void SpawnProjectile () {
		Instantiate (
			projectile,
			transform.position,
			Quaternion.identity
		);
	}

	private void ReloadLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}
}
