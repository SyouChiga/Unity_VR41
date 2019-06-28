using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public abstract class BeginNode : MonoBehaviour
    {
        //  listのnode
        [SerializeField]
        protected List<BeginNode> node_ = new List<BeginNode>();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected void Node()
        {
            NodeUpdate();
            NodeChildUpdate();
        }

        //ノードの子要素をアップデート
        protected void NodeChildUpdate()
        {
            if (node_.Count == 0) return;
            foreach(var node in node_)
            {
                node.NodeUpdate();
            }
        }

        //ノードのアップデート
        protected abstract void NodeUpdate();
    }
}
