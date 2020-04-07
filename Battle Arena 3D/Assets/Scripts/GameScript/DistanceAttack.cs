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
    [SerializeField] PhotonView PhotonView;

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

            int team = unit.getTeam();

            //spawno il proiettile
            PhotonView.RPC("onShoot", PhotonTargets.All, new object[] { positionSpawn.transform.position, Quaternion.identity, projectilePrefab, projectileForce, team });

            //PhotonNetwork.Destroy(projectile);

            //azzero la forza di lancio
            attackButtonPressedTime = 0;
            projectileForce = 0;


            //Riporto lo zoom allo stato originale
            camera.fieldOfView = maxCameraFieldOfView;
        }

        
    }

}
