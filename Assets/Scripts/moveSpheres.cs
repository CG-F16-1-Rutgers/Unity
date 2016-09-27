using UnityEngine;
using System.Collections;

public class moveSpheres : MonoBehaviour {
	private float deltaX = 0.05f;
	private float distance = 0.0f;
	public int direction;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame


	void Update () {
		distance += Mathf.Abs( rb.velocity.magnitude * Time.deltaTime);
		rb.AddForce (new Vector3 (direction*25, 0, 0));
		if (distance >= 10) {
			distance = 0;
			direction = -1*direction;
		}

	
	}
}
