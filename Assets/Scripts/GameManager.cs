using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TopScorerText;
    public TMP_InputField nameInputText;
    public string nameStored;
    public int scoreStored;
    

    public void GetScore(int score)
    {
        scoreStored = score;
        SaveName();
        LoadName();
    }

    public static GameManager GM;

    private void Start()
    {
        Debug.Log("Run Scene");
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
        LoadName();
        SetTopScorerText();
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string nameStored;
        public int scoreStored;
    }


    public void SaveName()
    {
        Debug.Log("Saved Name");
        SavePlayerData data = new SavePlayerData();
        data.nameStored = nameStored;
        data.scoreStored = scoreStored;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/cfg.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/cfg.json";
        if (File.Exists(path))
        {
            Debug.Log("Read");
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            scoreStored = data.scoreStored;
            nameStored = data.nameStored;
        }
    }

    public void z_SetName()
    {
        Debug.Log("Worked");
        if (scoreStored > PlayerPrefs.GetInt("HighScore", 0))
        {
            nameStored = nameInputText.text;
        }
    }

    public void SetTopScorerText()
    {
        TopScorerText.text = "Top scorer: " + nameStored + "- Highest score: " + scoreStored;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
