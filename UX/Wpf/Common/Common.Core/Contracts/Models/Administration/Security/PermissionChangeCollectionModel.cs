using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Security;

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <summary>
    /// A collection of <see cref="ModuleOwnerModel"/>s, <see cref="Group"/>s, <see cref="ViewHierarchyModel"/>s and <see cref="FieldHierarchyModel"/>s that changes in permissions.
    /// </summary>
    [DataContract]
    public class PermissionChangeCollectionModel : BindableBaseEntity
    {
        /// <summary>
        /// Creates an new empty model.
        /// </summary>
        public PermissionChangeCollectionModel()
        {
            Roles = new List<Group>();
            Views = new List<ViewHierarchyModel>();
            Fields = new List<FieldHierarchyModel>();
            OwnedModules = new List<ModuleOwnerModel>();
        }

        /// <summary>
        /// Creates a new model with changed roles assigned.
        /// </summary>
        /// <param name="roles">The list of modified roles.</param>
        public PermissionChangeCollectionModel(List<Group> roles) : this()
        {
            Roles = roles;
        }

        /// <summary>
        /// Creates a new model with changed views and fields assigned.
        /// </summary>
        /// <param name="views">The list of modified views.</param>
        /// <param name="fields">The list of modified fields.</param>
        public PermissionChangeCollectionModel(List<ViewHierarchyModel> views, List<FieldHierarchyModel> fields) : this()
        {
            Views = views;
            Fields = fields;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="views"></param>
        /// <param name="fields"></param>
        /// <param name="ownedModules"></param>
        public PermissionChangeCollectionModel(List<Group> roles, List<ViewHierarchyModel> views,
            List<FieldHierarchyModel> fields, List<ModuleOwnerModel> ownedModules)
        {
            Roles = roles;
            Views = views;
            Fields = fields;
            OwnedModules = ownedModules;
        }

        private List<Group> _roles;
        [DataMember]
        public List<Group> Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
        }

        private List<ViewHierarchyModel> _views;
        [DataMember]
        public List<ViewHierarchyModel> Views
        {
            get => _views;
            set => SetProperty(ref _views, value);
        }

        private List<FieldHierarchyModel> _fields;
        [DataMember]
        public List<FieldHierarchyModel> Fields
        {
            get => _fields;
            set => SetProperty(ref _fields, value);
        }

        private List<ModuleOwnerModel> _ownedModules;
        [DataMember]
        public List<ModuleOwnerModel> OwnedModules
        {
            get => _ownedModules;
            set => SetProperty(ref _ownedModules, value);
        }
    }
}
