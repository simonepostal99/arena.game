using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [PunRPC]
    public void onShoot(Vector3 positionSpawn, Quaternion rotation, GameObject projectile, float projectileForce, int unit)
    {
        double timeStamp = PhotonNetwork.time;

        createProjectile(positionSpawn, rotation, timeStamp, projectile, projectileForce, unit);
    }

    public void createProjectile(Vector3 positionSpawn, Quaternion rotation, double timeStamp, GameObject projectile, float projectileForce, int unit)
    {
        GameObject projectil = Instantiate(projectile, positionSpawn, rotation);

        //aggiungo la forza di lancio al proiettile
        projectil.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);

        //assegno a quale team appartiene il proiettile
        projectil.GetComponent<ProjectileMovement>().setTeam(unit);
    }

}
