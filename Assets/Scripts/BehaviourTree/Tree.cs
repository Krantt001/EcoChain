using UnityEngine;

namespace BehaviourTree
{
    [CreateAssetMenu(menuName = "BT/Tree")]
    public class Tree : ScriptableObject
    {
        [SerializeField] Node _root;

        public void Execute(AIBehaviour aiBehaviour)
        {
            _root.Evaluate(aiBehaviour);
        }
    }
}