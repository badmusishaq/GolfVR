using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfCups : MonoBehaviour {
	public GameManager gManager;
	public ParticleSystem ps;

	public GameObject golfCups;
	public GameObject NextSceneCanvas;
	public GameObject youWin;


	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter (Collider other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody> ();
		AudioSource aud = other.GetComponent<AudioSource> ();

		if (other.gameObject.CompareTag ("Ball"))
		{
			PlayParticle ();

			aud.Play ();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;

			gManager.CupsEntered ();

			StartCoroutine (Deactivate ());
		}
		if ((gManager.cupsEntered == gManager.golfCups.Count) && (gManager.cupsEntered < 40))
		{
			youWin.SetActive (true);
		}

		else if (gManager.cupsEntered == gManager.golfCups.Count)
		{
			NextSceneCanvas.SetActive (true);
		}
			
	}

	IEnumerator Deactivate()
	{
		yield return new WaitForSeconds (2.5f);

		golfCups.SetActive (false);

	}

	void PlayParticle()
	{
		ps.Play ();
	}

}
