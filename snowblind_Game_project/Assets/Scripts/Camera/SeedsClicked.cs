using UnityEngine;
using System.Collections;

public class SeedsClicked : MonoBehaviour {

    public GameObject AudioControl;
    public GameObject spawner;
    public bool isCollected;
    public float timeUntilRespawn;
    private float respawnTimer;
    public Canvas notifier;

    // Use this for initialization
    void Start ()
    {
        respawnTimer = timeUntilRespawn;
        spawner = GameObject.Find("PlayerObjectSpawner");
        AudioControl = GameObject.Find("Audio");
    }
	
	// Update is called once per frame
	void Update ()
    {
        respawnTimer -= Time.deltaTime;

        if (respawnTimer <= 0)
        {
            isCollected = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            notifier.enabled = true;
        }
    }

    void OnMouseDown()
    {
        if (isCollected == false)
        {
            spawner.GetComponent<Pick_up_seeds>().AddToSeeds();
            AudioControl.GetComponent<Audio_controler>().PlayCollectSaplings();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            notifier.enabled = false;
            isCollected = true;
            respawnTimer = timeUntilRespawn;
        }
    }
}
