using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    private ShootingType _TypeInUse;
    private int[] _NumBulletRemain = new int[4];

    private void Start()
    {
        _NumBulletRemain = ConfigurationUtil.NumsOfBulletEveryTypeStarting;
    }

    public int OnTakeTheBullet(int number = 1)
    {
        if (_NumBulletRemain[(int)_TypeInUse] == 0)
        {
            Debug.Log("Hết đạn! -.-");
            return 0;
        }

        if (number >= _NumBulletRemain[(int)_TypeInUse])
        {
            number = _NumBulletRemain[(int)_TypeInUse];
            _NumBulletRemain[(int)_TypeInUse] = 0;
        }
        else
        {
            _NumBulletRemain[(int)_TypeInUse] -= number;
        }

        return number;
    }

    public ShootingType TypeInUse
    {
        get { return _TypeInUse; }
        set
        {
            TypeInUse = value;
        }
    }
}
