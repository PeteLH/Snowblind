using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HouseGrow : MonoBehaviour {

    public GameObject AudioControl;

    public int houseSize;
    public bool upgradeAvailable = false;

    public GameObject pickUpCounter;
    public GameObject UpgradeCostText;

    public GameObject house1;
    public GameObject house2;
    public GameObject house3;

    public GameObject upgardeIcone1;

    public bool isPlaced;

    // Use this for initialization
    void Awake ()
    {
        pickUpCounter = GameObject.Find("PlayerObjectSpawner");
        pickUpCounter.GetComponent<Pick_up_seeds>().ListTheHouses();
        AudioControl = GameObject.Find("Audio");

        if (isPlaced == false)
        {
            Vector3 setAngle = new Vector3(0, 45, 0);
            gameObject.transform.eulerAngles = setAngle;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (houseSize)
        {
            case 0:
                house1.SetActive(true);
                break;

            case 1:
                house1.SetActive(false);
                house2.SetActive(true);
                break;

            case 2:
                house2.SetActive(false);
                house3.SetActive(true);
                break;
        }
    }


    public void HouseUpgradeAvailable() //upgrades are avaialble...
    {
        if (houseSize == 0 && pickUpCounter.GetComponent<Pick_up_seeds>().woodCollected >= 10) //here we check the houses current size
        {
            upgardeIcone1.SetActive(true); //... so set the upgrade icon to true
            UpgradeCostText.GetComponent<Text>().text = "10x Wood";
        }
        else if (houseSize == 1 && pickUpCounter.GetComponent<Pick_up_seeds>().woodCollected >= 50 && pickUpCounter.GetComponent<Pick_up_seeds>().RockCollected >= 20) //here we check the houses current size
        {
            upgardeIcone1.SetActive(true); //... so set the upgrade icon to true
            UpgradeCostText.GetComponent<Text>().text = "50x Wood\n20x Rock";
        }
        else
        {
            upgardeIcone1.SetActive(false);
        }
    }

    public void HouseUpgradeNotAvailable()
    {
        upgardeIcone1.SetActive(false);
    }

    public void HouseUpgrade() //this is activated when the player clicks the upgrade button
    {
        switch (houseSize)
        {
            case 0:
                pickUpCounter.GetComponent<Pick_up_seeds>().HouseUpgradeOne();
                houseSize = houseSize + 1; //thsi determines which upgrde will happen on the next upgrade button click
                AudioControl.GetComponent<Audio_controler>().PlayHammer();
                break;

            case 1:
                pickUpCounter.GetComponent<Pick_up_seeds>().HouseUpgradeTwo();
                houseSize = houseSize + 1; //thsi determines which upgrde will happen on the next upgrade button click
                AudioControl.GetComponent<Audio_controler>().PlayHammer();
                break;
        }
    }
}
