using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;
	private float xClamp = 16, yClamp = 8.5f;

	private void Update () {
		Move ();
		ClampMovement ();
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
}
