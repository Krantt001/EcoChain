using System;
using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/MoveTowardsCorrespondingBin")]
    public class MoveTowardsCorrespondingBin : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();
            var pickup = opponent.Pickup;

            var bins = FindObjectsOfType<Bin>();
            var bin = bins.First(bin => bin.AcceptedType == pickup.ItemType && bin.Owner == opponent);
            var correctBinDistance = Vector3.Distance(opponent.transform.position, bin.transform.position);

            if (correctBinDistance < opponent.DistanceThreshold && Math.Abs(correctBinDistance - GetClosestBin(opponent)) < float.Epsilon)
                aiBehaviour.Interacted = true;
            else
                aiBehaviour.Direction = (bin.transform.position - opponent.transform.position).normalized;

            return NodeResult.Success;
        }

        float GetClosestBin(Player opponent)
        {
            return FindObjectsOfType<Bin>().Min(bin => Vector3.Distance(opponent.transform.position, bin.transform.position));
        }
    }
}