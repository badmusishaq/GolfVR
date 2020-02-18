using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {
	private SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	//public float throwForce = 1.25f;

	private LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation;
	public GameObject player;
	public LayerMask laserMask;
	public float yNudgeAmount = 0.3f;
	public GameObject parCanvas;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		laser = GetComponentInChildren<LineRenderer> ();
		//player.transform.position = new Vector3 (transform.position.x, 1.2f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//int layerMask = 1 << 8;
		device = SteamVR_Controller.Input ((int)trackedObj.index);

		if (device.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) 
		{
			laser.gameObject.SetActive (true);
			teleportAimerObject.SetActive (true);


			laser.SetPosition (0, gameObject.transform.position);
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 15, laserMask)) {
				
				teleportLocation = hit.point;
				laser.SetPosition (1, teleportLocation);

				teleportAimerObject.transform.position = new Vector3 (teleportLocation.x, teleportLocation.y + yNudgeAmount, teleportLocation.z);
			}

//			else
//			{
//			//	teleportLocation for tempLocation
//				Vector3 tempLocation = new Vector3 (transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
//				RaycastHit groundRay;
//				if (Physics.Raycast (tempLocation, -Vector3.up, out groundRay, 17, laserMask)) {
//					
//					tempLocation = new Vector3 (transform.forward.x * 5 + transform.position.x, groundRay.point.y, transform.forward.z * 5 + transform.position.z);
//					}
//
//					laser.SetPosition (1, transform.forward * 5 + transform.position);
//
//				teleportAimerObject.transform.position = tempLocation + new Vector3 (0, yNudgeAmount, 0);
//				}
			}

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad))
		{
			laser.gameObject.SetActive (false);
			teleportAimerObject.SetActive (false);
			player.transform.position = teleportAimerObject.transform.position;
				//teleportLocation;
		}

		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad))
		{
			parCanvas.SetActive (true);
		}
		else if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad))
		{
			parCanvas.SetActive (false);
		}


	}

	void OnTriggerStay(Collider col)
	{
		Rigidbody rigid = col.gameObject.GetComponent<Rigidbody> ();
		if (col.gameObject.CompareTag("Ball"))
		{
//			if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
//			{
//				rigid.velocity = Vector3.zero;
//				rigid.angularVelocity = Vector3.zero;
//				DropObject(col);
//			}
//			else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
//			{
//				GrabObject(col);
//			}
		}
	}
	void GrabObject(Collider coli)
	{
		coli.transform.SetParent(gameObject.transform);
		coli.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse(2000);
	}
	void DropObject(Collider coli)
	{
		coli.transform.SetParent(null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity;
		rigidBody.angularVelocity = device.angularVelocity;
	}
}
