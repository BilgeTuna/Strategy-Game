using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageToSprite : MonoBehaviour
{
    public GameObject prefab;
    private GameObject soldier;
    private Animator anim;


    private void Awake()
    {
        soldier = GameObject.FindWithTag("Soldier");
        anim = soldier.GetComponent<Animator>();
    }
    public void Button()
    {
        soldier.GetComponent<SoldierMovement>().GetComponent<SoldierMovement>().enabled = false;
        anim.SetBool("isWalinkg", false);
        Vector3 prefabPos = new Vector3(0, 0, 0);
        Instantiate(prefab, prefabPos, Quaternion.identity);
        StartCoroutine(AfterClick());
    }

    private IEnumerator AfterClick()
    {
        yield return new WaitForSeconds(1f);
    }
}
