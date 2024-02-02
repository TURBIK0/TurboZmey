using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        SpawnFood();
        Food.SeverOnFoodaEst += SpawnFood;
    }
    public override void OnStopServer()
    {
        Food.SeverOnFoodaEst -= SpawnFood;
    }

    [Server]
    void SpawnFood()
    {
        Vector3 pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        GameObject foodInstэnce = Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);

        NetworkServer.Spawn(foodInstэnce);
    }
}
