using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionEnforcer : MonoBehaviour
{
    void Start()
    {
        // Force 2048x2048 resolution windowed
        Screen.SetResolution(2048, 2048, true);
    }
}
