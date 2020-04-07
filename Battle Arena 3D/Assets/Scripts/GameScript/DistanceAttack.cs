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
    [SerializeField] Transform positionSpawn;
    [SerializeField] Unit unit;
    [SerializeField] float sensitivityZoomIn, sensitivityZoomOut;
    [SerializeField] float maxCameraFieldOfView, minCameraFieldOfView;
    [SerializeField] PhotonView photonView;

    private Camera camera;


    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

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

            //Zoomare la camera più il tasto sx è premuto
            float fov = camera.fieldOfView;
            fov -= attackButtonPressedTime * sensitivityZoomIn;
            fov = Mathf.Clamp(fov, minCameraFieldOfView, maxCameraFieldOfView);
            camera.fieldOfView = fov;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //assegno il valore della forza di lancio in base al tempo di pressione del mouse
            attackButtonPressedTime = Mathf.Clamp(attackButtonPressedTime, 0.0f, maxChargeTime);
            projectileForce = projectileStepValue * attackButtonPressedTime;

            //int team = unit.getTeam();

            //spawno il proiettile
            photonView.RPC("onShoot", PhotonTargets.All, transform.position, Quaternion.identity, projectilePrefab.name, projectileForce, unit.getTeam() );

            //PhotonNetwork.Destroy(projectile);

            //azzero la forza di lancio
            attackButtonPressedTime = 0;
            projectileForce = 0;


            //Riporto lo zoom allo stato originale
            camera.fieldOfView = maxCameraFieldOfView;
        }

        
    }

    [PunRPC]
    public void onShoot(Vector3 positionSpawn, Quaternion rotation, string projectileName, float projectileForce, int team)
    {
        double timeStamp = PhotonNetwork.time;

        createProjectile(positionSpawn, rotation, timeStamp, projectileName, projectileForce, team);
    }

    public void createProjectile(Vector3 positionSpawn, Quaternion rotation, double timeStamp, string projectileName, float projectileForce, int team)
    {
        GameObject newProjectile = Instantiate(Resources.Load<GameObject>(projectileName), positionSpawn, rotation);

        //aggiungo la forza di lancio al proiettile
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);

        //assegno a quale team appartiene il proiettile
        newProjectile.GetComponent<ProjectileMovement>().setTeam(team);
    }

}
