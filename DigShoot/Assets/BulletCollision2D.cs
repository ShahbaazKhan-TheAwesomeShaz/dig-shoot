using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision2D : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletDestroyPS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var destroyPS = Instantiate(bulletDestroyPS, transform.position, Quaternion.identity);
        Destroy(destroyPS, 1f);
        Destroy(bullet.gameObject);
    }
}
