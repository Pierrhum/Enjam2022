using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image Overlay;
    public TextMeshProUGUI AnimalCPT;

    public IEnumerator Fade(bool In)
    {
        if (In)
        {
            yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Overlay}, Overlay.color.a,0f,2f));
            Overlay.enabled = false;
        }
        else
        {
            Overlay.enabled = true;
            yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Overlay}, Overlay.color.a,1f,2f));
        }
    }
    public void SetAnimalText(string Text)
    {
        AnimalCPT.text = Text;
    }
}
