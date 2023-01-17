using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolderUtil
{
    private static float _strengthRightnow;

    public static float StrengthRightnow
    {
        get { return _strengthRightnow; }
        set { _strengthRightnow = value; }
    }
}
