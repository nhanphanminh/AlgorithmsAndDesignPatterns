using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangOfFourDesignPatterns.Structure.Composite
{
    /// <summary>
    /// This is an example of Composite pattern which is used to organize a Tree-structure of a hierarchy presentation
    /// In this example, we will create a tree structure which have leaf and parent node.
    /// this interface is abstraction of nodes in the tree
    /// </summary>
    public interface ITreeNode
    {
        void AddNode(ITreeNode node);
        void RemoveNode(ITreeNode node);
        void Display();
    }
}
