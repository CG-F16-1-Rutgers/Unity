using UnityEngine;
using System.Collections;

public class moveBlock1 : MonoBehaviour {
	private float deltaX = 0.05f;
	private float distance = 0.0f;
	public int direction;
	public float maxDistance;
	public float force;
	public int xAxis;
	public int zAxis;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame


	void Update () {
		distance += Mathf.Abs( rb.velocity.magnitude * Time.deltaTime);
		rb.AddForce (new Vector3 (direction*force*xAxis, 0, direction*force*zAxis));
		if (distance >= maxDistance) {
			distance = 0;
			direction = -1*direction;
		}


	}
}
