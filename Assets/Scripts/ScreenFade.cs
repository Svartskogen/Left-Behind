using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    RawImage image;

    readonly Color clearColor = new Color(0, 0, 0, 0);
    Color holder;
    
    void Awake()
    {
        image = GetComponent<RawImage>();
        image.color = Color.black;
    }
    private void Start()
    {
        StartCoroutine(LerpImage(clearColor));
    }

    IEnumerator LerpImage(Color target)
    {
        float timer = 0;
        while(image.color != target)
        {
            image.color = Color.Lerp(image.color, target, timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator LerpImage(Color target, float timeScale)
    {
        float timer = 0;
        while (image.color != target)
        {
            image.color = Color.Lerp(image.color, target, timer);
            timer += Time.deltaTime * timeScale;
            yield return null;
        }
    }
    IEnumerator Blink()
    {
        yield return StartCoroutine(LerpImage(Color.black));
        StartCoroutine(LerpImage(clearColor));
    }

    [ContextMenu("Blink")]
    public void BlinkGraphic()
    {
        StartCoroutine(Blink());
    }
    public void SlowHide()
    {
        StartCoroutine(LerpImage(Color.black, 0.02f));
    }
}
