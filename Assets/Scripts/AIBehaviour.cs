using UnityEngine;
using Tree = BehaviourTree.Tree;

public class AIBehaviour : MonoBehaviour, IActionProvider
{
    [SerializeField] Tree _tree;

    void Update()
    {
        _tree.Execute(this);
    }

    public Vector2 Direction { get; set; }
    public bool Interacted { get; set; }
}