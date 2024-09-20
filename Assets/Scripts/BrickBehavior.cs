using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BrickBehavior : MonoBehaviour
{
    [HideInInspector] public int _hp;
    private int _score;
    private SpriteRenderer _spriteRenderer;
    private List<Sprite> _sprites;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            StartCoroutine(ReceiveDamage());
        }
    }
    public void SetData(BrickData brickData)
    {
        _sprites = new List<Sprite>(brickData.sprites);
        _score = brickData.Score;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = brickData.BaseColor;
        _hp = brickData.hp;
        _spriteRenderer.sprite = _sprites[0];
        MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = brickData.BaseColor;
    }

    IEnumerator ReceiveDamage()
    {
        _hp--;
        if (_hp < 1)
        {
            GetComponent<ParticleSystem>().Play();
            yield return new WaitForSecondsRealtime(0.5f);
            Destroy(gameObject);
        } else if (_hp == 1)
        {
            _spriteRenderer.sprite = _sprites[_hp];
        }
    }
}
