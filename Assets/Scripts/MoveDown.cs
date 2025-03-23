using UnityEngine;

public class MoveDown : MonoBehaviour {
	
	public float speed = 1000.0f;
	private Rigidbody _objectRb;
	private float _zDestroy = -20.0f;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		_objectRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		MoveEnemy();
		DestroyOutOfBounds();
	}

	void MoveEnemy() {
		_objectRb.AddForce(
			Vector3.back * (speed * Time.deltaTime),
			ForceMode.Impulse);
	}

	void DestroyOutOfBounds() {
		if (transform.position.z < _zDestroy) {
			Destroy(gameObject);
		}
	}
}