using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 5;

	private void Start () {
		Destroy (gameObject, 5);
	}

	private void Update () {
		transform.Translate (Vector3.right * moveSpeed);
	}
}
