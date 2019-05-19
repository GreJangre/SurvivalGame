using System.Collections;

public class HandController : CloseWeaponController
{
    // 활성화 여부
    public static bool isActivate = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isActivate)
        {
            TryAttack();
        }
    }
    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
                isSwing = false;
            }

            yield return null;
        }
    }
    public override void CloseWeaponChange(CloseWeapon closeWeapon)
    {
        base.CloseWeaponChange(closeWeapon);
        isActivate = true;
    }
}
