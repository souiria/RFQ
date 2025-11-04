namespace Core.Extentions
{
    public static class CoreMappingExtentions
    {
        #region UserList
        public static UserListGrpc MapToListUsersGrpc(this DbUserList entity)
        {
            UserListGrpc data = new UserListGrpc();
            data.Username = entity.Username;
            data.FirstName = entity.FirstName;
            data.Surname = entity.Surname;
            data.Site = entity.Site;
            data.Logon = entity.Logon;
            data.LastLogin = entity.LastLogin.ToUniversalTime().ToTimestamp();
            data.FirstLogin = entity.FirstLogin.ToUniversalTime().ToTimestamp();
            data.Accesss = entity.Accesss;
            data.IsActive = entity.IsActive;
            data.Groups = entity.Groups;
            data.Id = entity.Id.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            data.EmailAddress = entity.EmailAddress;
            data.ActiveDirectoryDeactivationDate = entity.ActiveDirectoryDeactivationDate.ToUniversalTime().ToTimestamp();
            data.IsUserActive = entity.IsUserActive;
            data.IsAccountLocked = entity.IsAccountLocked;
            data.UserRoles = entity.UserRoles;
            data.CreationHelpDeskNumber = entity.CreationHelpDeskNumber;
            data.CreationHelpDeskDescription = entity.CreationHelpDeskDescription;
            data.CreationHelpDeskDate = entity.CreationHelpDeskDate.ToUniversalTime().ToTimestamp();
            data.LastHelpDeskNumber = entity.LastHelpDeskNumber;
            data.LastHelpDeskDescription = entity.LastHelpDeskDescription;
            data.LastHelpDeskDate = entity.LastHelpDeskDate.ToUniversalTime().ToTimestamp();
            data.IsH1User = entity.IsH1User;
            return data;
        }
        #endregion
    }
}
