using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: demonstrate script interface to interact with terrain trees
 
// Steps: Attach this to main(parent/top) Player gameObject, or adjust myTransform to your hierarchy,
// define Inspector values for harvestTreeDistance, respawnTimer
// Setup a prefab tree with CAPSULE collider, how to at bottom of
// http://docs.unity3d.com/Documentation/Components/terrain-Trees.html
// paint terrain tree 
 
// Assign the non-collider prefab version of the tree to felledTree
// press Play, left click on terrain tree
 
// Harvested terrain tree info is passed to a manager object QM_ResourceManager for respawn management,
// you'll need that too or you could comment out any functionality related to manager 
 
// Note: this is not a demo of modifying terrainData permanently - there's enough risk involved with that
// such that you shouldn't try it unless you know what you are doing.

public class InteractTerrainTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
