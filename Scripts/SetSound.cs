using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SetSound : MonoBehaviour
{
    [SerializeField] private float _durationSpeed;

    private float _volume;
    private AudioSource _source;
    private bool _isCharacterInside;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Set(bool isCharacterInside)
    {
        _isCharacterInside = isCharacterInside;

        if(isCharacterInside == true)
            _source.Play();
    }

    private void Update()
    { 
        if (_isCharacterInside)
        {
            if (_volume < 1)
                _volume += _durationSpeed * Time.deltaTime;
        }
        else
        {
            if (_volume > 0)
                _volume -= _durationSpeed * Time.deltaTime;
            else if (_volume <= 0)
                _source.Stop();
        }

        _source.volume = _volume;
    }
}
