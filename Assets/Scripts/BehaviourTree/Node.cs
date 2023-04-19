using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Node : ScriptableObject
    {
        [SerializeField] protected List<Node> _children;

        public abstract NodeResult Evaluate(AIBehaviour aiBehaviour);
    }
}