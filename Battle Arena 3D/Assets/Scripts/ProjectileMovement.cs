using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Rigidbody bodyArrow;
    int team;

    private void Awake()
    {
        bodyArrow = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //aggiorno la rotazione della freccia (movimento parabolico)
        transform.rotation = Quaternion.LookRotation(bodyArrow.velocity);
    }


    //other è il collider dell'oggetto colpito
    private void OnTriggerEnter(Collider other)
    {
        //controllo se la freccia si scontra contro un'unità
        if(other.tag == "Unit")
        {
            //controllo se l'unità è del team avversario della freccia
            if(other.GetComponent<Unit>().getTeam() != team)
            {
                //eseguo il knockvbck sull'avversario
                other.GetComponent<Knockback>().knockback(transform.forward);

                //distruggo la freccia
                Destroy(gameObject);
            }
        }else if (other.tag == "SceneObject")
        {
            //distruggo la freccia
            Destroy(gameObject);
        }
    }


    public void setTeam(int teamValue)
    {
        team = teamValue;
    }
}
