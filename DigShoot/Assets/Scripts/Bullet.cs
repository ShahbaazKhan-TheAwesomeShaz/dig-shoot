using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    Ray ray;

    Rigidbody rb;

    Vector3 lastVelocity;
    Vector3 direction;

    public LayerMask collisionMask;
    
    public GameObject bulletDestroyPS;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        
    }

    void OnCollisionEnter(Collision other)
    {
    
        var speed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);

        if (other.gameObject.CompareTag("Enemy"))
        {

            var destroyPS = Instantiate(bulletDestroyPS, transform.position, Quaternion.identity);
            Destroy(destroyPS, 1f);
            
            //Commented out for debug purposes
            //Destroy(gameObject);
        }

    }


        

    // Update is called once per frame
    void Update()
    {
        
        rb.MovePosition(transform.position + direction* speed * Time.deltaTime);
        rb.velocity = direction * Mathf.Max(speed, 0f);

        lastVelocity = rb.velocity;
        transform.rotation = Quaternion.LookRotation(rb.velocity);

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;
        //Debug.DrawLine(transform.position, transform.forward,Color.green);

        //if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
        //{
        //    Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
        //    float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
        //    transform.eulerAngles = new Vector3(rot, 0, 0);

        //}
    }
    
    
    
}
