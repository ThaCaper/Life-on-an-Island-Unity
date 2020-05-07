using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelscript : MonoBehaviour
{
    public GameObject panel; // panel is the blue box we use as the inventory
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false); // removed inventory form beginning
    }

    public void showAndHideInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (panel.active == false)
            {
                panel.gameObject.SetActive(true);
            }
            else
            {
                panel.gameObject.SetActive(false);
            }
        }
    } // show or remove inventory on screen when pressing i
    // Update is called once per frame
    void Update()
    {
       showAndHideInventory();
    }
}
