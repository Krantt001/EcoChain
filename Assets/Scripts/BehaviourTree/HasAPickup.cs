using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/HasAPickup")]
    public class HasAPickup : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            return GameObject.Find("Opponent").GetComponent<Player>().Pickup == null
                ? NodeResult.Failure
                : NodeResult.Success;
        }
    }
}