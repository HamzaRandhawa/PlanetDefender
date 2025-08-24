using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnakeSegment : MonoBehaviour
{
    [FormerlySerializedAs("_snakeManager")] [SerializeField] private SnakeManager snakeManager;

    private Vector3 velocity;
    private Coroutine moveCoroutine;
    public Transform nextSegment;

    [SerializeField] private int fireballScore = 10;
    void Start()
    {
        
        velocity = Vector3.zero;
    }

    void Update()
    {
        if (snakeManager.CurrentInput == Vector2.zero) return;

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while ((transform.position - nextSegment.position).sqrMagnitude > snakeManager.SegmentSpacing)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                nextSegment.position,
                ref velocity,
                snakeManager.moveSpeed / (snakeManager.moveSpeed * 28f) // smooth time
            );
            yield return null;
        }
    }
 
}
