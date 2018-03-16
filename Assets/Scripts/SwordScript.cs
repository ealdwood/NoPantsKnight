using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public GameObject target;
    public float attackDistance;

    private Animator m_Anim;

    void Awake()
    {
        m_Anim = GetComponent<Animator>();
    }

    void Update ()
    {
        if (m_Anim.GetBool("isAttacking"))
        {
            Attack();
        }
    }
	
    void Attack()
    { 
        if(target == null)
        {
            return;
        }
        float distance = Vector2.Distance(transform.position, target.transform.position);
        bool facingEnemy = transform.localScale.x > 0
                            ? target.transform.position.x > transform.position.x
                            : target.transform.position.x < transform.position.x;

        if (distance < attackDistance && facingEnemy)
        {
            BroadcastMessage("PlayKilledEnemySound");
            Destroy(target, 0.1F);
        }          
    }
}
