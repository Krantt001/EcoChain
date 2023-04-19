using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Sequence")]
    public class Sequence : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            return _children.All(child => child.Evaluate(aiBehaviour) == NodeResult.Success)
                ? NodeResult.Success
                : NodeResult.Failure;
        }
    }
}