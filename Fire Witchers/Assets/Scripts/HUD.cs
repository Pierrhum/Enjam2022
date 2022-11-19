using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image FireBarFill;

    public TextMeshProUGUI AnimalCPT;
    public void SetFireFillBarAmount(float amount)
    {
        FireBarFill.fillAmount = amount;
    }

    public void SetAnimalText(string Text)
    {
        AnimalCPT.text = Text;
    }
}
