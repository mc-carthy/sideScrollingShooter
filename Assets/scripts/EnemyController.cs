using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;

	private void Update () {
		Move ();
	}

	private void Move () {
		transform.Translate (Vector3.left * moveSpeed);
	}
}
