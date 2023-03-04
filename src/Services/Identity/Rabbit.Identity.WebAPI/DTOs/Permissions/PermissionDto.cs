﻿namespace Rabbit.Identity.WebAPI.DTOs.Permissions
{
    public class PermissionDto : EntityDto
    {
        /// <summary>
        /// 权限名称（唯一标识符）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 上级权限
        /// </summary>
        public int? ParentId { get; set; }
    }
}
