using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public Waypoint[] path;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        path = gameObject.GetComponentsInChildren<Waypoint>();
    }
}
