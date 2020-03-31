using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
            Attack();

        if (Input.GetMouseButton(1) && !Input.GetMouseButtonDown(0))
            Defend();
    }

    public override void Attack()
    {
        Debug.Log("Attacco tank");
    }

    private void Defend()
    {
        Debug.Log("Paro");
    }
}
