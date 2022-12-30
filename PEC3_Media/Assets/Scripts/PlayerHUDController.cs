using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUDController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text nameText;

    public void SetMaxHealthValue(float value)
    {
        slider.maxValue = value;
    }

    public void SetHealthBarValue(float value)
    {
        slider.value = value;
    }

    public void SetPlayerName(string name)
    {
        nameText.text = name;
    }
}
