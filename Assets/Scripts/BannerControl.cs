using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerControl : MonoBehaviour
{
    public GameObject bannerCanvas;
    public Button skipButton;

    // Start is called before the first frame update
    void Start()
    {
        skipButton.onClick.AddListener(SkipButtonClicked);
    }

    
    private void SkipButtonClicked()
    {
        bannerCanvas.SetActive(false);
    }
}
