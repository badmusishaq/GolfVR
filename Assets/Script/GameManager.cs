using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GolfCups> golfCups;
	public int cupsEntered;


	public void CupsEntered()
	{
		cupsEntered++;
	}
}
