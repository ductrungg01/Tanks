using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionInfor
{
    #region Fields
    public Vector3 _Position = new Vector3();
    public float _ExplosionRadius = 5f;   
    public float _ExplosionForce = 1000f;
    #endregion

    #region Constructors
    public ExplosionInfor(Vector3 position)
    {
        this._Position = position;
    }

    public ExplosionInfor(Vector3 position, float radius, float explosionForce)
    {
        this._Position = position;
        this._ExplosionRadius = radius;
        this._ExplosionForce = explosionForce;
    }
    #endregion
}
