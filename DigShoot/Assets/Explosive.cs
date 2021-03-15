using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Explosive : MonoBehaviour
{

    public GameObject explodePS;
    public GameObject bullet;
    public Animator playerAnim;

    public Rig playerHeadRig;
    
    BoxCollider2D boxCollider2D;
    Rigidbody rb;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        



        


    }

   

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(bullet);

            var explodeFX = Instantiate(explodePS, transform.position + new Vector3(0f,0f,-10f), Quaternion.identity);
            Destroy(explodeFX, 5f);

            playerHeadRig.weight = 0;
            playerAnim.SetTrigger("Dead");

            GameController.instance.LevelFailed();

            //Rope.instance.BreakRope();

            Destroy(gameObject);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
