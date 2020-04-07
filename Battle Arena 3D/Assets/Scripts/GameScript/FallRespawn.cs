using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    [SerializeField] GameObject lane;
    [SerializeField] private float distanceFall;

    Rigidbody body;
    private float unit;

    private float distance;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UnitType unitType = GetComponent<Unit>().getUnitType();
        int team = GetComponent<Unit>().getTeam();

        if(team == 1) //team destra
        {
            switch (unitType)
            {
                case UnitType.archer:
                    lane = GameManager.instance.getSpawnRightArcher();
                    break;

                case UnitType.witch:
                    lane = GameManager.instance.getSpawnRightWitch();
                    break;

                case UnitType.gladiator:
                    lane = GameManager.instance.getSpawnRightGladiator();
                    break;
            }
        }else if(team == 2) //team sinistra
        {
            switch (unitType)
            {
                case UnitType.archer:
                    lane = GameManager.instance.getSpawnLeftArcher();
                    break;

                case UnitType.witch:
                    lane = GameManager.instance.getSpawnLeftWitch();
                    break;

                case UnitType.gladiator:
                    lane = GameManager.instance.getSpawnLeftGladiator();
                    break;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //controlla la distanza tra il player e la lane
        checkDistance();
    }

    //controlla la distanza tra il player e la lane
    private void checkDistance()
    {
        //Calcoliamo la distanza del player dalla lane in valore assoluto per rendere il codice utilizzabile sempre
        distance = Mathf.Abs(lane.transform.position.y - transform.position.y);

        //Controlliamo se distance è più grande di un certo valore, allora il player respawna
        if(distance > distanceFall)
        {
            //spostiamo il player nell'area 3D in una posizione poco sopra la lane rispetto all'asse y per evitare che sia dentro la lane
            Vector3 v3 = new Vector3(lane.transform.position.x, lane.transform.position.y + 10, lane.transform.position.z);
            transform.position = v3;

            //disativiamo momentaneamente la gravità del player per mantenerlo sospeso in aria
            StartCoroutine(zeroGravity());
        }
    }

    //Metodo che ferma il player in aria rendendolo un'oggetto statico per dare l'impressione di gravità zero
    private IEnumerator zeroGravity()
    {
        body.isKinematic = true;
        yield return new WaitForSeconds(1.5f);
        body.isKinematic = false;
    }
}
