using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class TurboZmeyaManager : NetworkManager
{
    [SerializeField] GameObject PoopEdaPrefaba;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2)
        {
            return;
        }
        GameObject FoodSpownerInstэnce = Instantiate(PoopEdaPrefaba);
        NetworkServer.Spawn(FoodSpownerInstэnce);
    }
}
