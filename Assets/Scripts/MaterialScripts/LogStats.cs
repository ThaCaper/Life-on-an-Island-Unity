using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStats : MonoBehaviour
{
    public string _name;
    public int logValue;
    public ItemObject log;
    public InventoryObject inventory;

    public LogStats(ItemObject log)
    {
        _name = log.name;
        logValue = log.value;
    }

    private bool isInRange;
    public void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (log != null)
            {
                inventory.AddItem(log, logValue);
                log = null;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
