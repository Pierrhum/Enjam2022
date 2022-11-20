using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public void Activate()
    {
        StartCoroutine(MovementCoroutine(2f));
    }

    private IEnumerator MovementCoroutine(float duration)
    {
        Vector3 initPos = transform.position;
        float timer = 0f;
        AnimationCurve smoothCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(1f, 1f) });

        float random = Random.Range(-5, 5);
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(Mathf.Lerp(initPos.x, initPos.x + random, smoothCurve.Evaluate(timer / duration)),
                Mathf.Lerp(initPos.y, initPos.y - 15, smoothCurve.Evaluate(timer / duration)));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
