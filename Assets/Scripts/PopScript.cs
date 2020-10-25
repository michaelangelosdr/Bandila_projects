using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopScript : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] Sprite Unpopped;
    [SerializeField] Sprite Popped;
    [SerializeField] AudioClip clip;
    [SerializeField] GameConfig config;
    
    bool isPopped = false;
    bool isTapped = false;

    BubleWrapMaker gm;

    public void Init( BubleWrapMaker gm)
    {
        isPopped = false;
        isTapped = false;
        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = Unpopped;
        this.gm = gm;
    }
    private void OnMouseDown()
    {
        isTapped = true;
      //  if (isPopped) return;
      //  transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);

        //StartCoroutine(pop());

        /* if (isPopped) return;

        
         Debug.Log("pop");
         if (audioSource == null) return;
         audioSource.Play();
         GetComponent<SpriteRenderer>().sprite = Popped;
         isPopped = true;
         transform.localScale = new Vector3(1, 1, 1);*/
    }
    private void OnMouseUp()
    {
        isTapped = false;
      //  if (isPopped) return;

      //  Debug.Log("pop");
       // if (audioSource == null) return;
       // audioSource.Play();
       // GetComponent<SpriteRenderer>().sprite = Popped;
       /// isPopped = true;
       // transform.localScale = new Vector3(1, 1, 1);
       // Handheld.Vibrate();
    }

    IEnumerator pop()
    {
        if (isPopped) yield break;

        yield return new WaitForSeconds(0.25f);
        if (isPopped) yield break;

        LeanTween.scale(this.gameObject, new Vector3(1, 1, 1),0.25f);

        audioSource.Play();
        GetComponent<SpriteRenderer>().sprite = Popped;
        isPopped = true;
        transform.localScale = new Vector3(1, 1, 1);
        Handheld.Vibrate();
        yield return null;
    }

    public void Refresh()
    {
        if(transform.localScale.y >=config.maxSize && isPopped == false)
        {
            gm.AddPoint();
            audioSource.Play();
            GetComponent<SpriteRenderer>().sprite = Popped; 
            transform.localScale = new Vector3(1, 1, 1);
           // Handheld.Vibrate();
          
            isPopped = true;
        }
        else if(isPopped ==false)
        {

            if (isTapped)
            {
                Debug.Log("On");
                if (transform.localScale.y <= config.maxSize && transform.localScale.x <= config.maxSize)
                {
                    Debug.Log("Expand");
                    transform.localScale += new Vector3(0.05f, 0.05f, 0.05f) * Time.deltaTime * config.popSpeedMultiplier;
                }

            }
            else
            {
                Debug.Log("Off");
                if (transform.localScale.y > config.minSize && transform.localScale.x > config.minSize)
                {
                    transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f) * Time.deltaTime * config.popSpeedMultiplier;
                }
            }

        }
    }

    public void ResetBubble()
    {
        isPopped = false;
        audioSource = GameObject.Find("AS").GetComponent<AudioSource>();
        isTapped = false;
        transform.localScale = new Vector3(config.minSize, config.minSize, 1);
        GetComponent<SpriteRenderer>().sprite = Unpopped;
    }


}
