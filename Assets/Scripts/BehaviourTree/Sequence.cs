using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Sequence")]
    public class Sequence : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            foreach (var node in _children)
            {
                switch (node.Evaluate(aiBehaviour))
                {
                    case NodeResult.Failure:
                        return NodeResult.Failure;
                    case NodeResult.Success:
                        continue;
                    case NodeResult.Running:
                        return NodeResult.Running;
                }
            }

            return NodeResult.Success;
        }
    }
}