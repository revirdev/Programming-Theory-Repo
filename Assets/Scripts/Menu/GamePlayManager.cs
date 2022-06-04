using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;

    private void Awake()
    {
        playerName.text = GameManager.GM.nameStored + "'s Survival";
    }
}
