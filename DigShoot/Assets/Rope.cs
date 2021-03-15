using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public static Rope instance;

    private void Awake()
    {
        instance = this;
    }

    public void BreakRope() {
        this.gameObject.SetActive(false);
        Anvil.instance.SetRigidBodyActive();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            BreakRope();
            Destroy(other.gameObject);
        }
    }

}
