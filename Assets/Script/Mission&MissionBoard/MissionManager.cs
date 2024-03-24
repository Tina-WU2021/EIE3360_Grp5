using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    // Singleton instance
    private static MissionManager instance;

    // List of missions
    public Dictionary<string, Mission> missionsList;

    // Current mission index
    public int currentMissionIndex;

    // Event triggered when a mission is completed
    public event Action OnMissionComplete;

    // Get the singleton instance of MissionManager
    public static MissionManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("MissionManager");
                instance = go.AddComponent<MissionManager>();
                DontDestroyOnLoad(go); // This will prevent the GameObject from being destroyed when loading a new scene
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure that only one instance of MissionManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Initialize the missions dictionary
        //The key: a short name for getting access to the dictionary
        //Mission[1]: the text that will be displayed in the game
        //Mission[2]: optional. true for optional, false for compulsory
        //Mission[3]: activated. true for activated.
        missionsList = new Dictionary<string, Mission>
        {
            {
                "Mission1",
                new Mission(
                    0,
                    "Mission 1 testing looooooooooooooong text blablablablablablablablablbla ummmmm ummmmm ummmm testing scrollable",
                    false,
                    false
                )
            },
            {
                "Mission2",
                new Mission(
                    1,
                    "in game description for mission2 testing interface activate missions text shows at the buttom",
                    true,
                    true
                )
            },
            { "Mission3", new Mission(2, "welcome to mission three", true, false) }
        };
    }

    // Activate a mission by its short name
    //To activate: MissionManager.Instance.ActivateMission("Mission2");
    public void ActivateMission(string shortName)
    {
        if (missionsList.ContainsKey(shortName))
        {
            missionsList[shortName].Activate();
        }
    }

    // Activate a mission by its short name
    //To deactivate: MissionManager.Instance.ActivateMission("Mission2");
    public void DeactivateMission(string shortName)
    {
        if (missionsList.ContainsKey(shortName))
        {
            missionsList[shortName].Deactivate();
        }
    }

    // Get a mission by its short name
    //To retrieve: MissionManager.Instance.GetMission("Mission1")
    public Mission GetMission(string shortName)
    {
        if (missionsList.ContainsKey(shortName))
        {
            return missionsList[shortName];
        }

        return null;
    }
}

// Mission class
[Serializable]
public class Mission
{
    public int missionIndex;
    public string missionDetail;
    public bool activated;
    public bool misisonIsOptional;

    public Mission(int index, string textdetail, bool optional, bool activate)
    {
        this.missionIndex = index;
        this.missionDetail = textdetail;
        this.misisonIsOptional = optional;
        this.activated = activate;
    }

    public void Activate()
    {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }
}
