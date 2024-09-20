using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class FalloutZone : MonoBehaviour
{
    public event Action BallOut;

    private void OnTriggerExit2D(Collider2D collision)
    {
        BallOut?.Invoke();
    }
}
