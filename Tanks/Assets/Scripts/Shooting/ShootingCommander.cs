using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCommander : MonoBehaviour
{
    public List<IShootingMethod> ShootingMethodList = new List<IShootingMethod>();

    public void Fire(ShootingType type, Vector3 pos, Quaternion rotation,  Vector3 velocity)
    {
        foreach (var method in ShootingMethodList)
        {
            if (method.Type() == type)
            {
                method.Fire(pos, rotation, velocity);
            }
        }
    }

    public void AddMethod(IShootingMethod method)
    {
        ShootingMethodList.Add(method);
    }
}
