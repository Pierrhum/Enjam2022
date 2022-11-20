using System;
using System.Collections;
using UnityEngine;

public class WaitingState : BaseState
{
    private Vector3 InitialScale;
    private Coroutine Interrogation;
    public WaitingState(Witch witch) : base(witch)
    {
        InitialScale = witch.InterrogationSprite.transform.localScale;
    }

    public override Type Tick()
    {
        _witch.Animator.SetBool("isBooking", false);
        _witch.Animator.SetBool("Back", false);
        _witch.Books.SetActive(false);
        if (_witch.CurrentZone != null)
        {
            //_witch.StopCoroutine(Interrogation);
            //Interrogation = null;
            
            switch (_witch.CurrentZone.Type)
            {
                case ZoneType.FIRE:
                    return typeof(FireState);
                case ZoneType.REST:
                    return typeof(RestState);
                case ZoneType.ANIMALS:
                    return typeof(AnimalsState);
                case ZoneType.TRAINING:
                    return typeof(TrainingState);
                case ZoneType.ZAWN:
                    return typeof(SpawnState);
            }
        }
        //if(Interrogation==null)
         //   Interrogation = _witch.StartCoroutine(InterrogationCoroutine());
        return null;
    }

    private IEnumerator InterrogationCoroutine()
    {
        while (_witch.CurrentZone == null)
        {
            //Reset
            _witch.InterrogationSprite.transform.localScale = InitialScale;
            
            // Bigger Scale Effect
            while (_witch.InterrogationSprite.transform.localScale.x < InitialScale.x + 0.01)
            {
                _witch.InterrogationSprite.transform.localScale +=
                    new Vector3(Time.deltaTime / 10, Time.deltaTime / 10, 0);
                yield return Time.deltaTime;
            }
            
            // Rotate Effect
            while (_witch.InterrogationSprite.transform.localRotation.eulerAngles.x < 15)
            {
                _witch.InterrogationSprite.transform.eulerAngles +=
                    new Vector3(Time.deltaTime / 10, 0, 0);
                yield return Time.deltaTime;
            }
            while (_witch.InterrogationSprite.transform.localRotation.eulerAngles.x > -15)
            {
                _witch.InterrogationSprite.transform.eulerAngles +=
                    new Vector3(-Time.deltaTime / 10, 0, 0);
                yield return Time.deltaTime;
            }
            while (_witch.InterrogationSprite.transform.localRotation.eulerAngles.x < 0)
            {
                _witch.InterrogationSprite.transform.eulerAngles +=
                    new Vector3(Time.deltaTime / 10, 0, 0);
                yield return Time.deltaTime;
            }
            _witch.InterrogationSprite.transform.eulerAngles = Vector3.zero;
            
            // Smaller Scale Effect
            while (_witch.InterrogationSprite.transform.localScale.x > InitialScale.x)
            {
                _witch.InterrogationSprite.transform.localScale +=
                    new Vector3(-Time.deltaTime / 10, -Time.deltaTime / 10, 0);
                yield return Time.deltaTime;
            }
        }
    }
}
