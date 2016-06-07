using System.Collections.Generic;
using System.Security.Permissions;

namespace DesignPattern.Composite
{
    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> ChildNodes { get; set; }

        public TreeNode(string name)
        {
            Name = name;
        }

        public void AddChild(TreeNode node)
        {
            ChildNodes.Add(node);
        }

        public void RemoveChild(TreeNode node)
        {
            ChildNodes.Remove(node);
        }
    }
}
