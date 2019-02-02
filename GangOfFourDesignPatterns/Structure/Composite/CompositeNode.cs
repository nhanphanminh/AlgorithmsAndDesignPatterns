using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangOfFourDesignPatterns.Structure.Composite
{
    public class CompositeNode:ITreeNode
    {
        private List<ITreeNode> m_nodes = new List<ITreeNode>();

        public void AddNode(ITreeNode node)
        {
            m_nodes.Add(node);
        }

        public void RemoveNode(ITreeNode node)
        {
            m_nodes.Remove(node);
        }

        public void Display()
        {
            Console.WriteLine("this is a composite node");

            foreach (var node in m_nodes)
            {
                node.Display();
            }
        }
    }
}
