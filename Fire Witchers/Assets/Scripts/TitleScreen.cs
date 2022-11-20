using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public AudioSource Music;
    public GameObject Title;
    public GameObject HowToPLay;
    public TextMeshProUGUI Advice;
    public Image Fade;
    public Image Background;
    public Image TreesBackground;
    public Image TreesForeground;
    private bool FadingOut = false;
    private int Step = 0;

    private Coroutine FadeCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        FadeCoroutine = StartCoroutine(Utils.UI.Fade(new List<Image>{Fade}, 1f,0f,5f));
        AnimateTrees();
        StartCoroutine(AdviceCoroutine(1f));
    }

    private void AnimateTrees()
    {
        StartCoroutine(TreesBackgroundCoroutine());
        StartCoroutine(TreesForegroundCoroutine());
    }

    private IEnumerator AdviceCoroutine(float duration)
    {
        AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });
        float alpha = 0f;
        float timer = 0f;
        bool In = true;
        while (!FadingOut)
        {
            alpha = In ? Mathf.Lerp(0f, 1f, smoothCurve.Evaluate(timer / duration)) : Mathf.Lerp(1f, 0f, smoothCurve.Evaluate(timer / duration));
            Advice.color = new Color(Advice.color.r, Advice.color.g, Advice.color.b, alpha);

            if (alpha >= 1f || alpha <= 0f)
            {
                In = !In;
                timer = 0f;
            }
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return null;
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
            yield return StartCoroutine(Utils.UI.UIEffectAnim(TreesForeground.gameObject.GetComponent<UIEffect>(), 0.5f,0.8f, 5f));
            yield return StartCoroutine(Utils.UI.UIEffectAnim(TreesForeground.gameObject.GetComponent<UIEffect>(), 0.8f,0.5f, 5f));
        }
    }

    private void Update()
    {
        if (!FadingOut && Input.GetKeyDown(KeyCode.Space))
        {
            if(Step==0)
                StartCoroutine(HowToPlayTransiton());
            else
                StartCoroutine(LoadLevelTransition());

            Step++;
        }
    }

    private IEnumerator HowToPlayTransiton()
    {
        FadingOut = true;
        StopCoroutine(FadeCoroutine);
        yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Fade}, Fade.color.a,1f,2f));
        Title.SetActive(false);
        HowToPLay.SetActive(true);
        yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Fade}, 1f,0f,1f));
        FadingOut = false;
        AnimateTrees();
        StartCoroutine(AdviceCoroutine(1f));
    }

    private IEnumerator LoadLevelTransition()
    {
        FadingOut = true;
        yield return StartCoroutine(Utils.UI.Fade(new List<Image>{Fade}, Fade.color.a,1f,2f, Music));
        SceneManager.LoadScene("MainLevel");
    }
}
