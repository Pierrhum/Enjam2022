using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image FireBarFill;

    public void SetFireFillBarAmount(float amount)
    {
        FireBarFill.fillAmount = amount;
    }
}
