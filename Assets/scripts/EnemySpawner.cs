using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private EnemyController enemy;
	[SerializeField]
	private bool canSpawn = true;
	[SerializeField]
	private float yClamp = 8.5f;
	private float xSpawn = 15;
	private float spawnRate = 0.5f;

	private void Start () {
		StartCoroutine (SpawnEnemy ());
	}

	private IEnumerator SpawnEnemy () {
		while (canSpawn) {
			yield return new WaitForSeconds (spawnRate);
			InstantiateAtPosition ();
		}
	}

	private void InstantiateAtPosition () {
		Instantiate (
			enemy,
			new Vector3(xSpawn, Random.Range(-yClamp, yClamp), 0),
			Quaternion.identity
		);
	}
}
