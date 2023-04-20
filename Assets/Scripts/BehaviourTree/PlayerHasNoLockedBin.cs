using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/PlayerHasNoLockedBin")]
    public class PlayerHasNoLockedBin : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var player = GameObject.Find("Player").GetComponent<Player>();
            var anyLocked = FindObjectsOfType<Bin>().Where(bin => bin.Owner == player).Any(bin => bin.IsLocked);

            return anyLocked ? NodeResult.Failure : NodeResult.Success;
        }
    }
}