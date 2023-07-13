using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delay : MonoBehaviour
{
    public GameObject beforeObject;
    public float delay = 0.1f;

    void Start()
    {
        StartCoroutine(PassedCoolTime(delay));
    }



    private IEnumerator PassedCoolTime(float CoolTimeDelay)
    {
        float cooltimePercent = 1f / 1000f;

       
            yield return new WaitForSeconds(CoolTimeDelay);
        


    }
}
