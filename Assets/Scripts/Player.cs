using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI survivalText;
    public string playerName;
    [SerializeField] TextMeshProUGUI TopText;

    [SerializeField] AudioClip clickySound;
    [SerializeField] AudioSource audioSource;

    public void SavePlayer()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        SaveSystem.SavePlayer(this);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadPlayer();
        LoadPlayerMenu();
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        playerName = data.PlayerName;

        survivalText.text = playerName;
    }

    public void LoadPlayerMenu()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerName = data.PlayerName;

        TopText.text = "Last survivor: " + playerName;
    }
    public void Update()
    {
        playerName = survivalText.text;
    }
}
