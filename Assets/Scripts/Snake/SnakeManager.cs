using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnakeManager : MonoBehaviour
{
    public InputManager inputManager;
    public Transform head;
    [FormerlySerializedAs("first")] public Transform firstSegment;
    public GameObject snakeParentObj;

    [SerializeField] private GameObject segmentPrefab;

    [SerializeField] private int initialSize = 3;

    [SerializeField] private float segmentSpacing = 0.2f; // distance between body parts
    private Transform earth;
    public Transform Earth => earth;

    public float SegmentSpacing => segmentSpacing;
    public float moveSpeed = 5f;
    private Vector2 currentInput;
    public Vector2 CurrentInput => currentInput; // public read-only property
    public List<Transform> segments = new List<Transform>();

    void Start()
    {
        InitiliazeSnake();
    }
    void Update()
    {
        
    }

    void InitiliazeSnake()
    {
        if (earth == null)
        {
            earth = GameObject.FindWithTag("Earth").transform;
        }
        // Add head as first segment
        segments.Add(firstSegment.transform);
        head.GetComponent<SnakeBodyTrack>().IsHead = true;
            
        
        // Spawn initial body
        for (int i = 0; i < initialSize; i++)
        {
            Grow();
        }
        segments[segments.Count - 1].GetComponent<SnakeBodyTrack>().IsTail = true;
    }
    public void Grow()
    {
        GameObject newSegment = Instantiate(segmentPrefab, segments[segments.Count - 1].position + new Vector3(1, 0, 0),
            Quaternion.identity, snakeParentObj.transform);
        newSegment.GetComponent<SnakeSegment>().nextSegment = segments[segments.Count - 1];
        segments.Add(newSegment.transform);
    }

    private void OnEnable()
    {
        inputManager.moveEvent += HandleMove;
        inputManager.moveCanceledEvent += HandleMoveCanceled;
    }

    private void OnDisable()
    {
        inputManager.moveEvent -= HandleMove;
        inputManager.moveCanceledEvent -= HandleMoveCanceled;
    }
    
    private void HandleMove(Vector2 input)
    {
        currentInput = input;
    }

    private void HandleMoveCanceled()
    {
        currentInput = Vector2.zero;
    }
}
