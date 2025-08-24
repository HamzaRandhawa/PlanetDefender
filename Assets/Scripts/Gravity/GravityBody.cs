using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    // [SerializeField] private MonoBehaviour gravitySourceComponent;
    private IGravitySource gravitySource;
    [SerializeField] private Rigidbody rigidBody;

    void Awake()
    {
        gravitySource = GameObject.FindWithTag("Earth").GetComponent<EarthGravity>() as IGravitySource;
        // rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        // gravitySource = gravitySourceComponent as IGravitySource;
    }

    void FixedUpdate()
    {
        if (gravitySource == null) return;
    
        // Gravity
        Vector3 gravityDir = gravitySource.GetGravityDirection(transform.position);
        Vector3 gravity = gravityDir * gravitySource.GetGravityStrength();
        rigidBody.AddForce(gravity, ForceMode.Acceleration);
    
        // Align orientation
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -gravityDir) * transform.rotation;
        rigidBody.MoveRotation(Quaternion.Slerp(rigidBody.rotation, targetRotation, 10 * Time.fixedDeltaTime));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
