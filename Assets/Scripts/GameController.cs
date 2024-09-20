using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<BrickData> bricks;
    [SerializeField, Tooltip("Кол-во строчек с блоками")] private int NumberOfLines;
    private float _offsetX = 0, _offsetY = 0;


    private void Start()
    {
        for (int i = 0; i < NumberOfLines; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject game = Instantiate(bricks[i].prefab, new Vector3(bricks[i].prefab.transform.position.x + _offsetX,
                    bricks[i].prefab.transform.position.y + _offsetY, 0), Quaternion.identity);

                _offsetX += 1.50f;

                if (game.TryGetComponent(out BrickBehavior brick))
                {
                    brick.SetData(bricks[i]);
                }
            }
            _offsetX = 0;
            _offsetY += 0.31f;
        }
    }
}
