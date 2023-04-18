using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] Animator _animator;

    void Start()
    {
        Activate();
    }

    [ContextMenu("Activate")]
    public void Activate()
    {
        _animator.Play("Hammering");
    }
    
    [ContextMenu("Deactivate")]
    public void Deactivate()
    {
        _animator.Play("Idle");
    }
}