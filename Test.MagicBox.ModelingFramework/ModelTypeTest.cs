﻿using System;
using MagicBox.MF;
using MagicBox.MF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox.MF
{
    /// <summary>
    /// 模型元数据相关功能单元测试
    /// </summary>
    [TestClass]
    public class ModelTypeTest
    {
        public ModelTypeTest()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateTableModelTypeTest()
        {
            var id = Model.NewId();
            try
            {
                if (!SessionFactory.Current.IsBeingTranscation)
                    SessionFactory.Current.BeginWithTranscation();
                var modelType = new ModelType(id, id)
                {
                    AncestorType = null,
                    Assembly = "MagicBox.ModelingFramework",
                    FullName = "MagicBox.MF.ModelsType",
                    IsAbstract = false,
                    IsSealed = true,
                    Parent = ModelFactory.Current.GetModel("", "")
                };
                modelType.CreateTableModelType();
                SessionFactory.Current.Accept();
            }
            catch (Exception)
            {
                SessionFactory.Current.Discard();
                throw;
            }
        }
    }
}
