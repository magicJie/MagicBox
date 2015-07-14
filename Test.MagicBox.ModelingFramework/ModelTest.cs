using System.Text;
using MagicBox.MF;
using MagicBox.MF.Domain;
using MagicBox.MF.Id;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox.ModelingFramework
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void ModelOperationTest()
        {
            var user = ModelFactory.Current.NewModel(ModelTypeId.User);
            var id = user.Id;
            var name = user.GetProperty<string>("name");
            user.SetProperty("name", "tom");
            user.Save();

            var model1 = ModelFactory.Current.GetModel(id, ModelTypeId.User);
            model1.GetProperty<string>("name");

            model1.Delete();
            model1.Save();

            var model2 = ModelFactory.Current.GetModel(id, ModelTypeId.User);
        }
        [TestMethod]
        public void RelationshipOperationTest()
        {
            //
        }

        [TestMethod]
        public void ModelCollectionOperationTest()
        {
            var modelColl = new ModelCollection(new DbNativeQuery("select *from Identity where rownum<10"));//是否接受多表查询？
            modelColl.Load();
            var count = modelColl.Count;
            var sb = new StringBuilder();
            foreach (Model model in modelColl)
            {
                sb.AppendLine(model.GetProperty<string>("name"));
            }
        }
        [TestMethod]
        public void ModelCollectionByModelTypeOperationTest()
        {
            var modelCollByType = new ModelCollectionByModelType(ModelTypeId.User, "name like 't*'");
            modelCollByType.Load();
            var conut = modelCollByType.Count;
            var sb = new StringBuilder();
            foreach (Model model in modelCollByType)
            {
                sb.AppendLine(model.GetProperty<string>("name"));
            }
        }
    }
}
