using InterfloraEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester
{
    [TestClass]
    public class CompanyStructureTests
    {
        [TestMethod]
        public void AddNode_ShouldAddNodeToParent()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);

            Node managerA = new Node(2, "Manager A");
            companyStructure.AddNode(managerA, ceo.Identifier);

            Node developerC = new Node(3, "Developer C");
            companyStructure.AddNode(developerC, managerA.Identifier);

            // Act
            List<Node> managerAChildren = companyStructure.GetChildren(managerA.Identifier);

            // Assert
            Assert.AreEqual(1, managerAChildren.Count);
            Assert.AreEqual(developerC, managerAChildren[0]);
        }

        [TestMethod]
        public void GetChildren_ShouldReturnChildrenOfGivenParent()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);

            Node managerA = new Node(2, "Manager A");
            companyStructure.AddNode(managerA, ceo.Identifier);

            Node developerC = new Node(3, "Developer C");
            companyStructure.AddNode(developerC, managerA.Identifier);

            // Act
            List<Node> managerAChildren = companyStructure.GetChildren(managerA.Identifier);

            // Assert
            Assert.AreEqual(1, managerAChildren.Count);
            Assert.AreEqual(developerC, managerAChildren[0]);
        }

        [TestMethod]
        public void ChangeParent_ShouldChangeParentOfNode()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);

            Node managerA = new Node(2, "Manager A");
            companyStructure.AddNode(managerA, ceo.Identifier);

            Node developerC = new Node(3, "Developer C");
            companyStructure.AddNode(developerC, managerA.Identifier);

            Node managerB = new Node(4, "Manager B");
            companyStructure.AddNode(managerB, ceo.Identifier);

            // Act
            companyStructure.ChangeParent(developerC.Identifier, managerB.Identifier);

            List<Node> managerBChildren = companyStructure.GetChildren(managerB.Identifier);
            List<Node> managerAChildren = companyStructure.GetChildren(managerA.Identifier);

            // Assert
            Assert.AreEqual(1, managerBChildren.Count);
            Assert.AreEqual(developerC, managerBChildren[0]);
            Assert.AreEqual(0, managerAChildren.Count);
        }

        [TestMethod]
        public void ChangeParent_ShouldNotChangeParentOfNode_WhenNewParentDoesNotExist()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A");
            companyStructure.AddNode(managerA, ceo.Identifier);
            Node developerC = new Node(3, "Developer C");
            companyStructure.AddNode(developerC, managerA.Identifier);
            Node managerB = new Node(4, "Manager B");
            companyStructure.AddNode(managerB, ceo.Identifier);

            // Act
            companyStructure.ChangeParent(developerC.Identifier, 5);
            List<Node> managerBChildren = companyStructure.GetChildren(managerB.Identifier);
            List<Node> managerAChildren = companyStructure.GetChildren(managerA.Identifier);

            // Assert
            Assert.AreEqual(0, managerBChildren.Count);
            Assert.AreEqual(1, managerAChildren.Count);
            Assert.AreEqual(developerC, managerAChildren[0]);
        }

        [TestMethod]
        public void ChangeParent_ShouldNotChangeParentOfNode_WhenNodeDoesNotExist()
        {
            // Arrange
            Node ceo = new Node(1, "CEO");
            CompanyStructure companyStructure = new CompanyStructure(ceo);
            Node managerA = new Node(2, "Manager A");
            companyStructure.AddNode(managerA, ceo.Identifier);
            Node developerC = new Node(3, "Developer C");
            companyStructure.AddNode(developerC, managerA.Identifier);
            Node managerB = new Node(4, "Manager B");
            companyStructure.AddNode(managerB, ceo.Identifier);

            // Act
            companyStructure.ChangeParent(5, managerB.Identifier);
            List<Node> managerBChildren = companyStructure.GetChildren(managerB.Identifier);
            List<Node> managerAChildren = companyStructure.GetChildren(managerA.Identifier);

            // Assert
            Assert.AreEqual(0, managerBChildren.Count);
            Assert.AreEqual(1, managerAChildren.Count);
            Assert.AreEqual(developerC, managerAChildren[0]);
        }

    }
}
