using System;
using System.Linq;
using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Inverter")]
    public class Inverter : Node
    {
        public override NodeResult Evaluate(AIBehaviour aiBehaviour)
        {
            return _children.First().Evaluate(aiBehaviour) switch
            {
                NodeResult.Running => NodeResult.Running,
                NodeResult.Success => NodeResult.Failure,
                NodeResult.Failure => NodeResult.Success,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}