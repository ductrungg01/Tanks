using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculateDamage 
{
    public static float Calculate(ExplosionInfor explosionInfor, Vector3 targetPosition, float maxDamage, float defendStat)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - explosionInfor._Position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (explosionInfor._ExplosionRadius - explosionDistance) / explosionInfor._ExplosionRadius;
        
        float damage = relativeDistance * maxDamage * 1/(defendStat/100f);
        //float damage = relativeDistance * maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}
