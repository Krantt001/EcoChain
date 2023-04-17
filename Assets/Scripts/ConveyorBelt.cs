using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] List<Animator> _animators;

    [ContextMenu("Activate")]
    public void Activate()
    {
        _animators.ForEach(animator => animator.Play("Activated"));
    }
    
    [ContextMenu("Deactivate")]
    public void Deactivate()
    {
        _animators.ForEach(animator => animator.Play("Idle"));
    }
}
