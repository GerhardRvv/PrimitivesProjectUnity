using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject powerUp;
	public GameObject[] enemies;

	private float _zEnemySpawnLocationRange = 15.0f;
	private float _xSpawnLocationRange = 15.0f;
	private float _zPowerUpSpawnLocationRange = 5.0f;

	private float _ySpawnLocation = 0.75f;

	private float powerUpSpawnTime = 5.0f;
	private float enemySpawnTime = 1.0f;
	private float startDelay = 1.0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
		InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);

	}

	// Update is called once per frame
	void Update() {
	}

	void SpawnRandomEnemy() {
		int randomIndex = Random.Range(0, enemies.Length);

		Vector3 spawnPosition = new Vector3(
			GetRandomPositionX(),
			_ySpawnLocation,
			_zEnemySpawnLocationRange
		);

		Instantiate(
			enemies[randomIndex],
			spawnPosition,
			enemies[randomIndex].gameObject.transform.rotation
		);
	}

	void SpawnPowerUp() {
		Vector3 spawnPosition = new Vector3(
			GetRandomPositionX(),
			_ySpawnLocation,
			GetRandomPositionZ()
		);
		
		Instantiate(powerUp, spawnPosition, powerUp.gameObject.transform.rotation);
	}

	float GetRandomPositionX() {
		return Random.Range(
			-_xSpawnLocationRange,
			_xSpawnLocationRange
		);
	}

	float GetRandomPositionZ() {
		return Random.Range(
			-_zPowerUpSpawnLocationRange,
			_zPowerUpSpawnLocationRange
		);
	}
}