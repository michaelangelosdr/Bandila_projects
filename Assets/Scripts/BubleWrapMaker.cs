using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
//using UnityEngine.Monetization;

public class BubleWrapMaker : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] PopScript prefab;

    [SerializeField] List<PopScript> bubbles;
    [SerializeField] GameConfig config;
    [SerializeField] Text TapCounter = null;

    int tapCount = 0;

    private string gameID = "3858979";
    private string placementId = "testAdd";

    [SerializeField] public bool isTestMode = false;

    private void Start()
    {
        bool isPadded = false;
        float padding = 0;
        bubbles = new List<PopScript>();
        for (int y = 0; y < config.yValue; y++)
        {
            isPadded = !isPadded;
            if (isPadded)
            {
                padding = 0.435f;
            }
            else
            {
                padding = 0;
            }
            for (int x = 0; x < config.xValue; x++)
            {
                var buble = Instantiate(prefab, new Vector3(((x+padding)*config.xSpaceMultiplier), 
                    y * config.ySpaceMultiplier, 
                    0), Quaternion.identity);
                buble.Init(this);
                LeanTween.rotateZ(buble.gameObject, Random.Range(0, 360), 0);
                bubbles.Add(buble);
            }
        }

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, isTestMode);
       
    }

    private void Update()
    {
        foreach(PopScript p in bubbles)
        {
            p.Refresh();
        }
    }

    public void ResetMe()
    {
        foreach(PopScript p in bubbles)
        {
            p.ResetBubble();
        }
    }

    public void AddPoint()
    {
        tapCount++;
        TapCounter.text = tapCount.ToString();

    }

    public void WatchSumAdz()
    {

        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("NO BRO");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            Debug.Log("YOU HAVE FINISHED AN ADD");
            ResetMe();
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    
}
