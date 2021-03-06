﻿using UnityEngine;
using System.Collections.Generic;

public class avoidNazgul : MonoBehaviour {
	private float threshold =5;
	private NavMeshAgent agent;
	private float distance;
	private Vector3 originalDestination;
	private bool hadDestination;
	private bool scared;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		scared = false;
		hadDestination = false;
	}

	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 0.5f) {
			//print ("ASDF!@@@@@@@@@@@@@@@!!!!!!!!");
			agent.ResetPath ();
			scared = false;
			if (hadDestination) {
				agent.destination = originalDestination;
				hadDestination = false;
			}
		}
			
		foreach (GameObject nazgul in GameObject.FindGameObjectsWithTag("Nazgul"))
		{
			distance = Vector3.Distance (agent.transform.position, nazgul.transform.position);
			if (distance < threshold && !scared) {
				int randx = Random.Range (1, 10) - 5;
				int randy = Random.Range (1, 10) - 5;
				int randz = Random.Range (1, 10) - 5;
				float x = randx   + nazgul.transform.position.x + Random.Range(-1,1)* threshold;
				float y = randy  + nazgul.transform.position.y+ Random.Range(-1,1)*threshold;
				float z = randz   + nazgul.transform.position.z+ Random.Range(-1,1)*threshold;
				originalDestination = agent.destination;
				hadDestination = true;
				agent.SetDestination (new Vector3 (x, y, z));
				scared = true;
			}

		}
	
	}


}

