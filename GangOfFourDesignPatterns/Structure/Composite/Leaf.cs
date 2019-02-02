using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangOfFourDesignPatterns.Structure.Composite
{
    /// <summary>
    /// This is leaf node in the tree-structure
    /// </summary>
    public class Leaf:ITreeNode
    {
        public void AddNode(ITreeNode node)
        {
            throw new NotSupportedException("Leaf node can not add new node");
        }

        public void RemoveNode(ITreeNode node)
        {
            throw new NotSupportedException("Leaf node can not remove node");
        }

        public void Display()
        {
            Console.WriteLine("this is a leaf node");
        }
    }
}
