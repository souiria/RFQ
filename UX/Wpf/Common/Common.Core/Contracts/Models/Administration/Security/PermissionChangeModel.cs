using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Security;

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <inheritdoc />
    /// <summary>
    /// A model used to track the changes in permissions for a user.
    /// </summary>
    [DataContract]
    public class PermissionChangeModel : BindableBaseEntity
    {
        /// <summary>
        /// Creates a new model with a random <see cref="Guid"/> Id. 
        /// </summary>
        public PermissionChangeModel()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Added = new PermissionChangeCollectionModel();
            Removed = new PermissionChangeCollectionModel();
        }

        /// <summary>
        /// Creates a new model with a random <see cref="Guid"/> Id, the <see cref="Guid"/> of the user being modified and the <see cref="Guid"/> of who it was created by.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="createdBy"></param>
        public PermissionChangeModel(Guid userGuid, Guid? createdBy) : this()
        {
            UserGuid = userGuid;
            CreatedBy = createdBy;
        }

        /// <summary>
        /// Creates a new model with a random <see cref="Guid"/> Id, the <see cref="Guid"/> of the user being modified and the <see cref="Guid"/> of who it was created by.
        /// It also takes a <see cref="PermissionChangeCollectionModel"/> for added permissions.
        /// </summary>
        /// <param name="userGuid">The <see cref="Guid"/> of the modified user.</param>
        /// <param name="createdBy">The <see cref="Guid"/> of the user who created this model.</param>
        /// <param name="added">A collection of permissions to be added.</param>
        public PermissionChangeModel(Guid userGuid, Guid? createdBy, PermissionChangeCollectionModel added) : this(userGuid, createdBy)
        {
            Added = added ?? throw new ArgumentNullException(nameof(added));
        }

        /// <summary>
        /// Creates a new model with a random <see cref="Guid"/> Id, the <see cref="Guid"/> of the user being modified and the <see cref="Guid"/> of who it was created by.
        /// It also takes a <see cref="PermissionChangeCollectionModel"/> for added and removed permissions.
        /// </summary>
        /// <param name="userGuid">The <see cref="Guid"/> of the modified user.</param>
        /// <param name="createdBy">The <see cref="Guid"/> of the user who created this model.</param>
        /// <param name="added">A collection of permissions to be added.</param>
        /// <param name="removed">A collection of permissions to be removed</param>
        public PermissionChangeModel(Guid userGuid, Guid? createdBy, PermissionChangeCollectionModel added, PermissionChangeCollectionModel removed) : this(userGuid, createdBy, added)
        {
            Removed = removed ?? throw new ArgumentNullException(nameof(removed));
        }

        private Guid _id;
        /// <summary>
        /// The unique Id for this model.
        /// </summary>
        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// The unique Id for the helpdesk call these permissions relate to.
        /// </summary>
        private string _helpdeskId;
        [DataMember]
        public string HelpdeskId
        {
            get => _helpdeskId;
            set => SetProperty(ref _helpdeskId, value);
        }

        /// <summary>
        /// A description of the changes to be made as part of the helpdesk call referenced with <see cref="HelpdeskId"/>
        /// </summary>
        [DataMember]
        public string HelpdeskDesc { get; set; }

        private Guid _userGuid;
        /// <summary>
        /// The unique Id of the user who is having their permissions being modified 
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private DateTime _createdDate;
        /// <summary>
        /// The date this model was created. This is assigned to <see cref="DateTime.UtcNow()"/> automatically during construction.
        /// </summary>
        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => SetProperty(ref _createdDate, value);
        }

        private Guid? _createdBy;
        /// <summary>
        /// The unique Id of the user who created this model. If this is left null, it indicates the model was created a service or system.
        /// </summary>
        [DataMember]
        public Guid? CreatedBy
        {
            get => _createdBy;
            set => SetProperty(ref _createdBy, value);
        }


        private PermissionChangeCollectionModel _added;
        /// <summary>
        /// A collection of the permissions that have been added as part of this model.
        /// </summary>
        [DataMember]
        public PermissionChangeCollectionModel Added
        {
            get => _added;
            set => SetProperty(ref _added, value);
        }

        private PermissionChangeCollectionModel _removed;
        /// <summary>
        /// A collection of the permissions that have been removed as part of this model.
        /// </summary>
        [DataMember]
        public PermissionChangeCollectionModel Removed
        {
            get => _removed;
            set => SetProperty(ref _removed, value);
        }
    }
}
