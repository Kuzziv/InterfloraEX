using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfloraEX.Models
{
    public class Node
    {
        // Constants representing the types of nodes
        public const string TypeManager = "manager";
        public const string TypeDeveloper = "developer";

        // List of all possible types
        public static readonly List<string> Types = new List<string>
        {
            TypeManager,
            TypeDeveloper
        };

        // Properties of the Node class
        public int Identifier { get; set; } // Unique identifier for the node
        public string Name { get; set; } // Name of the node
        public Node Parent { get; set; } // Reference to the parent node
        public int Height => Parent == null ? 0 : Parent.Height + 1; // Height of the node in the tree
        public List<Node> Children { get; set; } // List of child nodes
        public string Type { get; set; } // Type of the node
        public string Department { get; set; } // Department (only for Manager nodes)
        public string ProgramingLanguage { get; set; } // Programming language (only for Developer nodes)


        // Constructor to initialize a new instance of the Node class
        public Node(int identifier, string name, Node parent = null, string type = null)
        {
            Identifier = identifier;
            Name = name;
            Parent = parent;
            Children = new List<Node>();
            Type = type;

            // Set default values based on the node type
            if (Type == TypeManager)
            {
                Department = "Scrum Master"; // Set a default value for the Department
            }
            else if (Type == TypeDeveloper)
            {
                ProgramingLanguage = "C#"; // Sets a default value for the ProgramingLanguage
            }
        }

        // Method to add a child node to the current node
        public void AddChild(Node child)
        {
            Children.Add(child);
        }

        // Method to set the parent of the current node
        public void SetParent(Node parent)
        {
            Parent = parent;
        }

        // Method to get the children of the current node
        public List<Node> GetChildren()
        {
            return Children;
        }

        // Method to set the department (only for Manager nodes)
        public void SetDepartment(string department)
        {
            if (Type == TypeManager)
            {
                Department = department;
            }
        }

        // Method to set the programming language (only for Developer nodes)
        public void SetProgramingLanguage(string programingLanguage)
        {
            if (Type == TypeDeveloper)
            {
                ProgramingLanguage = programingLanguage;
            }
        }

    }
}
