using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI AnimalCPT;

    public void SetAnimalText(string Text)
    {
        AnimalCPT.text = Text;
    }
}
