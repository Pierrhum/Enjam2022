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
            Overlay.gameObject.SetActive(true);
            yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Overlay}, Overlay.color.a,0f,2f, GameManager.Instance.Music));
            Overlay.gameObject.SetActive(false);
        }
        else
        {
            Overlay.gameObject.SetActive(true);
            yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Overlay}, Overlay.color.a,1f,2f, GameManager.Instance.Music));
        }
    }
    public void SetAnimalText(string Text)
    {
        AnimalCPT.text = Text;
    }
}
