using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Common.BinaryTree
{
    class Node<T>
    {
        T _value;
        Node<T> _left;
        Node<T> _right;

        Node(T value, Node<T> left, Node<T> right)
        {
            _value = value;
            _left = left;
            _right = right;
            HasParent = false;
        }

        public bool HasParent { get; protected set; }

        public Node<T> Left { get { return _left; } }
        public Node<T> Right { get { return _right; } }

        public bool HasChildren()
        {
            return _left != null || _right != null;
        }
    }

    class Tree<T>
    {
        Node<T> _root;

    }

    //    template<typename T>
    //    class Tree
    //    {

    //        public:

    //    BinaryTreeNode<T>* m_pRoot;

    //        Tree(T value, const Tree<T>* pLeftTree = NULL, const Tree<T>* pRightTree = NULL)
    //    {
    //        BinaryTreeNode<T>* pLeftNode = NULL;
    //        if(pLeftTree != NULL)
    //        {
    //            pLeftNode = pLeftTree->m_pRoot;
    //            pLeftNode->m_bHasParent = true;
    //        }

    //    BinaryTreeNode<T>* pRightNode = NULL;
    //        if(pRightTree != NULL)
    //        {
    //            pRightNode = pRightTree->m_pRoot;
    //            pRightNode->m_bHasParent = true;
    //        }

    //    m_pRoot = new BinaryTreeNode<T>(value, pLeftNode, pRightNode);
    //    }

    //void PrintInorder()
    //{
    //    cout << "Inorder: " << endl;

    //    PrintInorder(m_pRoot);

    //    cout << endl;
    //}

    //void PrintPreorder()
    //{
    //    cout << "Preorder: " << endl;

    //    PrintPreorder(m_pRoot);

    //    cout << endl;
    //}

    //void PrintPostorder()
    //{
    //    cout << "Postorder: " << endl;

    //    PrintPostorder(m_pRoot);

    //    cout << endl;
    //}

    //// Print Breath First Search
    //void PrintBFS()
    //{
    //    cout << "Breath First Search: " << endl;

    //    queue<BinaryTreeNode<int>*> nodes;

    //    nodes.push(m_pRoot);

    //    while (!nodes.empty())
    //    {
    //        nodes.front()->PrintValue("");

    //        if (nodes.front()->m_pLeftNode != NULL)
    //        {
    //            nodes.push(nodes.front()->m_pLeftNode);
    //        }

    //        if (nodes.front()->m_pRightNode != NULL)
    //        {
    //            nodes.push(nodes.front()->m_pRightNode);
    //        }

    //        nodes.pop();
    //    }

    //    cout << endl;
    //}

    //// Print Depth First Search
    //void PrintDFS()
    //{
    //    cout << "Depth First Search: " << endl;

    //    string tabs = "";

    //    PrintDFS(m_pRoot, tabs);

    //    cout << endl;
    //}

    //void Insert(int value)
    //{
    //    Insert(value);
    //}

    //~Tree()
    //{
    //    delete m_pRoot;
    //}

    //private:

    //    // Order: Left, Root, Right
    //    void PrintInorder(BinaryTreeNode<T>* pNode)
    //{
    //    // Print the left node
    //    if (pNode->m_pLeftNode != NULL)
    //    {
    //        PrintInorder(pNode->m_pLeftNode);
    //    }

    //    // Print the root
    //    pNode->PrintValue("");
    //    cout << " ";

    //    // Print the right node
    //    if (pNode->m_pRightNode != NULL)
    //    {
    //        PrintInorder(pNode->m_pRightNode);
    //    }

    //    if (!pNode->HasParent())
    //    {
    //        return;
    //    }
    //}

    //// Order: Root, Left, Right
    //void PrintPreorder(BinaryTreeNode<T>* pNode)
    //{
    //    // Print the root
    //    pNode->PrintValue("");
    //    cout << " ";

    //    // Print the left node
    //    if (pNode->m_pLeftNode != NULL)
    //    {
    //        PrintPreorder(pNode->m_pLeftNode);
    //    }

    //    // Print the right node
    //    if (pNode->m_pRightNode != NULL)
    //    {
    //        PrintPreorder(pNode->m_pRightNode);
    //    }

    //    if (!pNode->HasParent())
    //    {
    //        return;
    //    }
    //}

    //// Inserts an element into the tree
    //void Insert(int value, BinaryTreeNode<T>* pNode)
    //{
    //    if (value < pNode->m_value)
    //    {
    //        Insert(pNode->m_pLeftNode);
    //    }
    //    else
    //    {
    //        Insert(pNode->m_pRightNode);
    //    }
    //}

    //// Order: Left, Right, Root
    //void PrintPostorder(BinaryTreeNode<T>* pNode)
    //{
    //    // Print the left node
    //    if (pNode->m_pLeftNode != NULL)
    //    {
    //        PrintPostorder(pNode->m_pLeftNode);
    //    }

    //    // Print the right node
    //    if (pNode->m_pRightNode != NULL)
    //    {
    //        PrintPostorder(pNode->m_pRightNode);
    //    }

    //    // Print the root
    //    pNode->PrintValue("");

    //    if (!pNode->HasParent())
    //    {
    //        return;
    //    }
    //}


    //// Print Depth First Search
    //void PrintDFS(BinaryTreeNode<T>* pNode, string tabs)
    //{
    //    pNode->PrintValue(tabs);

    //    cout << endl;

    //    tabs += "   ";

    //    if (pNode->m_pLeftNode != NULL)
    //    {
    //        PrintDFS(pNode->m_pLeftNode, tabs);
    //    }

    //    // Print the right node
    //    if (pNode->m_pRightNode != NULL)
    //    {
    //        PrintDFS(pNode->m_pRightNode, tabs);
    //    }
    //}
    //};


    //void CreateTree()
    //{
    //    Tree<int> tree(19,
    //        new Tree<int>(11,
    //            new Tree<int>(7),
    //            new Tree<int>(16,
    //                new Tree<int>(13),
    //                new Tree<int>(17))),
    //        new Tree<int>(35,
    //            new Tree<int>(23)));

    //    tree.Insert(15);

    //    //tree.PrintInorder();
    //    //tree.PrintPreorder();
    //    //tree.PrintPostorder();
    //    //tree.PrintBFS();
    //    tree.PrintDFS();

    //    // Find node
    //    // Delete node
    //    // Test complexity logN
    //    // graphs
    //}


}
