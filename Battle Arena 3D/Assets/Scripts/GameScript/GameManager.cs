using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Spawn e Respawn Point per tutti i giocatori
    [SerializeField] GameObject spawnLeftArcher;
    [SerializeField] GameObject spawnLeftWitch;
    [SerializeField] GameObject spawnLeftGladiator;
    [SerializeField] GameObject spawnRightArcher;
    [SerializeField] GameObject spawnRightWitch;
    [SerializeField] GameObject spawnRightGladiator;

    //GUI scelta personaggio
    [SerializeField] GameObject canvas_MenuJoinMatch;

    //GUI Camera 
    [SerializeField] GameObject guiCamera;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Errore instance +1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getSpawnLeftArcher()
    {
        return spawnLeftArcher;
    }
    public GameObject getSpawnLeftWitch()
    {
        return spawnLeftWitch;
    }
    public GameObject getSpawnLeftGladiator()
    {
        return spawnLeftGladiator;
    }

    public GameObject getSpawnRightArcher()
    {
        return spawnRightArcher;
    }
    public GameObject getSpawnRightWitch()
    {
        return spawnRightWitch;
    }
    public GameObject getSpawnRightGladiator()
    {
        return spawnRightGladiator;
    }



    public GameObject getCanvas_MenuJoinMatch()
    {
        return canvas_MenuJoinMatch;
    }

    public GameObject getGUICamera()
    {
        return guiCamera;
    }
}
