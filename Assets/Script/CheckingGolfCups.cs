using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGolfCups : MonoBehaviour {
	private GameObject golfCups;
	public bool hasEntered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Ball"))
		{
			hasEntered = true;
			golfCups.layer = 10;
		}
	}

	void OnTriggerExit (Collider cell)
	{
		if (cell.gameObject.CompareTag ("Ball"))
		{
			hasEntered = false;
			golfCups.layer = 9;
		}
	}
}
