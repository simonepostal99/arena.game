using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    //[SerializeField] GameObject cam;
    [SerializeField] float interactionDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }

    private void checkCollision()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            RaycastHit hit;
            //Ray pointer = new Ray(transform.position, Vector3.forward);

            Debug.DrawRay(transform.position, Vector3.forward * interactionDistance);


            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                if (hit.collider.tag == "Unit")
                {
                    Debug.Log("Colpito!");
                    hit.collider.GetComponent<Knockback>().knockback(transform.forward);
                }
            }
        }
    }
}
