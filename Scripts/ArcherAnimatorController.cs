using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimatorController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 获取当前动画状态信息
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("DeathTrigger", true);
        }
        else
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetTrigger("BeAttacked");
        }

        if (animatorStateInfo.IsName("Walk"))
        {

        }
        else
        if (animatorStateInfo.IsName("Kick"))
        {
            if (animatorStateInfo.normalizedTime >= 0.9f)
            {
                animator.SetBool("KickAttack", false);
            }
        }
        else
        if (animatorStateInfo.IsName("Shoot"))
        {
            if (animatorStateInfo.normalizedTime >= 0.9f)
            {
                animator.SetBool("ShootAttack", false);
            }
        }
        else
        if (animatorStateInfo.IsName("HitReaction"))
        {
            animator.SetBool("KickAttack", false);
            animator.SetBool("ShootAttack", false);
        }
        else
        if(animatorStateInfo.IsName("Death"))
        {
            animator.SetBool("Died", true);
        }
    }
}
