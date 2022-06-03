using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject chooseCharacterMenu;

    public TMP_InputField enterNameField;
    public TextMeshProUGUI topScorerText;

    public MenuUIHandler MN;

    private void Awake()
    {
        if (MN != null)
        {
            Destroy(gameObject);
        }
        MN = this;
        DontDestroyOnLoad(MN);
    }
    public void PlayButtonAtMainMenu()
    {
        mainMenu.SetActive(false);
        chooseCharacterMenu.SetActive(true);
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReturnInOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ReturnInChooseCharacter()
    {
        chooseCharacterMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayInChooseCharacter()
    {
        SceneManager.LoadScene(1);
    }
}
