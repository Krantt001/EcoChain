using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/ResetInputs")]
    public class ResetInputs : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            aiBehaviour.Interacted = false;
            aiBehaviour.Direction = Vector2.zero;
            return NodeResult.Success;
        }
    }
}