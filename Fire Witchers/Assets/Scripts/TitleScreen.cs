using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public Image Background;
    public Image TreesBackground;
    public Image TreesForeground;
    private bool FadingOut = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TreesBackgroundCoroutine());
        StartCoroutine(TreesForegroundCoroutine());
    }

    private IEnumerator TreesBackgroundCoroutine()
    {
        while (!FadingOut)
        {
            yield return StartCoroutine(Utils.UI.UIShinyBrightnessAnim(TreesBackground.gameObject.GetComponent<UIShiny>(), 0f,0.4f, 1f));
            yield return StartCoroutine(Utils.UI.UIShinyBrightnessAnim(TreesBackground.gameObject.GetComponent<UIShiny>(), 0.4f,0f, 1f));
        }
    }
    
    private IEnumerator TreesForegroundCoroutine()
    {
        while (!FadingOut)
        {
            yield return StartCoroutine(Utils.UI.UIEffectAnim(TreesForeground.gameObject.GetComponent<UIEffect>(), 0f,0.6f, 5f));
            yield return StartCoroutine(Utils.UI.UIEffectAnim(TreesForeground.gameObject.GetComponent<UIEffect>(), 0.6f,0f, 5f));
        }
    }
}
