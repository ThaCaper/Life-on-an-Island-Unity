using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialTypes
{
    Log,
    Stone,
    Iron,
}
public abstract class ItemObject : ScriptableObject
{

    public GameObject prefab;
    public int value;
    public MaterialTypes type;
    [TextArea(15, 20)]
    public string description;


}
