using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/MoveTowardsClosestItem")]
    public class MoveTowardsClosestItem : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();

            var items = FindObjectsOfType<Item>().ToList();

            var minDistance = float.MaxValue;
            Item closestItem = null;

            foreach (var item in items)
            {
                var distance = Vector3.Distance(opponent.transform.position, item.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = item;
                }
            }

            if (closestItem == null)
                return NodeResult.Failure;

            if (minDistance < opponent.DistanceThreshold)
            {
                aiBehaviour.Interacted = true;
            }
            else
            {
                aiBehaviour.Direction = (closestItem.transform.position - opponent.transform.position).normalized;
            }

            return NodeResult.Success;
        }
    }
}