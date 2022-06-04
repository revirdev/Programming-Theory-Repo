using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TopScorerText;
    public TMP_InputField nameInputField;

    public string nameStored;

    public static GameManager GM;


    private void Update()
    {
        
    }

    private void Start()
    {
        LoadName();
        SetTopScorerText();
    }
    private void Awake()
    {
        
        if (GM != null)
        {
            Destroy(gameObject);
            return;
        }

        GM = this;
        DontDestroyOnLoad(GM);
       
        
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string nameStored;
    }

    public void SaveName()
    {
        SavePlayerData data = new SavePlayerData();
        data.nameStored = nameStored;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/cfg.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/cfg.json";
        if (File.Exists(path))
        {
            Debug.Log("read");
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            nameStored = data.nameStored;
        }
    }

    public void GetPlayerNameFromInput()
    {
        nameStored = nameInputField.text; 
    }

    public void SetTopScorerText()
    {
        TopScorerText.text = "Top score survivor: " + nameStored;
    }
}
