using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    [SerializeField, Tooltip("Выбираемая ширина, по умолчанию = размер экрана")] public float SizeX;
    [SerializeField, Tooltip("Выбираемая высота, по умолчанию = размер экрана")] public float SizeY;
    private float _targetSizeX = 0f;
    private float _targetSizeY = 0f;
    private const float _halfSize = 200f;

    [SerializeField] private bool IsHorizontal = false;

    private void Awake()
    { 
        _targetSizeX = IsHorizontal ? SizeY : SizeX;
        _targetSizeY = IsHorizontal ? SizeX : SizeY;
        SizeX = Screen.currentResolution.width;
        SizeY = Screen.currentResolution.height;

        ScaleCamera();
    }

    private void ScaleCamera()
    {
        float screenRatio = (float)(Screen.width / Screen.height);
        float targetRatio = _targetSizeX / _targetSizeY;

        if (screenRatio >= targetRatio)
        {
            Resize();
        } else
        {
            float difference = targetRatio / screenRatio;
            Resize(difference);
        }
    }

    private void Resize(float diffrenece = 1.0f)
    {
        Camera.main.orthographicSize = _targetSizeY / _halfSize * diffrenece;
    }
}
