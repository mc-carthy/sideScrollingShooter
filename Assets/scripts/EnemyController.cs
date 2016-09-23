using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private ParticleSystem particles;
	[SerializeField]
	private float moveSpeed;

	private void Update () {
		Move ();
	}

	private void Move () {
		transform.Translate (Vector3.left * moveSpeed);
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "projectile") {
			InstantiateParticles ();
			ScoreController.instance.IncrementScore ();

			Destroy (trig.gameObject);
			Destroy (gameObject);
		}
	}

	private void InstantiateParticles () {
		Instantiate (
			particles,
			transform.position,
			Quaternion.identity
		);
	}
}
