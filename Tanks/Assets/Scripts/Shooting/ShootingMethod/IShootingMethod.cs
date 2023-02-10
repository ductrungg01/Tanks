using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingMethod
{
    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity);
}
