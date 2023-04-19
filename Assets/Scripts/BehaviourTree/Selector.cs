using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Selector")]
    public class Selector : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            return _children.Any(child => child.Evaluate(aiBehaviour) == NodeResult.Success)
                ? NodeResult.Success
                : NodeResult.Failure;
        }
    }
}