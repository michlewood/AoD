using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp1
{
    class BinaryTreeNode
    {
        //public BinaryTreeNode Parent { get; private set; }
        public BinaryTreeNode LeftChild { get; private set; }
        public BinaryTreeNode RightChild { get; private set; }

        public int Value { get; }

        public int Length
        {
            get { return Value.ToString().Length; }
        }


        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public void SetChild(BinaryTreeNode newChild)
        {
            if (Value >= newChild.Value)
            {
                if (LeftChild == null)
                {
                    LeftChild = newChild;
                    //LeftChild.SetParent(this);
                }
                else LeftChild.SetChild(newChild);
            }
            else
            {
                if (RightChild == null)
                {
                    RightChild = newChild;
                    //RightChild.SetParent(this);
                }
                else RightChild.SetChild(newChild);
            }
        }

        //private void SetParent(BinaryTreeNode parent)
        //{
        //    Parent = parent;
        //}

        public List<BinaryTreeNode> GetTree()
        {
            List<BinaryTreeNode> tempTree = new List<BinaryTreeNode>();

            if (LeftChild != null) tempTree.AddRange(this.LeftChild.GetTree());
            tempTree.Add(this);
            if (RightChild != null) tempTree.AddRange(this.RightChild.GetTree());

            return tempTree;
        }

        public List<int> GetIntTree()
        {
            List<int> tempTree = new List<int>();

            if (LeftChild != null) tempTree.AddRange(this.LeftChild.GetIntTree());
            tempTree.Add(this.Value);
            if (RightChild != null) tempTree.AddRange(this.RightChild.GetIntTree());

            return tempTree;
        }

        public void PrintTree(int left = 200, int top = 0)
        {
            if (LeftChild != null)
            {

                if (RightChild == null) LeftChild.PrintTree(left - 5, top + 1);
                else LeftChild.PrintTree(left - 8, top + 1);
            }
            if (RightChild != null)
            {

                if (LeftChild == null) RightChild.PrintTree(left + 5, top + 1);
                else RightChild.PrintTree(left + 9, top + 1);
            }

            Console.SetCursorPosition(left, top);
            Console.WriteLine(Value);
            Console.SetCursorPosition(0, 10);
        }
    }
}
