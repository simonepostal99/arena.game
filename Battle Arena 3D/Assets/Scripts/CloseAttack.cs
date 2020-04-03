using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    //[SerializeField] GameObject cam;
    [SerializeField] float interactionDistance;
    [SerializeField] Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //controllo se colpisco il nemico
        checkCollision();
    }

    private void checkCollision()
    {
        //controllo se premo il mouse sinistro
        if (Input.GetMouseButtonDown(0))
        {

            //creo un raggio nella direzione della camera per controllare se colpisco un oggetto
            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.forward * interactionDistance);


            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                //controllo se l'oggetto che ho colpito è un nemico
                if (hit.collider.tag == "Unit" && hit.transform.GetComponent<Unit>().getTeam() != unit.getTeam())
                {
                    //knockback sull'avversario colpito
                    hit.collider.GetComponent<Knockback>().knockback(transform.forward);
                }
            }
        }
    }
}
