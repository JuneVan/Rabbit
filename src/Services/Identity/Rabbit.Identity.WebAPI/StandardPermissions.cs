namespace Rabbit.Identity.WebAPI
{
    public static class StandardPermissions
    {
        #region Permissions
        public const string Permissions = "Rabbit.Identity.Permissions";
        public const string Permissions_Create = "Rabbit.Identity.Permissions.Create";
        public const string Permissions_Update = "Rabbit.Identity.Permissions.Update";
        public const string Permissions_Delete = "Rabbit.Identity.Permissions.Delete";
        #endregion

        #region Roles
        public const string Roles = "Rabbit.Identity.Roles";
        public const string Roles_Create = "Rabbit.Identity.Roles.Create";
        public const string Roles_Update = "Rabbit.Identity.Roles.Update";
        public const string Roles_Delete = "Rabbit.Identity.Roles.Delete";
        #endregion

        #region Users
        public const string Users = "Rabbit.Identity.Users";
        public const string Users_Create = "Rabbit.Identity.Users.Create";
        public const string Users_Update = "Rabbit.Identity.Users.Update";
        public const string Users_Delete = "Rabbit.Identity.Users.Delete";
        #endregion
    }
}
