using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    public static Anvil instance;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void SetRigidBodyActive()
    {
        rb.isKinematic = false;
    }
}
