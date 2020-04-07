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


    /*[PunRPC]
    public void onShoot(Vector3 positionSpawn, Quaternion rotation, string projectileName, int projectileForce, int team)
    {
        double timeStamp = PhotonNetwork.time;

        createProjectile(positionSpawn, rotation, timeStamp, projectileName, projectileForce, team);
    }

    public void createProjectile(Vector3 positionSpawn, Quaternion rotation, double timeStamp, string projectileName, int projectileForce, int team)
    {
        GameObject newProjectile = Instantiate(Resources.Load<GameObject>(projectileName), positionSpawn, rotation);

        //aggiungo la forza di lancio al proiettile
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);

        //assegno a quale team appartiene il proiettile
        newProjectile.GetComponent<ProjectileMovement>().setTeam(team);
    }*/

}
