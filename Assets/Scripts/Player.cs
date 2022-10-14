using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _moving;
    private float _turnDirection;
    private Rigidbody2D _rb;
    public float _moveSpeed;
    public float _turnSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _turnDirection = 0.0f;
            _rb.AddForce(this.transform.up / this._moveSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (_moving)
        {
            _rb.AddForce(this.transform.up * this._moveSpeed);
        }

        if(_turnDirection != 0.0f)
        {
            _rb.AddTorque(_turnDirection * _turnSpeed);
        }

    }
}
