using System.Collections;
using UnityEditor;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int treeHealth = 5;
    public Transform logs;
    public GameObject tree;
    public Vector3 position;

    public int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        tree = this.gameObject;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeHealth <= 0)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            StartCoroutine(DestroyTree());
        }
    }

    IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(7);
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(tree);

        position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(logs, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(2, 0, 0) + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(5, 0, 0) + position, Quaternion.identity);
    }
}
