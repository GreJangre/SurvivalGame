using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    // 체력
    [SerializeField] private int hp;
    private int currentHp;

    // 스태미나
    [SerializeField] private int sp;
    private int currentSp;

    // 스태미나 증가량
    [SerializeField] private int spIncreaseSpeed;
    
    // 스태미나 재회복 딜레이
    [SerializeField] private int spReChargeTime;
    private int currentSpRechargeTime;
    
    // 스태미나 감소 여부
    private bool spUsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
