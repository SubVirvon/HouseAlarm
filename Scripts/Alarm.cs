using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _source;
    private Coroutine _changeVolume;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void SetVolume(bool isCharacterInside)
    {
        float targetVolume;

        if (isCharacterInside)
            targetVolume = 1;
        else
            targetVolume = 0;
            
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);

        _changeVolume = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        if (_source.volume == 0)
            _source.Play();

        while (_source.volume != targetVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, Time.deltaTime / _duration);

            yield return null;
        }

        if (_source.volume == 0)
            _source.Stop();
    }
}
