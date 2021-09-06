using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public int targetFrame;
    public GameObject dropdown;
    public List<int> frameRates;
    public Resolution[] resolutions;
    public Dropdown resolution;
    private void Start()
    {
        frameRates.Add(30);
        frameRates.Add(60);
        frameRates.Add(120);
        //sets up the resolution options
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }
    //function that allows for game resolution to be changed
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void LimitFramerate(int target)
    {
        Application.targetFrameRate = frameRates[target];
        //Application.targetFrameRate = -1;
        Debug.Log(target);
        Debug.Log(frameRates[target]);
    }

    void vSyncCount() 
    {
        QualitySettings.vSyncCount = 0;//if you want to use targetframerate set vsync to 0
    }
}
