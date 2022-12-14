using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIEffects;
using TMPro;

namespace Utils {
    public static class UI
    {
        #region Basic Unity Effects
        public class CoroutineWrapper : MonoBehaviour { }

        public static void SetImageOpacity(Image image, float a)
        {
            Color c = image.color;
            image.color = new Color(c.r, c.g, c.b, a);
        }
        public static IEnumerator Fade(List<Image> images, float start, float end, float duration, AudioSource source=null)
        {
            float timer = 0f;
            AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });

            while (timer <= duration)
            {
                timer += Time.deltaTime;
                foreach(Image img in images)
                {
                    Color c = img.color;
                    img.color = new Color(c.r, c.g, c.b, Mathf.Lerp(start, end, smoothCurve.Evaluate(timer / duration)));
                    if (source != null)
                        source.volume = Mathf.Lerp(start > end ? 0 : 1, start > end ? 1 : 0, smoothCurve.Evaluate(timer / duration));
                }
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        public static IEnumerator Fade(List<Image> images, List<TextMeshProUGUI> texts, float start, float end, float duration)
        {
            float timer = 0f;
            AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });

            while (timer <= duration)
            {
                timer += Time.deltaTime;
                foreach (Image img in images)
                {
                    Color c = img.color;
                    img.color = new Color(c.r, c.g, c.b, Mathf.Lerp(start, end, smoothCurve.Evaluate(timer / duration)));
                }
                foreach(TextMeshProUGUI txt in texts)
                {
                    Color c = txt.color;
                    txt.color = new Color(c.r, c.g, c.b, Mathf.Lerp(start, end, smoothCurve.Evaluate(timer / duration)));
                }
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        #endregion

        #region UiEffect Tool

        public static IEnumerator Dissolve(UIDissolve dissolve, float start, float end, float duration)
        {
            float timer = 0f;
            AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });

            while (timer <= duration)
            {
                timer += Time.deltaTime;
                dissolve.effectFactor = Mathf.Lerp(start, end, smoothCurve.Evaluate(timer / duration));
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        public static IEnumerator UIShinyBrightnessAnim(UIShiny shiny, float startBrightness, float endBrightness, float duration)
        {
            float timer = 0f;
            AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });
            while (timer <= duration)
            {
                timer += Time.deltaTime;
                shiny.brightness = Mathf.Lerp(startBrightness, endBrightness, smoothCurve.Evaluate(timer / duration));
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        
        public static IEnumerator UIEffectAnim(UIEffect effect, float startFactor, float endFactor, float duration)
        {
            float timer = 0f;
            AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });
            while (timer <= duration)
            {
                timer += Time.deltaTime;
                effect.effectFactor = Mathf.Lerp(startFactor, endFactor, smoothCurve.Evaluate(timer / duration));
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        #endregion
    }
};