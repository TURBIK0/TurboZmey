using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;

    public static event Action SeverOnFoodaEst;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindObjectOfType<Snake>().AddTail();
        GameObject boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        Destroy(boom, 3f);
        NetworkServer.Destroy(gameObject);
        SeverOnFoodaEst?.Invoke();
    }
}