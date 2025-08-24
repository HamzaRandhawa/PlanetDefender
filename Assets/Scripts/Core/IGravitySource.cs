using UnityEngine;

public interface IGravitySource
{
    Vector3 GetGravityDirection(Vector3 position);
    float GetGravityStrength();
}
