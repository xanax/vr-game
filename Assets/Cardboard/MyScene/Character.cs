using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float speed = 600000.0F;
	public float jumpSpeed = 8.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		Rigidbody body = GetComponent<Rigidbody>();
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		if (Input.GetButton("Jump"))
			moveDirection.y = jumpSpeed;
			
		body.velocity += (moveDirection * Time.deltaTime);
		//transform.position+= (moveDirection * Time.deltaTime) * 2;
	}

	void OnCollisionEnter(Collision other){
		//Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Earth2"){
			Destroy(other.gameObject);
		}
	}
}