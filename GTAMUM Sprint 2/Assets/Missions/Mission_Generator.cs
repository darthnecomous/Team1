using UnityEngine;
using System.Collections;

public class Mission_Generator : MonoBehaviour {

	Stats statScript;

	public GameObject[] Car_Triggers;

	public GameObject mission_Alert;

	public bool mission_active = false;

	string mission_Description = "";

	public int which_house = 0;

	public int mugsRequired = 0;

	int currentMugtotal;

	int mugTotalNeeded = -1;

	GLOBAL globalScript;

	bool mission_success = false;
	int counter = 0;
	int success_popup_timer = 500;

	// Use this for initialization
	void Start () 
	{
		globalScript = GameObject.Find ("Main Camera").GetComponent<GLOBAL> ();

		statScript = GameObject.Find ("StatsGameObj").GetComponent<Stats> ();

		Car_Triggers = GameObject.FindGameObjectsWithTag ("Car_Arrived_Trigger");

		for (int i = 0; i < Car_Triggers.Length; i++)
		{
			Car_Triggers[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 	
	{
		currentMugtotal = globalScript.TotalMuggings;

		if (mugTotalNeeded != -1)
		{
			mugsRequired = mugTotalNeeded - currentMugtotal;
			mission_Description = "Steal The Possesions Of " + mugsRequired + " People"; 
		}

		if (currentMugtotal == mugTotalNeeded)
		{
			mugTotalNeeded = -1;
			Mugging_Mission_Sucess();
		}

		if (mission_success)
		{

			if (counter == success_popup_timer)
			{
				mission_success = false;
				counter = 0;
			}

			else {counter++;}
		}

	}

	public void Mission_Type ()
	{
		int type = Random.Range (1, 100);

		if (type > 50){Driving_Mission();}

		else {Crime_Mission();}
	}

	public void Driving_Mission ()
	{
		mission_Description = "Drive To The Location On Your Map";

		which_house = Random.Range (0, Car_Triggers.Length);

		Car_Triggers [which_house].SetActive (true);

		Instantiate (mission_Alert, Car_Triggers [which_house].transform.position + new Vector3(0,60.0f,0), Quaternion.identity);

		mission_active = true;
	}

	public void Crime_Mission()
	{
		mugsRequired = Random.Range (1, 20);

		mission_active = true;

		mission_Description = "Steal The Possesions Of " + mugsRequired + " People"; 

		mugTotalNeeded = currentMugtotal + mugsRequired;
	}

	public void Mugging_Mission_Sucess()
	{
		mission_success = true;
		mission_active = false;

		Stats.money += 50;
	}

	public void Driving_Mission_Sucess()
	{
		mission_success = true;
		mission_active = false;

		Destroy (GameObject.Find ("Mission_Alert(Clone)"));

		Car_Triggers [which_house].SetActive (false);

		Stats.money += 50;

		statScript.suspicion += 20;
	}

	void OnGUI ()
	{
		if (mission_active)
		{
			GUI.Box(new Rect(Screen.width - 300, Screen.height-Screen.height, 300, 30), mission_Description);
		}

		if (mission_success)
		{
			GUI.Box(new Rect(Screen.width/2, Screen.height/2, 400, 60), "Mission Succcess! £50 has been sent to your bank!");
		}
	}
}
