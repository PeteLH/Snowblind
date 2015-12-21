using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

    public GameObject AudioControl;
    public GameObject spawner;
    public bool isPlaced = true;
    public int rockHarvestCost;

    // Use this for initialization
    void Start ()
    {
        spawner = GameObject.Find("PlayerObjectSpawner");
        AudioControl = GameObject.Find("Audio");

        if (isPlaced == true)
        {
            Vector3 randoAngle = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            gameObject.transform.eulerAngles = randoAngle;
            gameObject.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && spawner.GetComponent<ClickToSpawn>().selectedobject == 6 && spawner.GetComponent<Pick_up_seeds>().woodCollected >= 5)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (gameObject.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))  //
            {
                if (hit.collider.tag == "Rock") //
                {
                    spawner.GetComponent<Pick_up_seeds>().RockCollected = spawner.GetComponent<Pick_up_seeds>().RockCollected + Random.Range(0, 2);
                    spawner.GetComponent<Pick_up_seeds>().woodCollected = spawner.GetComponent<Pick_up_seeds>().woodCollected - rockHarvestCost;
                    spawner.GetComponent<Pick_up_seeds>().checkHouseUpgradesAvailable();
                    AudioControl.GetComponent<Audio_controler>().PlayMineRock();
                    Destroy(gameObject);
                }
            }
        }
    }
}
