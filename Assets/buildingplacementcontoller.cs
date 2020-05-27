using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingplacementcontoller : MonoBehaviour
{

    [SerializeField]
    private GameObject[] placeableObjectPrefabs;

    private GameObject currentPlaceObject;
    private float mouseWheelRotate;
    private int currentPrefabIndex = -1;

    // Update is called once per frame
    private void Update()
    {
        HandleNewObjectHotKey();
        if (currentPlaceObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            rotateFromMouseWheel();
            releaseIfClick();
        }
    }

    private void releaseIfClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceObject = null;
        }
    }


    // to do rotate with Q and E
    private void rotateFromMouseWheel()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentPlaceObject.transform.Rotate(Vector3.right,   90f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentPlaceObject.transform.Rotate(Vector3.left, 90f);
        }

      //  mouseWheelRotate += Input.mouseScrollDelta.y;
       // currentPlaceObject.transform.Rotate(Vector3.left,mouseWheelRotate * 10f);
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceObject.transform.position = hitInfo.point;
            currentPlaceObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }

    private void HandleNewObjectHotKey()
    {
        for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        {


            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                if (pressedKeyOfCurrentPrefab(i))
                {
                    Destroy(currentPlaceObject);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentPlaceObject == null)
                    {
                        Destroy(currentPlaceObject);
                    }
                    currentPlaceObject = Instantiate(placeableObjectPrefabs[i]);
                }

                   

            }
        }
    }

    private bool pressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceObject != null && currentPrefabIndex == i;
    }
}
