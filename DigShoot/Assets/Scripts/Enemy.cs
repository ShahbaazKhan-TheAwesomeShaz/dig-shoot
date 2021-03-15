using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            anim.SetTrigger("Dead");
            Debug.Log("Enemy is Dead");
            StartCoroutine(WinAfterTime());
        }
        

    }

    IEnumerator WinAfterTime()
    {
        yield return new WaitForSeconds(2f);
        GameController.instance.LevelComplete();
    }

}
