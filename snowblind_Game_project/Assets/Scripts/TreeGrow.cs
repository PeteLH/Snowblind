using UnityEngine;
using System.Collections;

public class TreeGrow : MonoBehaviour {

    public GameObject AudioControl;
    public GameObject houseCore;
    public GameObject spawner;
    public GameObject sapling1;
    public GameObject sapling2;
    public GameObject tree1;
    public GameObject treeStump;

    public float timeTilGrow;

    public float sproutSapling2;
    public float sproutTree1;

    bool isGrowing = true;

	// Use this for initialization
	void Start ()
    {
        Vector3 randoAngle = new Vector3(0, Random.Range(0, 360), 0);
        gameObject.transform.eulerAngles = randoAngle;

        spawner = GameObject.Find("PlayerObjectSpawner");
        AudioControl = GameObject.Find("Audio");
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeTilGrow  += Time.deltaTime;

        if (timeTilGrow < sproutSapling2 && isGrowing == true)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.0001f, gameObject.transform.localScale.y + 0.0001f, gameObject.transform.localScale.z + 0.0001f);
        }

        if (timeTilGrow >= sproutSapling2 && isGrowing == true)
        {
            sapling1.SetActive(false);
            sapling2.SetActive(true);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.0001f, gameObject.transform.localScale.y + 0.0001f, gameObject.transform.localScale.z + 0.000f);
        }

        if (timeTilGrow >= sproutTree1 && isGrowing == true)
        {
            sapling2.SetActive(false);
            tree1.SetActive(true);
            isGrowing = false;
            spawner.GetComponent<ClickToSpawn>().PlusOneFullTree();
        }
        if (Input.GetMouseButtonDown(0) && spawner.GetComponent<ClickToSpawn>().selectedobject == 5)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (tree1.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))  //
            {
                if (hit.collider.tag == "Tree") //&& spawner.GetComponent<ClickToSpawn>().selectedobject == 5
                {
                    spawner.GetComponent<Pick_up_seeds>().woodCollected = spawner.GetComponent<Pick_up_seeds>().woodCollected + Random.Range(4, 10);
                    spawner.GetComponent<Pick_up_seeds>().checkHouseUpgradesAvailable(); // every time wood is collected check if an upgrae is available -> Pick_up_seeds
                    tree1.SetActive(false);
                    treeStump.SetActive(true);
                    AudioControl.GetComponent<Audio_controler>().PlayWoodChop();
                }
            }
        }
    }
}
