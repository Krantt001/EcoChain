using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/IsCorrespondingBinLocked")]
    public class IsCorrespondingBinLocked : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();
            var itemType = opponent.Pickup.ItemType;

            var locked = FindObjectsOfType<Bin>().First(bin => bin.AcceptedType == itemType && bin.Owner == opponent).IsLocked;

            return locked ? NodeResult.Success : NodeResult.Failure;
        }
    }
}