using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Brick Data", menuName = "GameData/Create/Brick Data")]
public class BrickData : ScriptableObject
{
    public int hp;
    public GameObject prefab;
    public List<Sprite> sprites;
    public Color BaseColor;
    public int Score;
}
