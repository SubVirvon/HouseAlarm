using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        float direction = 0;

        if(Input.GetKey(KeyCode.D))
            direction = 1;
        else if(Input.GetKey(KeyCode.A))
            direction = -1;

        transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
    }
}
