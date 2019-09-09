using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDS.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BL.Model.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void ConstructorNotParam_NullItem()
        {
            //Arrange
            LinkedList<int> linkedList;
            //Act
            linkedList = new LinkedList<int>();
            //Assert
            Assert.AreEqual(null, linkedList.Head);
            Assert.AreEqual(null, linkedList.Tail);
            Assert.AreEqual(0, linkedList.Count);
        }

        [TestMethod()]
        public void ConstructorOneParam_DataNotNull_OneItem()
        {
            //Arrange
            int data = 1;
            LinkedList<int> linkedList;
            //Act
            linkedList = new LinkedList<int>(data);
            //Assert
            Assert.AreEqual(data, linkedList.Head.Data);
            Assert.AreEqual(data, linkedList.Tail.Data);
            Assert.AreEqual(1, linkedList.Count);
        }
        [TestMethod()]
        public void ConstructorOneParam_DataNull_ArgumentNullException()
        {
            //Arrange
            string data = null;
            //Act
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new LinkedList<string>(data), "Исключение при добавлении null!");
        }


        [TestMethod()]
        public void AddOneParam_DataNotNullListEmpty_AddItem()
        {
            //Arrange
            int data = 1;
            LinkedList<int> linkedList = new LinkedList<int>();
            //Act
            linkedList.Add(data);
            //Assert
            Assert.AreEqual(data, linkedList.Head.Data);
            Assert.AreEqual(data, linkedList.Tail.Data);
            Assert.AreEqual(1, linkedList.Count);
        }
        [TestMethod()]
        public void AddOneParam_DataNotNullListNotEmpty_AddItem()
        {
            //Arrange
            int data1 = 1;
            int data2 = 2;
            int data3 = 3;
            LinkedList<int> linkedList = new LinkedList<int>(data1);
            //Act
            linkedList.Add(data2);
            linkedList.Add(data3);
            //Assert
            Assert.AreEqual(data1, linkedList.Head.Data);
            Assert.AreEqual(data3, linkedList.Tail.Data);
            Assert.AreEqual(3, linkedList.Count);
        }
        [TestMethod()]
        public void AddOneParam_DataNull_ArgumentNullException()
        {
            //Arrange
            string data1 = "1";
            string data2 = "2";
            string data3 = null;
            LinkedList<string> linkedList = new LinkedList<string>(data1);
            linkedList.Add(data2);
            //Act

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.Add(data3), "Исключение при добавлении null!");
        }



        [DataTestMethod]
        [DataRow(new string[]{"1","2","3","1"}, "1", new string[] { "2", "3", "1" })]
        [DataRow(new string[]{"1","2","1","4"}, "2", new string[] { "1", "1", "4" })]
        [DataRow(new string[]{"1","2","3","4"}, "4", new string[] { "1", "2", "3"})]
        [DataRow(new string[]{"4"}, "4", new string[] { })]
        public void RemoveFirstOneParam_DataNotNull_True(string[] datas, string delete, string[] res)
        {
            //Arrange
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (var data in datas)
            {
                linkedList.Add(data);
            }
            bool isRemove;
            //Act
            isRemove = linkedList.RemoveFirst(delete);
            //Assert
            int i = 0;
            Assert.AreEqual(res.Length,linkedList.Count);
            Assert.IsTrue(isRemove);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(res[i],item);
                
                i++;
            }
        }


        [DataTestMethod]
        [DataRow(new string[] { "1","2","3" }, "4", new string[] { "1", "2", "3" })]
        [DataRow(new string[] { "1" }, "4", new string[] { "1" })]
        [DataRow(new string[] { }, "4", new string[] { })]
        public void RemoveFirstOneParam_DataNotNull_False(string[] datas, string delete, string[] res)
        {
            //Arrange
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (var data in datas)
            {
                linkedList.Add(data);
            }
            //Act
            bool isRemove;
            //Act
            isRemove = linkedList.RemoveFirst(delete);
            //Assert
            int i = 0;
            Assert.AreEqual(res.Length,linkedList.Count);
            Assert.IsFalse(isRemove);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(res[i], item);

                i++;
            }
        }




        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "3", "1" }, "1", new string[] { "2", "3" })]
        [DataRow(new string[] { "1", "2", "1", "4" }, "2", new string[] { "1", "1", "4" })]
        [DataRow(new string[] { "4", "4", "3", "4" }, "4", new string[] { "3" })]
        [DataRow(new string[] { "4" }, "4", new string[] { })]
        public void RemoveAllOneParam_DataNotNull_True(string[] datas, string delete, string[] res)
        {
            //Arrange
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (var data in datas)
            {
                linkedList.Add(data);
            }
            bool isRemove;
            //Act
            isRemove = linkedList.RemoveAll(delete);
            //Assert
            int i = 0;
            Assert.AreEqual(res.Length,linkedList.Count);
            Assert.IsTrue(isRemove);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(res[i], item);

                i++;
            }
        }


        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "3" }, "4", new string[] { "1", "2", "3" })]
        [DataRow(new string[] { "1" }, "4", new string[] { "1" })]
        [DataRow(new string[] { }, "4", new string[] { })]
        public void RemoveAllOneParam_DataNotNull_False(string[] datas, string delete, string[] res)
        {
            //Arrange
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (var data in datas)
            {
                linkedList.Add(data);
            }
            //Act
            bool isRemove;
            //Act
            isRemove = linkedList.RemoveAll(delete);
            //Assert
            int i = 0;
            Assert.AreEqual(res.Length,linkedList.Count);
            Assert.IsFalse(isRemove);
            foreach (var item in linkedList)
            {
                Assert.AreEqual(res[i], item);

                i++;
            }
        }


        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "3" })]
        [DataRow(new string[] { "1" })]
        [DataRow(new string[] { })]
        public void ClearNullParam_EmptyList(string[] datas)
        {
            //Arrange
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (var data in datas)
            {
                linkedList.Add(data);
            }
            //Act
            //Act
            linkedList.Clear();
            //Assert
            Assert.AreEqual(null, linkedList.Head);
            Assert.AreEqual(null, linkedList.Tail);
            Assert.AreEqual(0, linkedList.Count);
        }
    }
}