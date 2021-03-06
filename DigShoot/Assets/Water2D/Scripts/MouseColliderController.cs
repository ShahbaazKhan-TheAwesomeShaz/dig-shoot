﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseColliderController : MonoBehaviour
{
	CircleCollider2D col;
	public Vector2 offset = new Vector2(2f, -4f);

	void Start()
    {
		col = GetComponent<CircleCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
		//col.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		//if (Input.GetMouseButton(0)) {
		//	col.enabled = true;
		//	col.transform.position = (Vector2) Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//} else {
		//	col.enabled = false;
		//}
	}
}
