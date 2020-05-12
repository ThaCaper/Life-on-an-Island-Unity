using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AxeController : MonoBehaviour, ToolInterface
{
    //For Chopping
    public int rayLength = 10;
    public Vector3 forward;
    public RaycastHit hit;

    private bool treeHasFallen = false;
    private TreeController treeScript;

    //For Axe animation
    public int dmg = 10;
    public float maxDistance = 1.5f;
    public Animator anim;
    public float dmgDelay = 0.6f;

    private float distance;
    private Vector3 ray;
    private int attack1Streak = 0;
    private int attack2Streak = 0;

    public float CPSlimit = 10f;
    public float timeout = 0;
    // Update is called once per frame
    void Update()
    {
        /*if (timeout > 0)
        {
            timeout -= Time.deltaTime;
        }
        */
        if (Input.GetButtonDown("Fire1"))
        {
            //timeout = 1f; //CPS limit
            StartCoroutine(ToolAttack());
            HitTree();
        }

        
    }

    IEnumerator WaitForTree()
    {
        yield return new WaitForSeconds(7);
        treeHasFallen = true;
    }


    public IEnumerator ToolAttack()
    {
        if (Random.value >= 0.5 && attack1Streak <= 2)
        {
            anim.SetBool("Hit01", true);
            attack1Streak += 1;
            attack2Streak = 0;
        }
        else
        {
            if (attack2Streak <= 2)
            {
                anim.SetBool("Hit02", true);
                attack1Streak = 0;
                attack2Streak += 1;
            }
            else
            {
                anim.SetBool("Hit01", true);
                attack1Streak += 1;
                attack2Streak = 0;
            }
        }


        yield return new WaitForSeconds(dmgDelay);
        //Actual attacking
        RaycastHit hit;
        ray = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        if (Physics.Raycast(Camera.main.ScreenPointToRay(ray), out hit))
        {
            distance = hit.distance;
            if (distance < maxDistance)
            {
                hit.transform.SendMessage("ApplyDmg", dmg, SendMessageOptions.DontRequireReceiver);
            }
        }
        anim.SetBool("Hit01", false);
        anim.SetBool("Hit02", false);
    }

    void HitTree()
    {
        forward = Camera.main.transform.forward;
        if (Physics.Raycast(transform.position, forward, out hit, rayLength))
        {
            if (hit.collider.gameObject.tag == "Tree")
            {
                treeScript = GameObject.Find(hit.collider.gameObject.name).GetComponent<TreeController>();
                if (Input.GetButtonDown("Fire1").Equals(true))
                {
                    Debug.Log("Tree got hit");
                    treeScript.treeHealth -= 1;
                    StartCoroutine(WaitForTree());
                }
            }
        }
    }
}
