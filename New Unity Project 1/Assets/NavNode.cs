﻿using UnityEngine;
using System.Collections;

public class NavNode : MonoBehaviour {//put on all nodes
	public int NodeNumber;//nodes unique number, 2 the same will cause problems, also the nodes position in the master array
	public int[] AdjNodes = new int[6];//List of adjacent nodes, size is default only and must be changed in editor to actual amount of nodes, you can have more then one of a node to increase the chance it is chosen
	static public int RNG;//place to put RNG results, usable in all scripts
	public GameObject spawn;//the object to be spawned, replace with multiple variables and re bild when you want to choose between different types.

	// Use this for initialization
	void Start () {
		nodes.nodeList [NodeNumber] = new NodeStore (this.transform.position, AdjNodes);
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(PlayerStore.PlayerLoc , nodes.nodeList[NodeNumber].loc) > 30 && Vector3.Distance(PlayerStore.PlayerLoc , nodes.nodeList[NodeNumber].loc) < 60 )//if in spawn range of player
		{
		RNG = Random.Range (0, 200);//0.5% per node to spawn people
		if (RNG < 1) 
		{
			GameObject tempPre;
			tempPre = Instantiate(spawn, nodes.nodeList[NodeNumber].loc, Quaternion.identity) as GameObject;
			tempPre.GetComponent<NewBehaviourScript>().target = NodeNumber;
			}
		}
	}
}
