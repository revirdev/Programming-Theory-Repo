using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TextMeshProUGUI qualityText;
    [SerializeField] int qualityTextIndex = 3;

    private void Update()
    {
        ChangeQuality();
        SetQuality();
    }

    public void ChangeQuality()
    {
        if (qualityTextIndex == 1)
            qualityText.text = "Low";
        else if (qualityTextIndex == 2)
            qualityText.text = "Mid";
        else if (qualityTextIndex == 3)
            qualityText.text = "High";
        else if (qualityTextIndex == 4)
            qualityTextIndex = 3;
        else if (qualityTextIndex == 0)
            qualityTextIndex = 1;
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void RightButtonQuality()
    {
        if (qualityTextIndex > 0 && qualityTextIndex < 4)
            qualityTextIndex += 1;
    }

    public void LeftButtonQuality()
    {
        if (qualityTextIndex > 0 && qualityTextIndex < 4)
            qualityTextIndex -= 1;
    }

    public void SetQuality()
    {
        if (qualityTextIndex == 1)
            QualitySettings.SetQualityLevel(0, false);
        else if (qualityTextIndex == 2)
            QualitySettings.SetQualityLevel(1, false);
        else if (qualityTextIndex == 3)
            QualitySettings.SetQualityLevel(2, false);
    }
}
