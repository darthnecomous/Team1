﻿using UnityEngine;
using System.Collections;

public class Car_Trigger_Register : MonoBehaviour {

	Mission_Generator Mscript;

	// Use this for initialization
	void Start () 
	{
		Mscript = GameObject.Find ("Main Camera").GetComponent<Mission_Generator> ();
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Car_Arrived_Trigger")
		{
			Mscript.Driving_Mission_Sucess();
		}
	}
}
