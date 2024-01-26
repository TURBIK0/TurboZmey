using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TurboName : NetworkBehaviour
{
    [SerializeField] TMP_Text turboNameText;

    [SyncVar(hook = nameof(HandlePlayerNameUpdated))]
    string turboName;
    
    void HandlePlayerNameUpdated(string oldText, string newText)
    {
        turboNameText.text = newText;
    }

    public override void OnStartServer()
    {
        turboName = $"ТУРБИК {connectionToClient.connectionId}";
    }
}
