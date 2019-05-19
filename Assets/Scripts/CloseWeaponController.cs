using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloseWeaponController : MonoBehaviour
{
    // 현재 장착된 Hand형 타입 무기
    [SerializeField] private CloseWeapon currenCloseWeapon;
    
    // 공격중
    protected bool isAttack = false;
    protected bool isSwing = false;

    protected RaycastHit hitInfo;

    protected void TryAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isAttack)
            {
                StartCoroutine(AttackCorutine());
            }
        }
    }

    protected IEnumerator AttackCorutine()
    {
        isAttack = true;
        currenCloseWeapon.anim.SetTrigger("Attack");
        
        yield return new WaitForSeconds(currenCloseWeapon.attackDelayA);
        isSwing = true;
        
        // 공격 활성화 시점
        StartCoroutine(HitCoroutine());
        
        yield return new WaitForSeconds(currenCloseWeapon.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currenCloseWeapon.attackDelay - currenCloseWeapon.attackDelayA - currenCloseWeapon.attackDelayB);
        isAttack = false;
    }

    protected abstract IEnumerator HitCoroutine();

    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currenCloseWeapon.range))
        {
            return true;
        }
        return false;
    }

    public virtual void CloseWeaponChange(CloseWeapon closeWeapon)
    {
        if (WeaponManager.currentWeapon != null)
            WeaponManager.currentWeapon.gameObject.SetActive(false);

        currenCloseWeapon = closeWeapon;
        WeaponManager.currentWeapon = currenCloseWeapon.GetComponent<Transform>();
        WeaponManager.currentWeaponAnim = currenCloseWeapon.anim;

        currenCloseWeapon.transform.localPosition = Vector3.zero;
        currenCloseWeapon.gameObject.SetActive(true);
    }
}
