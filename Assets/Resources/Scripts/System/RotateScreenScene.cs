using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScreenScene : MonoBehaviour
{
    public enum ScreenType 
    {
        Portrait,
        PortraitUpsideDown,
        LandscapeLeft,
        LandscapeRight
    }
    public ScreenType screenType;
    // Start is called before the first frame update
    void Start()
    {
        SetScreenType();
    }

    /// <summary>
    /// スクリーン
    /// </summary>
    void SetScreenType() 
    {
        switch (screenType)
        {
            case ScreenType.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case ScreenType.PortraitUpsideDown:
                Screen.orientation = ScreenOrientation.PortraitUpsideDown;
                break;
            case ScreenType.LandscapeLeft:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
            case ScreenType.LandscapeRight:
                Screen.orientation = ScreenOrientation.LandscapeRight;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
