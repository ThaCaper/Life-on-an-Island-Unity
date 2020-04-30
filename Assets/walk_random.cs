using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_random : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody rb;
    public Vector2 movement;

    private Rigidbody iguana;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        movement = new Vector2(Random.value, 0);
        rb.AddForce( direction * speed);
    }
}
