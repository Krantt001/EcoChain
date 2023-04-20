using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Selector")]
    public class Selector : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            foreach (var node in _children)
            {
                switch (node.Evaluate(aiBehaviour))
                {
                    case NodeResult.Failure:
                        continue;
                    case NodeResult.Success:
                        return NodeResult.Success;
                    case NodeResult.Running:
                        return NodeResult.Running;
                }
            }

            return NodeResult.Failure;
        }
    }
}