using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{
    public Image blackPanel;
    private void Start()
    {
        blackPanel.canvasRenderer.SetAlpha(0.0f);
    }

    public void FadeIn()
    {
        blackPanel.CrossFadeAlpha(1, 1, false);
        Debug.Log("FadeIn");
    }

    public void FadeOut()
    {
        blackPanel.CrossFadeAlpha(0, 1, false);
        Debug.Log("FadeOut");
    }
}
