using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/MoveTowardsClosestPlayerBin")]
    public class MoveTowardsClosestPlayerBin : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();
            var player = GameObject.Find("Player").GetComponent<Player>();

            var bins = FindObjectsOfType<Bin>().Where(bin => bin.Owner == player);

            Bin closestPlayerBin = null;
            var closestDistance = float.MaxValue;

            foreach (var bin in bins)
            {
                var distance = Vector3.Distance(opponent.transform.position, bin.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPlayerBin = bin;
                }
            }
            
            aiBehaviour.Direction = (closestPlayerBin.transform.position - opponent.transform.position).normalized;

            return NodeResult.Success;
        }
    }
}