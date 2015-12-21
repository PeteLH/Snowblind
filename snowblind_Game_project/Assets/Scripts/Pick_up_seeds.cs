using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Pick_up_seeds : MonoBehaviour {

    public GameObject House;
    public GameObject SeedText;
    public GameObject woodText;
    public GameObject RockText;
    public GameObject houseCountText;
    public int seedCount;
    public int woodCollected;
    public int RockCollected;
    public GameObject woodStaticText;
    public GameObject SeedStaticText;

    public GameObject[] houses;

    // Use this for initialization
    void Start()
    {
        Invoke("ListTheHouses", 0);
    }

    // Update is called once per frame
    void Update()
    {
        SeedText.GetComponent<Text>().text = seedCount.ToString() + " Saplings";
        woodText.GetComponent<Text>().text = woodCollected.ToString() + " Wood";
        RockText.GetComponent<Text>().text = RockCollected.ToString() + " Rocks";
        houseCountText.GetComponent<Text>().text = houses.Length.ToString() + " Houses";
    }

    public void AddToSeeds()
    {
        seedCount = seedCount + Random.Range(1, 5);
    }

    public void ListTheHouses()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        Invoke("checkHouseUpgradesAvailable", 0);
    }

    public void HouseUpgradeOne()
    {
        woodCollected = woodCollected - 10;
        Invoke("checkHouseUpgradesAvailable", 0);
    }

    public void HouseUpgradeTwo()
    {
        woodCollected = woodCollected - 50;
        RockCollected = RockCollected - 20;
        Invoke("checkHouseUpgradesAvailable", 0);
    }

    public void checkHouseUpgradesAvailable() // checks to see if the player can affor a upgrade 
    {
            foreach (GameObject house in houses) //looks through all the spawned houses and for each one there is set the upgrade button activated
            {
                    house.GetComponent<HouseGrow>().HouseUpgradeAvailable(); //sets the upgrdae buton funtion on each house
            }
    }
}