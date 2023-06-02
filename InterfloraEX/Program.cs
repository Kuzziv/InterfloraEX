using InterfloraEX.Models;

// Create the nodes
Node ceo = new Node(1, "CEO", null, Node.TypeManager);
Node managerA = new Node(2, "Manager A", ceo, Node.TypeManager);
Node managerB = new Node(3, "Manager B", ceo, Node.TypeManager);
Node developerC = new Node(4, "Developer C", managerA, Node.TypeDeveloper);
Node developerD = new Node(5, "Developer D", managerA, Node.TypeDeveloper);

// Set department for manager nodes
managerA.SetDepartment("Sales");
managerB.SetDepartment("Marketing");

// Set programming language for developer nodes
developerC.SetProgramingLanguage("Java");
developerD.SetProgramingLanguage("Python");

// Create the company structure
CompanyStructure company = new CompanyStructure(ceo);

// Add nodes to the company structure
company.AddNode(managerA, ceo.Identifier);
company.AddNode(managerB, ceo.Identifier);
company.AddNode(developerC, managerA.Identifier);
company.AddNode(developerD, managerA.Identifier);


//Print the company structure
company.PrintNode(ceo);

// Get child nodes of a given node
Console.WriteLine("\nChild nodes of 'Manager A':");
var managerAChildren = company.GetChildren(managerA.Identifier);
if (managerAChildren != null)
{
    foreach (var child in managerAChildren)
    {
        Console.WriteLine($"- {child.Name}");
    }
}

// Change the parent of a node
company.ChangeParent(developerD.Identifier, managerB.Identifier);

// Print the updated company structure
Console.WriteLine("\nUpdated company structure:");
company.PrintNode(ceo);


// The ReadLine() method is used to prevent the console from closing
Console.ReadLine();
