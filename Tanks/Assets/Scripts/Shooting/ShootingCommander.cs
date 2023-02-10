using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCommander : MonoBehaviour
{
    private List<IShootingMethod> ShootingMethodList = new List<IShootingMethod>();

    public void Fire(Vector3 pos, Quaternion rotation,  Vector3 velocity)
    {
        foreach (var method in ShootingMethodList)
        {
            // TODO: detect the right shooting
            method.Fire(pos, rotation, velocity);
        }
    }

    public void AddMethod(IShootingMethod method)
    {
        ShootingMethodList.Add(method);
    }
}
