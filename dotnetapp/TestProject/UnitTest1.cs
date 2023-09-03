using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Moq;
using System.Data;
using System.Data.SqlClient;

namespace FurnitureApp.Tests
{
    [TestFixture]
    public class FurnitureControllerTests
    {
        private Type controllerType;
        private Type furnitureType;
        private PropertyInfo[] properties;

        [SetUp]
        public void Setup()
        {
            // Get the type of the FurnitureController
             furnitureType = typeof(dotnetapp.Models.Furniture);
            properties = furnitureType.GetProperties();
            controllerType = typeof(FurnitureController);
        }

        [Test]
        public void TestIndexMethodExists()
        {
            // Arrange
            MethodInfo indexMethod = controllerType.GetMethod("Index");

            // Assert
            Assert.IsNotNull(indexMethod, "Index method should exist in FurnitureController.");
        }

        [Test]
        public void TestCreateGetMethodExists()
        {
            // Arrange
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[0]);

            // Assert
            Assert.IsNotNull(createGetMethod, "Create method should exist in FurnitureController.");
        }

        [Test]
        public void TestCreatePostMethodExists()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { typeof(Furniture) });

            // Assert
            Assert.IsNotNull(createPostMethod, "Create POST method should exist in FurnitureController.");
        }


        [Test]
        public void TestCreatePostMethodReturnsActionResult()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { typeof(Furniture) });
            var controller = new FurnitureController();

            // Act
            var furniture = new Furniture(); // Create a sample Furniture object
            var result = createPostMethod.Invoke(controller, new object[] { furniture });

            // Assert
            Assert.IsInstanceOf<IActionResult>(result, "Create (POST) method should return an IActionResult.");
        }

        [Test]
        public void TestFurnitureClassExists()
        {
            // Arrange
            Type furnitureType = typeof(dotnetapp.Models.Furniture);

            // Assert
            Assert.IsNotNull(furnitureType, "Furniture class should exist.");
        }

        [Test]
        public void TestFurniturePropertiesExist()
        {
            // Assert
            Assert.IsNotNull(properties, "Furniture class should have properties.");
            Assert.IsTrue(properties.Length > 0, "Furniture class should have at least one property.");
        }

         [Test]
        public void TestidProperty()
        {
            // Arrange
            PropertyInfo idProperty = properties.FirstOrDefault(p => p.Name == "id");

            // Assert
            Assert.IsNotNull(idProperty, "Id property should exist.");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "Id property should have data type 'int'.");
        }

        [Test]
        public void TestProductProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Product");

            // Assert
            Assert.IsNotNull(productProperty, "Product property should exist.");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Product property should have data type 'string'.");
        }

        [Test]
        public void TestDescriptionProperty()
        {
            // Arrange
            PropertyInfo descriptionProperty = properties.FirstOrDefault(p => p.Name == "Description");

            // Assert
            Assert.IsNotNull(descriptionProperty, "Description property should exist.");
            Assert.AreEqual(typeof(string), descriptionProperty.PropertyType, "Description property should have data type 'string'.");
        }

        [Test]
        public void TestMaterialProperty()
        {
            // Arrange
            PropertyInfo descriptionProperty = properties.FirstOrDefault(p => p.Name == "Material");

            // Assert
            Assert.IsNotNull(descriptionProperty, "Material property should exist.");
            Assert.AreEqual(typeof(string), descriptionProperty.PropertyType, "Material property should have data type 'string'.");
        }

        [Test]
        public void TestDimensionsProperty()
        {
            // Arrange
            PropertyInfo descriptionProperty = properties.FirstOrDefault(p => p.Name == "Dimensions");

            // Assert
            Assert.IsNotNull(descriptionProperty, "Dimensions property should exist.");
            Assert.AreEqual(typeof(string), descriptionProperty.PropertyType, "Dimensions property should have data type 'string'.");
        }

        [Test]
        public void TestPriceProperty()
        {
            // Arrange
            PropertyInfo descriptionProperty = properties.FirstOrDefault(p => p.Name == "Price");

            // Assert
            Assert.IsNotNull(descriptionProperty, "Price property should exist.");
            Assert.AreEqual(typeof(decimal), descriptionProperty.PropertyType, "Price property should have data type 'string'.");
        }

        [Test]
        public void TestFurnitureDbContext_ClassExists_in_Models()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.FurnitureDbContext");
            Assert.NotNull(postType, "FurnitureDbContext class does not exist.");
        }

        [Test]
        public void TestFurniture_Folder_Exists()
        {
            bool viewsFolderExists = Directory.Exists(@"/home/coder/project/workspace/Furniture-MVC-ADO/dotnetapp/Views/Furniture");

            Assert.IsTrue(viewsFolderExists, "Furniture does not exist.");
        }

        [Test]
        public void Test_CreateViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Furniture-MVC-ADO/dotnetapp/Views/Furniture", "Create.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Create.cshtml view file does not exist.");
        }

        [Test]
        public void Test_IndexViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Furniture-MVC-ADO/dotnetapp/Views/Furniture", "Index.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Index.cshtml view file does not exist.");
        }
    }
}
