using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private SnakeManager _snakeManager;
    private void OnEnable()
    {

    }
    
    void Start()
    {
     
    }
    
    

    private void OnDisable()
    {
     
    }

 

    void Update()
    {
        // 1. 
        if (_snakeManager.Earth == null || _snakeManager.CurrentInput == Vector2.zero) return;
        
        // 2. Get surface normal (Earth center → snake position)
        Vector3 normal = (transform.position - _snakeManager.Earth.position).normalized;

        // 3. Build tangent directions
        Vector3 right = Vector3.Cross(normal, transform.forward).normalized;
        Vector3 forward = Vector3.Cross(right, normal).normalized;

        // 4. Calculate move direction based on input
        Vector3 moveDir = (_snakeManager.CurrentInput.x * right + _snakeManager.CurrentInput.y * forward).normalized;
        moveDir.z = 0f;
        // 5. Apply movement directly (no physics)
        transform.position += moveDir * _snakeManager.moveSpeed * Time.deltaTime;
    }
}


