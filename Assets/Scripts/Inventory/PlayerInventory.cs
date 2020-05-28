using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var log = other.GetComponent<LogStats>();
        if (log)
        {
            inventory.AddItem(log.log, log.logValue);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
