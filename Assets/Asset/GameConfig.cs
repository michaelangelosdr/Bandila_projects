using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "config", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] public float maxSize = 1.15f;
    [SerializeField] public float minSize = 1.0f;
    [SerializeField] public float popSpeedMultiplier = 10f;

    [SerializeField] public float xSpaceMultiplier = 1;
    [SerializeField] public float ySpaceMultiplier = 1;

    [SerializeField] public float xValue = 10;
   [SerializeField] public float yValue = 9;

}
