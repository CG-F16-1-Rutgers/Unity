using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {
	private List<GameObject> selectedUnits = new List<GameObject>();
	// Use this for initialization
	void Start () {
		//selectedUnit = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if ( (hit.transform.tag == "Agent" || hit.transform.tag == "Nazgul") && Input.GetMouseButtonDown (0)) {
				if (!selectedUnits.Contains (hit.transform.GetComponent<NavMeshAgent> ().gameObject)) {
					selectedUnits.Add (hit.transform.GetComponent<NavMeshAgent> ().gameObject);
					if (hit.transform.tag != "Nazgul") {
						selectedUnits [selectedUnits.Count - 1].GetComponent<Renderer> ().material.color = Color.red;
					} else {
						selectedUnits [selectedUnits.Count - 1].GetComponent<Renderer> ().material.color = Color.green;
					}
				} else {
					
					if (hit.transform.GetComponent<NavMeshAgent> ().tag != "Nazgul") {
						hit.transform.GetComponent<NavMeshAgent> ().gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
					}
					selectedUnits.Remove (hit.transform.GetComponent<NavMeshAgent> ().gameObject);
				}
			}
			if (hit.transform.tag == "Ground" && Input.GetMouseButtonDown (0)) {
				for (int i = 0; i < selectedUnits.Count; i++) {
					if (selectedUnits [i].GetComponent<NavMeshAgent> ().tag != "Nazgul") {
						selectedUnits [i].GetComponent<Renderer> ().material.color = Color.yellow;
					} else {
						selectedUnits [i].GetComponent<Renderer> ().material.color = Color.black;
					}
				}
				selectedUnits.Clear ();
			}
		}

		RaycastHit hit2;
		if (Input.GetMouseButtonDown(1)) {
			Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray2, out hit2)){
				//agent.SetDestination(hit.point);
				for (int i = 0; i < selectedUnits.Count; i++) {
					selectedUnits [i].GetComponent<NavMeshAgent> ().SetDestination (hit2.point);
				}
			}
		}

	}
}
