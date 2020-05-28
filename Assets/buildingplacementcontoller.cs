using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingplacementcontoller : MonoBehaviour
{

    // listen over alle bygninger
    [SerializeField]
    private GameObject[] placeableObjectPrefabs;

    //den valget bygning 
    [SerializeField]
    private GameObject currentPlaceObject;
    
    //denne variable bruges kun at nulstille når vi har vagle en bygning
    private int currentPrefabIndex = -1;

    // Update is called once per frame
    //
    private void Update()
    {
        HandleNewObjectHotKey();
        // vi tjekker på om man har valget en bygning
        if (currentPlaceObject != null)
        {
            // kommetar står ved functionerne
            MoveCurrentPlaceableObjectToMouse();
            rotateFromMouseWheel();
            releaseIfClick();
        }
    }


    //releaseIfClick()
    // tjekker på om vi trykker på b 
    // derefter sætter vi vores current object til null for at ikke gemme den bygning vi valgt 
    private void releaseIfClick()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            currentPlaceObject = null;
        }
    }

    //rotateFromMouseWheel()
    // tjekker på om vi trykker på Q eller E og rotater bygning til venstre eller højre
    // TODO rotate with Q and E
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


    /*
     *MoveCurrentPlaceableObjectToMouse()
     */
    private void MoveCurrentPlaceableObjectToMouse()
    {
        // der vores mussen pjeler bliver der lavet en linje og der hvor linje rammer bliver bygning sat når der trykkes på B
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            // dette skal sørge for at bygningerne er rotater korret
            currentPlaceObject.transform.position = hitInfo.point;
            currentPlaceObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }


    /*
     *HandleNewObjectHotKey()
     * vi looper over vores placeableObjectPrefabs som er et array
     * så tjekker vi på om vi trykker på et tal fra 1 til og med 9
     * 
     *
     */
    private void HandleNewObjectHotKey()
    {
        for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        {


            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                /*
                 * den if statment tjekker på om vi tidligere har trykke på et tal
                 * så hvis vi har trykket på 5
                 * og så trykker på 5 igen så sletter vi bygning
                 *
                 * else
                 *
                 * vi tjekker om currentPlaceObject != null
                 *så hvis vi har trykket på 5
                 * og så trykker på 3 igen så sletter vi bygning
                 * så skulle vi gerne slette bygning 5
                 * derefter satte vi vores currentprefab ind i spillet
                 *
                 */
                if (pressedKeyOfCurrentPrefab(i))
                {
                    Destroy(currentPlaceObject);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentPlaceObject != null)
                    {
                        Destroy(currentPlaceObject);
                    }
                    currentPlaceObject = Instantiate(placeableObjectPrefabs[i]);
                    currentPrefabIndex = i;
                }

                   

            }
        }
    }

    private bool pressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceObject != null && currentPrefabIndex == i;
    }
}
