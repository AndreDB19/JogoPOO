using UnityEngine;

public abstract class states : MonoBehaviour
{
    public abstract void Enter();
    public abstract void Do();
    public abstract void FixedDo();
    public abstract void LateDo();
    public abstract void Exit();
}