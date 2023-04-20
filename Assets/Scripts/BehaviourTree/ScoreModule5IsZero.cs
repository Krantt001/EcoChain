using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/ScoreModule5IsZero")]
    public class ScoreModule5IsZero : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            var opponent = GameObject.Find("Opponent").GetComponent<Player>();
            return opponent.Points % 5 == 0 && opponent.Points != 0 ? NodeResult.Success : NodeResult.Failure;
        }
    }
}