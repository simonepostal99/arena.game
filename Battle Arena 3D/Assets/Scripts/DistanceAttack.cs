using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{

    float projectileForce;
    float attackButtonPressedTime;
    [SerializeField] float maxChargeTime;
    [SerializeField] float projectileStepValue;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //aggiorno il tempo di pressione in secondi mentre tengo premuto il mouse
            attackButtonPressedTime += Time.deltaTime;           
        }

        if (Input.GetMouseButtonUp(0))
        {
            //assegno il valore della forza di lancio in base al tempo di pressione del mouse
            attackButtonPressedTime = Mathf.Clamp(attackButtonPressedTime, 0.0f, maxChargeTime);
            projectileForce = projectileStepValue * attackButtonPressedTime;

            //spawno il proiettile
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);

            //aggiungo la forza di lancio al proiettile
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);

            //assegno a quale team appartiene il proiettile
            projectile.GetComponent<ProjectileMovement>().setTeam(unit.getTeam());

            //azzero la forza di lancio
            attackButtonPressedTime = 0;
            projectileForce = 0;
        }

        
    }
}
