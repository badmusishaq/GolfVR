using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;


	public SteamVR_LoadLevel levelLoader;



	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();

	}

	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);


	}


	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.CompareTag("GolfClub") || col.gameObject.CompareTag("Disable"))
		{
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger))
			{
				DropObject (col);
			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) 
			{
				HoldObject (col);			
			}
		}

		if (col.gameObject.CompareTag ("NextScene"))
		{
			if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger))
			{
				GotoScene ();
			}
		}

	}

	public void HoldObject (Collider coli)
	{
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse (2000);
	}

	public void DropObject (Collider coli)
	{
		coli.transform.SetParent (null);
		Rigidbody rigidbody = coli.GetComponent<Rigidbody> ();
		rigidbody.isKinematic = true;
	}

	public void GotoScene ()
	{
		levelLoader.Trigger ();
	}
}
