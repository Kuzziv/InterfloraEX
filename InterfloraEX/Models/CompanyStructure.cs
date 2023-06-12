using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfloraEX.Models
{
    public class CompanyStructure
    {
        private Node root;

        // Constructor to initialize the CompanyStructure with a root node
        public CompanyStructure(Node root)
        {
            this.root = root;
        }

        // Method to add a new node to the CompanyStructure under a specific parent node
        public void AddNode(Node newNode, int parentId)
        {
            // Find the parent node based on the parentId
            Node parentNode = FindNode(root, parentId);
            if (parentNode != null)
            {
                // Set the parent of the new node and add it to the parent's children list
                newNode.SetParent(parentNode);
                parentNode.AddChild(newNode);
            }
        }

        // Method to get the children nodes of a specific parent node
        public List<Node> GetChildren(int parentId)
        {
            // Find the parent node based on the parentId
            Node parentNode = FindNode(root, parentId);
            return parentNode?.GetChildren();
        }

        // Method to change the parent of a node
        public void ChangeParent(int nodeId, int newParentId)
        {
            // Find the node to be moved and the new parent node based on their ids
            Node node = FindNode(root, nodeId);
            Node newParentNode = FindNode(root, newParentId);
            if (node != null && newParentNode != null)
            {
                // Remove the node from its current parent's children list
                node.Parent.GetChildren().Remove(node);

                // Set the new parent for the node and add it to the new parent's children list
                node.SetParent(newParentNode);
                newParentNode.AddChild(node);
            }
        }

        // Recursive method to find a node in the CompanyStructure based on its id
        private Node FindNode(Node node, int nodeId)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Identifier == nodeId)
            {
                return node;
            }
            foreach (Node child in node.GetChildren())
            {
                Node result = FindNode(child, nodeId);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        // Method to print the details of a node and its children in a hierarchical structure
        public void PrintNode(Node node, int level = 0)
        {
            // Create indentation based on the level of the node
            string indentation = new string(' ', level * 4);
            // Print the node's details, including its name, identifier, parent (if exists), height, and type (if exists)
            Console.Write($"{indentation}- {node.Name} (ID: {node.Identifier}, Parent: {(node.Parent != null ? node.Parent.Name : "None")}, Height: {node.Height}");

            if (!string.IsNullOrEmpty(node.Type))
            {
                // If the node has a type, print additional information based on the type
                Console.Write($", Type: {node.Type}");

                // Exclude the CEO node from the additional details
                if (node.Name != "CEO")
                {
                    // If the node is a manager, print the department
                    if (node.Type == Node.TypeManager)
                    {
                        Console.Write($", Department: {node.Department}");
                    }
                    // If the node is a developer, print the programming language
                    else if (node.Type == Node.TypeDeveloper)
                    {
                        Console.Write($", Programming Language: {node.ProgramingLanguage}");
                    }
                }
            }

            Console.WriteLine();

            // Recursively print the children nodes
            foreach (Node child in node.GetChildren())
            {
                PrintNode(child, level + 1);
            }
        }
    }
}
