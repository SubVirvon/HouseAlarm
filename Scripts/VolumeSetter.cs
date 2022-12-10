using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _changeStep;

    private float _volume;
    private AudioSource _source;
    private bool _isCharacterInside;
    private Coroutine _changeVolume;
    private bool _isCoroutinStart = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Set(bool isCharacterInside)
    {
        _isCharacterInside = isCharacterInside;
        
        if(_isCoroutinStart == false)
            _changeVolume = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        var waitForStep = new WaitForSeconds(_changeStep * _duration);
        bool isFinish = false;

        _isCoroutinStart = true;

        if (_volume <= 0)
            _source.Play();

        while(isFinish == false)
        {
            if (_isCharacterInside)
                _volume += _changeStep;
            else
                _volume -= _changeStep;

            _source.volume = _volume;

            if (_volume >= 1)
            {
                StopCoroutine(_changeVolume);
            }
            else if(_volume <= 0)
            {
                StopCoroutine(_changeVolume);
                _source.Stop();
            }

            yield return waitForStep;
        }
    }

    private void StopCoroutine(int coroutineName)
    {
        _isCoroutinStart = false;
        StopCoroutine(coroutineName);
    }
}
