using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float gunAccurancy;

    [SerializeField] private GameObject go_CrosshairHUD;

    public void WalkingAnimation(bool _flag)
    {
        //WeaponManager.currentWeaponAnim.SetBool("Walk", _flag);
        animator.SetBool("Walking", _flag);
    }

    public void RunningAnimation(bool _flag)
    {
        //WeaponManager.currentWeaponAnim.SetBool("Run", _flag);
        animator.SetBool("Running", _flag);
    }
    
    public void JumpingAnimation(bool _flag)
    {
        animator.SetBool("Running", _flag);
    }

    public void CrouchingAnimation(bool _flag)
    {
        animator.SetBool("Crouching", _flag);
    }
}