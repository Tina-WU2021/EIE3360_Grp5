// using System;
// using System.Collections.Generic;
// using UnityEngine;

// public class MissionManager : MonoBehaviour
// {
//     // Singleton instance
//     private static MissionManager instance;

//     // List of missions
//     public List<Mission> missions;

//     // Current mission index
//     public int currentMissionIndex;

//     // Event triggered when a mission is completed
//     public event Action OnMissionComplete;

//     // Get the singleton instance of MissionManager
//     public static MissionManager Instance
//     {
//         get
//         {
//             if (instance == null)
//             {
//                 GameObject go = new GameObject("MissionManager");
//                 instance = go.AddComponent<MissionManager>();
//                 DontDestroyOnLoad(go); // This will prevent the GameObject from being destroyed when loading a new scene
//             }
//             return instance;
//         }
//     }

//     private void Awake()
//     {
//         // Ensure that only one instance of MissionManager exists
//         if (instance != null && instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         instance = this;
//         DontDestroyOnLoad(gameObject);
//     }

//     private void Start()
//     {
//         // Initialize the missions list
//         missions = new List<Mission>
//         {
//             // Add your missions to the list in the desired order
//             // Set the optional parameter as needed
//             new Mission("Mission 1", false, OnMission1Complete),
//             new Mission("Mission 2", true, OnMission2Complete),
//             new Mission("Mission 3", true, OnMission3Complete)
//         };

//         // Load the saved progress, if any
//         currentMissionIndex = PlayerPrefs.GetInt("CurrentMissionIndex", 0);

//         // Start the current mission
//         StartCurrentMission();
//     }

//     // Start the current mission
//     private void StartCurrentMission()
//     {
//         if (currentMissionIndex < missions.Count)
//         {
//             Mission currentMission = missions[currentMissionIndex];
//             currentMission.Activate();
//         }
//         else
//         {
//             // All missions completed
//             Debug.Log("All missions completed!");
//         }
//     }

//     // Callback for mission 1 completion
//     private void OnMission1Complete()
//     {
//         Debug.Log("Mission 1 complete!");
//         // Trigger actions or events for mission 1 completion

//         // Move to the next mission
//         GoToNextMission();
//     }

//     // Callback for mission 2 completion
//     private void OnMission2Complete()
//     {
//         Debug.Log("Mission 2 complete!");
//         // Trigger actions or events for mission 2 completion

//         // Move to the next mission
//         GoToNextMission();
//     }

//     // Callback for mission 3 completion
//     private void OnMission3Complete()
//     {
//         Debug.Log("Mission 3 complete!");
//         // Trigger actions or events for mission 3 completion

//         // Move to the next mission
//         GoToNextMission();
//     }

//     // Move to the next mission
//     public void GoToNextMission()
//     {
//         currentMissionIndex++;

//         // Save the current mission index
//         PlayerPrefs.SetInt("CurrentMissionIndex", currentMissionIndex);

//         if (currentMissionIndex < missions.Count)
//         {
//             Mission currentMission = missions[currentMissionIndex];
//             currentMission.Activate();

//             // Release subsequent missions
//             ReleaseSubsequentMissions(currentMissionIndex);
//         }
//         else
//         {
//             // All missions completed
//             Debug.Log("All missions completed!");
//         }

//         // Trigger the mission complete event
//         OnMissionComplete?.Invoke();

//         // Load the next scene or perform other necessary actions
//     }

//     // Release subsequent missions starting from the specified index
//     private void ReleaseSubsequentMissions(int startIndex)
//     {
//         for (int i = startIndex + 1; i < missions.Count; i++)
//         {
//             missions[i].Activate();
//         }
//     }
// }

// // Mission class
// public class Mission
// {
//     public string name;
//     public bool activated;
//     public bool optional;
//     public System.Action onComplete;

//     public Mission(string name, bool optional, System.Action onComplete)
//     {
//         this.name = name;
//         this.optional = optional;
//         this.onComplete = onComplete;
//     }

//     public void Activate()
//     {
//         activated = true;
//     }

//     public void Complete()
//     {
//         onComplete?.Invoke();
//     }
// }
