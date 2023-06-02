using InterfloraEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void AddNode_ValidParentId_AddsNodeToParent()
        {
            // Arrange
            Node root = new Node(1, "Root");
            CompanyStructure companyStructure = new CompanyStructure(root);

            Node parentNode = new Node(2, "Parent");
            companyStructure.AddNode(parentNode, 1);

            Node newNode = new Node(3, "New Node");

            // Act
            companyStructure.AddNode(newNode, 2);
            var children = companyStructure.GetChildren(2);

            // Assert
            Assert.IsTrue(children.Contains(newNode));
        }

        [TestMethod]
        public void GetChildren_ValidParentId_ReturnsChildren()
        {
            // Arrange
            Node root = new Node(1, "Root");
            CompanyStructure companyStructure = new CompanyStructure(root);

            Node parentNode = new Node(2, "Parent");
            companyStructure.AddNode(parentNode, 1);

            Node childNode1 = new Node(3, "Child 1");
            Node childNode2 = new Node(4, "Child 2");

            companyStructure.AddNode(childNode1, 2);
            companyStructure.AddNode(childNode2, 2);

            // Act
            var children = companyStructure.GetChildren(2);

            // Assert
            Assert.IsTrue(children.Contains(childNode1));
            Assert.IsTrue(children.Contains(childNode2));
        }

        [TestMethod]
        public void ChangeParent_ValidNodeIds_ChangesParentNode()
        {
            // Arrange
            Node root = new Node(1, "Root");
            CompanyStructure companyStructure = new CompanyStructure(root);

            Node parentNode1 = new Node(2, "Parent 1");
            Node parentNode2 = new Node(3, "Parent 2");
            companyStructure.AddNode(parentNode1, 1);
            companyStructure.AddNode(parentNode2, 1);

            Node childNode = new Node(4, "Child");
            companyStructure.AddNode(childNode, 2);

            // Act
            companyStructure.ChangeParent(4, 3);
            var newParent = childNode.Parent;

            // Assert
            Assert.AreEqual(parentNode2, newParent);
        }

        [TestMethod]
        public void SetDepartment_ShouldReturnDepartment()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A", ceo, Node.TypeManager);

            // Act
            managerA.SetDepartment("IT");

            // Assert
            Assert.AreEqual("IT", managerA.Department);
        }

        [TestMethod]
        public void SetProgramingLanguage_ShouldReturnProgramingLanguage()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A", ceo, Node.TypeManager);
            Node developerC = new Node(3, "Developer C", managerA, Node.TypeDeveloper);

            // Act
            developerC.SetProgramingLanguage("C#");

            // Assert
            Assert.AreEqual("C#", developerC.ProgramingLanguage);
        }

        [TestMethod]
        public void NodeHeight_ShouldReturnHeightOfManagerA()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A", ceo, Node.TypeManager);
            Node developerC = new Node(3, "Developer C", managerA, Node.TypeDeveloper);

            // Act
            int height = managerA.Height;

            // Assert
            Assert.AreEqual(1, height);
        }

        [TestMethod]
        public void NodeHeight_ShouldReturnHeightOfDeveloperC()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A", ceo, Node.TypeManager);
            Node developerC = new Node(3, "Developer C", managerA, Node.TypeDeveloper);

            // Act
            int height = developerC.Height;

            // Assert
            Assert.AreEqual(2, height);
        }
    }
}
