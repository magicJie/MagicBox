using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.ItemCore
{
    public interface IBaseItem
    {
        void Accept();

        void AfterCreated();

        void AfterDeleted();

        void AfterNewed();

        void AfterReplicated(IBaseItem baseItem);

        void AfterSaved();

        void AfterResetedProperty<T>(String dbColumnName,T value);
        void AfterTransitState(ILifeCycleTransition transition);
        void Afterupdated();
        bool ContainsAttribute(string name);
        bool ContainsProperty(string dbColumnName);
        void Delete();
        IAttribute GetAttribute(string name);
        IRIC GetAttributes();
        object GetProperty(string dbColumnName);
        T GetProperty<T>(string dbColumnName);
        object GetProperty(string dbColumnName, ItemDataVersion version);
        T GetProperty<T>(string dbColumnName, ItemDataVersion version);
        bool IsEqualTo(IBaseItem item);
        bool IsExists();
        bool IsInstanceOf(IItemType itemType);
        bool IsModifiedProperty(string dbColumnName);
        bool IsReadonlyProperty(string dbColumnName);
        bool IsWritableProperty(string dbColumnName);
        void Load();
        IBaseItem MoveTo(IItemType destination);
        bool Precreating();
        bool Predeleting();
        bool Presaving();
        bool PresettingProperty<T>(string dbColumnName, T value);
        bool PretransitState(ILifeCycleTransition transition);
        bool Preupdating();
        void Refresh();
        IBaseItem Replicate();
        IBaseItem Replicate(IItemCollection relationshipItems);
        void Reset();
        void Save();
        bool SetProperty(string dbColumnName, object value);
        bool SetProperty<T>(string dbColumnName, T value);
        bool TransitState(ILifeCycleTransition transition);
        void Verify();

        IBaseItem Config { get; set; }

        DateTime? CreatedOn { get; }

        IUser Creator { get; }

        IBaseItem Decorated { get; }

        int? Generation { get; set; }

        string Id { get; }

        bool IsCurrent { get; set; }

        bool IsDeleting { get; }

        bool IsDetached { get; }

        bool IsReleased { get; set; }

        object this[string columnName] { get; set; }

        object this[string columnName, ItemDataVersion version] { get; }

        Wisense.Common.Item.ItemRef ItemRef { get; }

        Wisense.Common.Item.ItemState ItemState { get; }

        IItemType ItemType { get; }

        string ItemTypeId { get; set; }

        string Key { get; }

        string KeyedName { get; }

        IUser Locker { get; set; }

        string MajorRev { get; set; }

        IIdentity Manager { get; set; }

        string MinorRev { get; set; }

        IUser Modificator { get; }

        DateTime? ModifiedOn { get; }

        bool NewVersion { get; set; }

        bool NotLockable { get; set; }

        IIdentity Owener { get; }

        IPermission Permission { get; }

        IRICC RICC { get; }

        ILifeCycleState State { get; set; }
    }
}
