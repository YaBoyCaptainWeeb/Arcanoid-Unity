using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [SerializeField] private PlayerMove player;
    [SerializeField] private float BallSpeed;
    [SerializeField] private FalloutZone BallZone;

    private float _offsetX = 0;
    private float _originalPositionY;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _originalPositionY = transform.position.y;

        player.SpacePressed += StartingForce;
        player.PlayerMoved += Follow;
        BallZone.BallOut += Reset;
    }

    private void StartingForce()
    {
       if (Math.Abs(player.GetComponent<Rigidbody2D>().velocity.x) > 1)
            _offsetX = player.GetComponent<Rigidbody2D>().velocity.x < 0 ? -BallSpeed : BallSpeed;

        _rigidBody2D.AddForce(new Vector2(_offsetX * 10, BallSpeed * 8));
        player.SpacePressed -= StartingForce;
        player.PlayerMoved -= Follow;

        _offsetX = 0;
    }

    private void Follow()
    {
        transform.position = new Vector2(player.transform.position.x,transform.position.y);
    }
    
    private void Reset()
    {
        _rigidBody2D.position = Vector2.zero;
        _rigidBody2D.velocity = Vector2.zero;

        transform.position = new Vector2(player.transform.position.x,_originalPositionY);
        player.PlayerMoved += Follow;
        player.SpacePressed += StartingForce;

    }
}
