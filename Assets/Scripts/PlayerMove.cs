using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 direction;
    public event Action SpacePressed, PlayerMoved;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            if (Input.GetKey(KeyCode.Space))
            {
                SpacePressed?.Invoke();
                return;
            }
        } else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
            if (Input.GetKey(KeyCode.Space))
            {
                SpacePressed?.Invoke();
                return;
            }
        }
        else
        {
            direction = Vector2.zero;
        }

        PlayerMoved?.Invoke();

        if (Input.GetKey(KeyCode.Space))
        {
            SpacePressed?.Invoke();
        }
    }
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            _rigidbody2D.AddForce(direction * Speed);
        }
    }
}
