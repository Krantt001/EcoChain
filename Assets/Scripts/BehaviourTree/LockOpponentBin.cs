using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/LockOpponentBin")]
    public class LockOpponentBin : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();
            var player = GameObject.Find("Player").GetComponent<Player>();

            var bins = FindObjectsOfType<Bin>().Where(bin => bin.Owner == player);

            var closestDistance = float.MaxValue;

            foreach (var bin in bins)
            {
                var distance = Vector3.Distance(opponent.transform.position, bin.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }

            if (closestDistance > opponent.DistanceThreshold)
                return NodeResult.Failure;
            
            aiBehaviour.Interacted = true;
            return NodeResult.Success;
        }
    }
}