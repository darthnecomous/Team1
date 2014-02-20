using UnityEngine;
using System.Collections;

public class scr_Car_Spawn : MonoBehaviour {
	public int R;
	GameObject Car;
	GameObject House;
    Quaternion HouseFacing;
	int HouseP;
	// Use this for initialization
	void Start () {
		Car = GameObject.Find ("Car_Prefab");
		R = Random.Range (0, 8);
		HouseP = Random.Range (0, 4);
		HouseFacing = transform.rotation;

		if (R == 1) {
			Instantiate(Car);
			//Car.transform.position = transform.localPosition + new Vector3 (0,0,11);
			Car.transform.position = transform.localPosition - (transform.right* 13);
			//Car.transform.position = transform.localPosition - (transform.forward* HouseP);

			Car.transform.rotation = HouseFacing;
			Car.transform.Rotate(Car.transform.up,92f);
			//Car.transform.position = transform.position + (transform.forward * 50);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
