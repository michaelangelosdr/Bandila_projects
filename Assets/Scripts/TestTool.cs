using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTool : MonoBehaviour
{
    [SerializeField] GameConfig ga;
    public void ChangePopSpeed(bool isIncrease)
    {
        if (isIncrease)
        {
            ga.popSpeedMultiplier += 5;
        }
        else
        {
            ga.popSpeedMultiplier -= 5;
        }
    }
    

}
