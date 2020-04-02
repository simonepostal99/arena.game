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
        
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();
    }

    private void checkDistance()
    {
        distance = Mathf.Abs(lane.transform.position.y - transform.position.y);

        if(distance > distanceFall)
        {
            Vector3 v3 = new Vector3(lane.transform.position.x, lane.transform.position.y + 10, lane.transform.position.z);
            transform.position = v3;

            StartCoroutine(zeroGravity());
        }
    }


    private IEnumerator zeroGravity()
    {
        body.isKinematic = true;
        yield return new WaitForSeconds(1.5f);
        body.isKinematic = false;
    }
}
