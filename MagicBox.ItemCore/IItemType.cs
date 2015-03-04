using System;
using System.ComponentModel;
using System.Reflection;

namespace MagicBox.ItemCore
{
    public interface IItemType : IGeneralItem, IBaseItem, IEquatable<IBaseItem>, IComparable<IBaseItem>, INotifyPropertyChanged
    {
        ILifeCycle GetLifeCycle();
        IItemCollection GetMetadata(IRelationshipType relationshipType);
        IProperty GetPropertyMetadata(string dbColumnName);
        IRelationshipType GetRelationshipTypeMetadata(string relationshipTypeName);
        bool IsAncestorOf(IItemType itemType);
        bool IsDescendantOf(IItemType itemType);
        IProperty TryGetProperty(string dbColumnName);
        IProperty TryGetPropertyMetadata(string dbColumnName);
        IRelationshipType TryGetRelationshipType(string relationshipTypeName);
        IRelationshipType TryGetRelationshipTypeMetadata(string relationshipTypeName);

        bool Abstract { get; }

        IItemCollectionByItemType Ancestors { get; }

        IItemCollection AvailablePermissionItemMetadata { get; }

        IItemCollectionByItemType Children { get; }

        string ClassPath { get; }

        [Obsolete("客户端扩展元数据已废弃不用，请考虑用其他方式实现。")]
        IItemCollection ClientExtensionMetadata { get; }

        bool Core { get; }

        string DbTableName { get; }

        int? DefaultPageSize { get; set; }

        IItemCollectionByItemType Descendants { get; }

        string EntityClass { get; }

        string EntityClassAssembly { get; }

        Assembly EntityClassAssemblyAssembly { get; }

        Type EntityClassType { get; }

        IItemCollection FilterMetadata { get; }

        IFile Icon { get; }

        bool IsRelationship { get; }

        bool IsVersionable { get; }

        IItemCollection ItemLifeCycleMetadata { get; }

        [Obsolete("报表元数据已废弃不用，请考虑用其他方式实现。")]
        IItemCollection ItemReportMetadata { get; }

        IItemCollection ItemWorkflowMetadata { get; }

        string Label { get; }

        string LabelPlural { get; }

        string Name { get; }

        IItemType Parent { get; }

        IItemCollection PermissionMetadata { get; }

        IItemCollection PropertyMetadata { get; }

        IRelationshipType RelationshipType { get; }

        IItemCollection RelationshipTypeMetadata { get; }

        bool Sealed { get; }

        [Obsolete("服务端扩展元数据已废弃不用，请考虑用其他方式实现。")]
        IItemCollection ServerExtensionMetadata { get; }

        string StorageStrategy { get; set; }

        bool UnlockOnLogout { get; }
    }
}
