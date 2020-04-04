using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] float backMovement;
    [SerializeField] float upMovement;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void knockback(Vector3 fw)
    {
        fw.y = fw.y + upMovement;
        body.AddForce(fw * backMovement, ForceMode.Impulse);
    }
}
