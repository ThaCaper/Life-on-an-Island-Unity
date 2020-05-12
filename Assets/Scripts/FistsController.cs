using System.Collections;
using UnityEngine;

public class FistsController : MonoBehaviour
{
    public int dmg = 10;
    public float maxDistance = 1.5f;
    public Animator anim;
    public float dmgDelay = 0.6f;

    private float distance;
    private Vector3 ray;
    private int attack1Streak = 0;
    private int attack2Streak = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WeaponAttack());
        }
    }

    public IEnumerator WeaponAttack()
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
}
