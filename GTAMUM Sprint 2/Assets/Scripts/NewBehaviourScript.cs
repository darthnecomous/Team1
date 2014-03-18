using UnityEngine;
using System.Collections;




public class NewBehaviourScript : MonoBehaviour {//put on all pedestrians, makes them move and sets thier targets
	public NavMeshAgent agent;//always attach a navmeshagent too

	public int target;
	int last;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, nodes.nodeList[target].loc) < 2) {//if at node
			if(Vector3.Distance(PlayerStore.PlayerLoc , nodes.nodeList[target].loc) > 100)//if out of range
			{
				nodes.pedCount --;
				Destroy(this.gameObject);
			
			}
			else{
				NavNode.RNG = Random.Range(0,nodes.nodeList[target].adjNodes.Length);//choose adacent
			if (nodes.nodeList[target].adjNodes[NavNode.RNG] != last)
			{
				last = target;//go to adjacent
				target = nodes.nodeList[target].adjNodes[NavNode.RNG];
				agent.SetDestination(nodes.nodeList[target].loc);
                transform.LookAt(nodes.nodeList[target].loc);
                transform.Rotate(new Vector3(0, 1, 0), -90);
			}
						
			}
				}
	
	}
}
