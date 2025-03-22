using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float _speed = 40.0f;
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

        _playerRb.AddForce(Vector3.forward * (verticalInput * _speed));
        _playerRb.AddForce(Vector3.right * (horizontalInput * _speed));
    }

    void ConstraintPlayerMovement() {
        if (transform.position.z < -_zBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -_zBound);
        }
        else if (transform.position.z > _zBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, _zBound);
        }
    }
}