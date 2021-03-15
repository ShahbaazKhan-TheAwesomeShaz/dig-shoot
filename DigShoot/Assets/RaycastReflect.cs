using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RaycastReflect : MonoBehaviour
{
    public int reflections;
    public float maxLength;
    public Transform rayCastPoint;


    private LineRenderer lineRenderer;
    private Ray2D ray;
    private RaycastHit hit;
    private RaycastHit2D hit2D;

    Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }   

    // Update is called once per frame
    void Update()
    {


        ray = new Ray2D(rayCastPoint.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, rayCastPoint.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            #region 3D raycast Logic
            //if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            //{
            //    lineRenderer.positionCount += 1;
            //    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
            //    remainingLength -= Vector3.Distance(ray.origin, hit.point);

            //    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

            //    //Debug Line
            //    if (hit.collider.CompareTag("Sand")) { Debug.Log("Hitting sand right now"); }


            //    if (!hit.collider.CompareTag("Block")) { break; }
            //}
            //else
            //{
            //    lineRenderer.positionCount += 1;
            //    lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            //}

            #endregion


            hit2D = Physics2D.Raycast(ray.origin, ray.direction, remainingLength);

            // hit2D.collider.CompareTag("Block") || hit2D.collider.CompareTag("Sand"))
            if (hit2D.collider!=null)
            {

                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit2D.point);
                remainingLength -= Vector2.Distance(ray.origin, hit2D.point);

                direction = Vector2.Reflect(ray.direction, hit2D.normal);

                ray = new Ray2D(hit2D.point, direction);

                //if (!hit2D.collider.CompareTag("Sand") || !hit2D.collider.CompareTag("Block")) { break; }
                if (!hit2D.collider.CompareTag("Block")) { break; }
            }
            else
            {
                lineRenderer.positionCount += 1;
                //lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }
}
