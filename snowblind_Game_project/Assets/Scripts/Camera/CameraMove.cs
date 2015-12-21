using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float scrollSpeed = 1f;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    private float camX;
    private float camZ;
    private float camZoom;

    public bool camResetBool;
    Vector3 homePos = new Vector3(0, 25, -47.32f);

    void Awake()
    {
        camX = transform.position.x;
        camZ = transform.position.z;
        camZoom = gameObject.GetComponent<Camera>().orthographicSize;
    }

    void LateUpdate()
    {
        if (camResetBool == false)
        {
            transform.position = new Vector3(camX, transform.position.y, camZ);

            gameObject.GetComponent<Camera>().orthographicSize = camZoom;
        }
    }

    void Update()
    {
        // zoom control
        if (camZoom >= 0.5 && camZoom <= 14)
        {
            camZoom -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        if (camZoom < 0.5)
        {
            camZoom = 0.5f;
        }
        if (camZoom > 14)
        {
            camZoom = 14;
        }


            // go north controll
            if (Input.GetKey("w"))
            {
                if (camZ <= maxZ)
                {
                    camZ = camZ + moveSpeed;
                }
            }

            // go south controll
            if (Input.GetKey("s"))
            {
                if (camZ >= minZ)
                {
                    camZ = camZ - moveSpeed;
                }
            }

            if (Input.GetKey("d"))
            {
                if (camX <= maxX)
                {
                    camX = camX + moveSpeed;
                }
            }

            if (Input.GetKey("a"))
            {
                if (camX >= minX)
                {
                    camX = camX - moveSpeed;
                }
            }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void ResetCamera()
    {
        camResetBool = true;
        if (camResetBool == true)
        {
            transform.position = homePos;
            camX = homePos.x;
            camZ = homePos.z;
            Invoke("ResetCameraBool", 0.1f);
        }
    }

    void ResetCameraBool()
    {
        camResetBool = false;
    }
}
