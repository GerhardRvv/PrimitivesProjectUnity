using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float _speed = 1000.0f;
	private float _zBound = 10f;

	private Rigidbody _playerRb;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		_playerRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		MovePlayer();
		ConstraintPlayerMovement();
	}

	void MovePlayer() {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		_playerRb.AddForce(
			Vector3.forward * (verticalInput * _speed * Time.deltaTime),
			ForceMode.Force
		);
		_playerRb.AddForce(
			Vector3.right * (horizontalInput * _speed * Time.deltaTime),
			ForceMode.Force
		);
	}

	void ConstraintPlayerMovement() {
		if (transform.position.z < -_zBound) {
			transform.position = new Vector3(transform.position.x, transform.position.y, -_zBound);
		}
		else if (transform.position.z > _zBound) {
			transform.position = new Vector3(transform.position.x, transform.position.y, _zBound);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			Debug.Log("PLayer has collided with Enemy");
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("PowerUp")) {
			Debug.Log("Player has collided with PowerUp");
			Destroy(other.gameObject);
		}
	}
}