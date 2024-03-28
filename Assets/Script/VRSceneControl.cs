using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRSceneControl : MonoBehaviour
{
    public string targetSceneName;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            EnableVR();
        }
        else
        {
            DisableVR();
        }
    }

    private void EnableVR()
    {
        XRDisplaySubsystem display = XRSubsystemHelper.GetDisplaySubsystem();
        if (display != null && !display.running)
        {
            display.Start();
        }
    }

    private void DisableVR()
    {
        XRDisplaySubsystem display = XRSubsystemHelper.GetDisplaySubsystem();
        if (display != null && display.running)
        {
            display.Stop();
        }
    }
}

public static class XRSubsystemHelper
{
    private static List<XRDisplaySubsystem> displayList = new List<XRDisplaySubsystem>();

    public static XRDisplaySubsystem GetDisplaySubsystem()
    {
        XRDisplaySubsystem display = null;
        SubsystemManager.GetInstances(displayList);
        if (displayList.Count > 0)
        {
            display = displayList[0];
        }
        return display;
    }
}