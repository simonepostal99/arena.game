using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUnit : MonoBehaviour
{
    [SerializeField] int team;
    [SerializeField] UnitType unitType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnChoosePlayer()
    {
        //Spawniamo il player giusto in base al bottono che l'utente ha premuto, scegliendo tra il tipo di unità e la squadra
        if (team == 1) //team destra
        {
            switch (unitType)
            {
                case UnitType.archer:
                    PhotonNetwork.Instantiate("RightArcher", GameManager.instance.getSpawnRightArcher().transform.position, Quaternion.identity, 0);
                    break;

                case UnitType.witch:
                    PhotonNetwork.Instantiate("RightWitch", GameManager.instance.getSpawnRightWitch().transform.position, Quaternion.identity, 0);
                    break;

                case UnitType.gladiator:
                    PhotonNetwork.Instantiate("RightGladiator", GameManager.instance.getSpawnRightGladiator().transform.position, Quaternion.identity, 0);
                    break;
            }
        }
        else if (team == 2) //team sinistra
        {
            switch (unitType)
            {
                case UnitType.archer:
                    PhotonNetwork.Instantiate("LeftArcher", GameManager.instance.getSpawnLeftArcher().transform.position, Quaternion.identity, 0);
                    break;

                case UnitType.witch:
                    PhotonNetwork.Instantiate("LeftWitch", GameManager.instance.getSpawnLeftWitch().transform.position, Quaternion.identity, 0);
                    break;

                case UnitType.gladiator:
                    PhotonNetwork.Instantiate("LeftGladiator", GameManager.instance.getSpawnLeftGladiator().transform.position, Quaternion.identity, 0);
                    break;
            }
        }

        //Disattiviamo l'interfaccia grafica del menù di scelta dei personaggi
        GameManager.instance.getCanvas_MenuJoinMatch().SetActive(false);
        //Disattiviamo la camera che si vede nel menù gui di scelta dei personaggi
        GameManager.instance.getGUICamera().SetActive(false);
    }
}
