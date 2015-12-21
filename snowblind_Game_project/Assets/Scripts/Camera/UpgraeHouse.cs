using UnityEngine;
using System.Collections;

public class UpgraeHouse : MonoBehaviour {

    public GameObject houseGrower;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        houseGrower.GetComponent<HouseGrow>().HouseUpgrade();
    }
}
