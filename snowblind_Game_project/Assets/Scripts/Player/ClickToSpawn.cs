using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickToSpawn : MonoBehaviour
{
    public GameObject AudioControl;
    public GameObject toolTip;
    public string toolTipText;
    public GameObject houseCore;
    public Terrain gameTerrain;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    public GameObject uIPannel;

    public int houseCost;
    public int rockCost;

    public int selectedobject;
    RaycastHit hit;

    public int treeCount;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        toolTip.GetComponent<Text>().text = toolTipText;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //gameTerrain.GetComponent<Collider>().Raycast
                {
                    if (hit.collider.tag == "Ground")
                    {
                        if (selectedobject == 1 && gameObject.GetComponent<Pick_up_seeds>().seedCount >= 1)
                        {
                            gameObject.GetComponent<Pick_up_seeds>().seedCount = gameObject.GetComponent<Pick_up_seeds>().seedCount - 1;
                            Instantiate(objectOne, hit.point, Quaternion.identity);
                            AudioControl.GetComponent<Audio_controler>().PlayDrum();
                        }

                        if (selectedobject == 2 && gameObject.GetComponent<Pick_up_seeds>().RockCollected >= 1)
                        {
                            Instantiate(objectTwo, hit.point, Quaternion.identity);
                            gameObject.GetComponent<Pick_up_seeds>().RockCollected = gameObject.GetComponent<Pick_up_seeds>().RockCollected - rockCost;
                        }

                        if (selectedobject == 3 && gameObject.GetComponent<Pick_up_seeds>().woodCollected >= houseCost)
                        {
                            gameObject.GetComponent<Pick_up_seeds>().woodCollected = gameObject.GetComponent<Pick_up_seeds>().woodCollected - houseCost;
                            Instantiate(objectThree, hit.point, Quaternion.identity);
                            AudioControl.GetComponent<Audio_controler>().PlayHammer();
                        }
                    }
                }
            }
        }
    }

    public void PlusOneFullTree()
    {
        treeCount = treeCount + 1;
    }

    public void UseCursor()
    {
        selectedobject = 0;
        toolTipText = "";
    }

    public void SetPlaceTree()
    {
        selectedobject = 1;
        toolTipText = "PLACE SAPLING\nCost: 1x Sapling\n\nEventually the sapling will grow\ninto a mighty tree,\nallowing you to harvest it for wood";
    }

    public void SetPlaceRock()
    {
        selectedobject = 2;
        toolTipText = "PLACE ROCK\nCost: 1x Rock\n\nNeed to dump some\nboulders? You're in the right place.";
    }

    public void SetPlaceHouse()
    {
        selectedobject = 3;
        toolTipText = "PLACE HOUSE\nCost: 20x Wood\n\nPlace a basic house.";
    }

    public void SetUseAxe()
    {
        selectedobject = 5;
        toolTipText = "USE AXE\n\nEquip your axe and chop\ndown some of those trees!";
    }

    public void SetUsePik()
    {
        selectedobject = 6;
        toolTipText = "USE PICK\nCost: 5x Wood\n\nEquip your pick and mine\nsome rock!";
    }
}

