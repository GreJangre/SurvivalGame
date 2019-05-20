using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private int hp; // 바위 체력

    [SerializeField] private float destroyTime; // 파편 제거 시간

    [SerializeField] private SphereCollider col; // 구체 컬라이더

    // 게임 오브젝트
    [SerializeField] private GameObject goRock; // 일반 바위
    [SerializeField] private GameObject goDebris; // 깨진 바위
    [SerializeField] private GameObject goEffectPrefabs;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip effectSound;
    [SerializeField] private AudioClip effectSound2;

    // 사운드 이름
    [SerializeField] private string strikeSound;
    [SerializeField] private string destroySound;
    public void Mining()
    {
        SoundManager.instance.PlaySoundEffect(strikeSound);
        var clone = Instantiate(goEffectPrefabs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destroyTime);
        
        hp--;

        if (hp <= 0)
            Destruction();
    }

    private void Destruction()
    {
        SoundManager.instance.PlaySoundEffect(destroySound);
        col.enabled = false;
        Destroy(goRock);
        
        goDebris.SetActive(true);
        Destroy(goDebris, destroyTime);
    }
}
