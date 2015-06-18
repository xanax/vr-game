using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionStay(Collision other){

		//Debug.Log ("Conveyor: "+other.gameObject.tag);

		other.rigidbody.velocity = new Vector3 (1f, 0, 0);
		//other.transform.position += new Vector3 (0.1f, 0, 0);
	}
}
