using UnityEngine;
using System.Collections;

public class simpleMove : MonoBehaviour {
	private Rigidbody rb;
	private bool selected;

	// Use this for initialization
	void Start () {
		selected = false;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "Movable" && Input.GetMouseButtonDown (0)) {
				rb = hit.transform.GetComponent<Rigidbody> ();
			}
		}

		if (Input.GetKey ("u")) {
			rb.transform.position = rb.transform.position + new Vector3 (-0.5f,0,0);
		}
		if (Input.GetKey ("j")) {
			rb.transform.position = rb.transform.position + new Vector3 (0.5f,0,0);
		}
		if (Input.GetKey ("k")) {
			rb.transform.position = rb.transform.position + new Vector3 (0,0,0.5f);
		}
		if (Input.GetKey ("h")) {
			rb.transform.position = rb.transform.position + new Vector3 (0,0,-0.5f);
		}
	}
}
