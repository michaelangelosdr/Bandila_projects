using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
   [SerializeField] private bool isTesting = false;

    [SerializeField] private TestTool test = null;
    [SerializeField] private BubleWrapMaker GM = null;
    
    private void Start()
    {       
     test.gameObject.SetActive(isTesting);    
    }

    public void ResetWrap()
    {
        GM.ResetMe();
    }

}
