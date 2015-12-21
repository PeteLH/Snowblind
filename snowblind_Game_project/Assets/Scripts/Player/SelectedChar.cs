using UnityEngine;
using System.Collections;

public class SelectedChar : MonoBehaviour {

    public float charSpeed = 1f;
    public Terrain goTerrain;
    private bool selected;

    bool isCharMoving;
    RaycastHit hit;
    Vector3 targetPos;

    // Use this for initialization
    void Start ()
    {
        Invoke("CharSelected", 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity) && selected == true)
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                isCharMoving = true;
            }
        }

        if (isCharMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, charSpeed * Time.deltaTime);
        }

        if (transform.position == hit.point)
        {
            isCharMoving = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Invoke("CharNotSelected", 0);
        }
    }

    void OnMouseDown()
    {
        if (selected == false)
        {
            Invoke("CharSelected", 0);
        }
        else
        {
            Invoke("CharNotSelected", 0);
        }
    }

    void CharSelected()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        selected = true;
    }

    void CharNotSelected()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        selected = false;
    }
}
