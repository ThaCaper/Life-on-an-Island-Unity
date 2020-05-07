using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public GameObject panel;



    public void showAndHidePanel()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (panel.active == true)
            {
                panel.gameObject.SetActive(false);
            }
            else
            {
                panel.gameObject.SetActive(true);
            }


        }
    }
    // Start is called before the first frame update
    void Start()
    {
       panel.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
       showAndHidePanel();
    }
}
