using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponManager : MonoBehaviour
{
    // 무기 중복 교체 실행 방지
    public static bool isChangeWeapon = false;
    
    // 현재 무기, 애니메이션
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;
    
    // 현재 무기 타입
    [SerializeField] private string currentWeaponType;

    // 무기 교체 딜레이, 교체 종료 시점
    [SerializeField] private float changeWeaponDelayTime;
    [SerializeField] private float changeWeaponEndDelayTime;
    
    // 무기 종류
    [SerializeField] private CloseWeapon[] hands;
    
    // 무기 관리
    private Dictionary<string, CloseWeapon> handDictionary = new Dictionary<string, CloseWeapon>();
    
    // 필요한 컴포넌트
    [SerializeField] private HandController theHandController;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hands.Length; i++)
        {
            handDictionary.Add(hands[i].closeWeaponName, hands[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChangeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                StartCoroutine(ChangeWeaponCorutine("HAND", "맨손"));
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                StartCoroutine(ChangeWeaponCorutine("HAND", "맨손"));
        }
    }

    public IEnumerator ChangeWeaponCorutine(string type, string name)
    {
        isChangeWeapon = true;
        currentWeaponAnim.SetTrigger("Weapon_Out");
        
        yield return new WaitForSeconds(changeWeaponDelayTime);

        CancelPreWeaponAction();
        WeaponChange(type, name);

        yield return new WaitForSeconds(changeWeaponEndDelayTime);

        currentWeaponType = type;
        isChangeWeapon = false;
    }

    private void CancelPreWeaponAction()
    {
        switch (currentWeaponType)
        {
            case "HAND":
                HandController.isActivate = false;
                break;
        }
    }

    private void WeaponChange(string type, string name)
    {
        if (type == "HAND")
        {
            theHandController.CloseWeaponChange(handDictionary[name]);
        }
    }
}
