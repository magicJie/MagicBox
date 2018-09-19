using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace MagicBox.Reflection
{
    public class TypeCreator
    {
        public static Type CreateType(string className, IDictionary<string,Type> properties)
        {
            var currentDoamin = Thread.GetDomain();
            TypeBuilder typeBuilder;
            ModuleBuilder moduleBuilder;
            MethodBuilder methodBuilder;
            PropertyBuilder propertyBuilder;
            FieldBuilder fieldBuilder = null;
            AssemblyBuilder assemblyBuilder = null;
            ILGenerator ilGenerator = null;
            MethodAttributes methodAttrs;

            assemblyBuilder = currentDoamin.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
                AssemblyBuilderAccess.RunAndSave);
            moduleBuilder = assemblyBuilder.DefineDynamicModule(Guid.NewGuid().ToString(),true);
            typeBuilder = moduleBuilder.DefineType(className,
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.BeforeFieldInit |
                TypeAttributes.Serializable);
            //cab=new CustomAttributeBuilder(typeof(Castle.ActiveReccord.PropertyAttribute).GetConstructor(Type.EmptyTypes),new object[0]);
            //typeBuilder.SetCustomAttribute(cab);
            //cab = new CustomAttributeBuilder(typeof(Castle.ActiveRecord.PropertyAttribute).GetConstructor(Type.EmptyTypes), new object[0]);
            methodAttrs = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            foreach (KeyValuePair<string, Type> keyValuePair in properties)
            {
                fieldBuilder = typeBuilder.DefineField("field_" + keyValuePair.Key, keyValuePair.Value,
                    FieldAttributes.Public);
                propertyBuilder = typeBuilder.DefineProperty(keyValuePair.Key,
                    PropertyAttributes.HasDefault, keyValuePair.Value, null);
                
                methodBuilder = typeBuilder.DefineMethod("get_" + keyValuePair.Key, methodAttrs, keyValuePair.Value,
                    Type.EmptyTypes);
                ilGenerator = methodBuilder.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldfld,fieldBuilder);
                ilGenerator.Emit(OpCodes.Ret);
                propertyBuilder.SetGetMethod(methodBuilder);

                methodBuilder = typeBuilder.DefineMethod("set_" + keyValuePair.Key, methodAttrs, typeof (void),
                    new[] {keyValuePair.Value});
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Stfld,fieldBuilder);
                ilGenerator.Emit(OpCodes.Ret);
                propertyBuilder.SetSetMethod(methodBuilder);
            }
            return typeBuilder.CreateType();
            //return assemblyBuilder.GetType(className);
            //return methodBuilder.GetType(className);
        }
    }
}
