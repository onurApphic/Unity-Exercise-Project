using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{
}


public interface IKillable
{
    void Kill();
}
public interface IDamageable<T>
{
    void Damage(T damageTaken);
}

public class Avatar : MonoBehaviour, IKillable, IDamageable<float>
{
    public void Kill()
    {
        //Do something fun
    }
    public void Damage(float damageTaken)
    {
        //Do something fun
    }
}