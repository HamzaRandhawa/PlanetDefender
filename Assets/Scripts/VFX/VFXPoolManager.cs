using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject vfxPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public static VFXPoolManager Instance;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(vfxPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetVFX(Vector3 position)
    {
        var vfx = pool.Dequeue();
        vfx.transform.position = position;
        vfx.SetActive(true);
        pool.Enqueue(vfx);
        return vfx;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
