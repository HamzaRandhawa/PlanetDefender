using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGravity : MonoBehaviour, IGravitySource
{
    [SerializeField] private float gravityStrength = 9.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetGravityDirection(Vector3 position)
    { 
        return (transform.position - position).normalized;
    }

    public float GetGravityStrength()
    {
        return gravityStrength;
    }
}
