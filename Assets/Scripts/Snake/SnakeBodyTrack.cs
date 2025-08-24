using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyTrack : MonoBehaviour
{
	bool isHead = false;
	public bool IsHead
	{
		get => isHead;
		set => isHead = value;
	}

	bool isTail = false;
    public bool IsTail
    {
	    get => isTail;
	    set => isTail = value;
    }

    private void Awake()
    {
	    isHead = false;
	    isTail = false;
    }

    public bool IsSurrounded()
    {
	    return !(IsHead || IsTail);
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
