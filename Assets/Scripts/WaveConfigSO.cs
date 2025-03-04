//The name of the file ends with an 'SO' that indicates that it is an ScriptableObject.

using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

//CreateAssetMenu is used here so that we can create new WaveConfig in Unity.*New Wave Config is the new file name & the menu name is of type 
// Wave Config*
[CreateAssetMenu(menuName= "Wave Config", fileName = "New Wave Config")]

//MonoBehaviour is switched for ScriptableObject (*Note: That the Game objects only exists within the scenes or prefabs, whereas a scriptable 
// object is an asset that exists on disk. *).
public class WaveConfigSO : ScriptableObject
{
    //pathprefab of type transform is used to store all the Waypoints. *Note: the objects here are private as they are within an ScrirptableObject*
    [SerializeField] Transform pathprefab;
    [SerializeField] float movespeed = 5f;

    //GetMoveSpeed(), getStartingWaypoint() & GetWaypoints() are all 'Getter function' here as the objects within an ScriptableObject are private.
    //So in order to access movespeed we used a getter function.
    public Transform GetStartingWaypoint(){
        return pathprefab.GetChild(0); //For getting the first waypoint's transform
    }

    public List<Transform> GetWaypoints(){
        List<Transform> waypoints= new List<Transform>(); //Declaring a list 'waypoints' for storing child (waypoints) component of type 'Transform'.
        foreach(Transform child in pathprefab){
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed(){
        return movespeed;
    }
}
