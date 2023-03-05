﻿global using Dapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Npgsql;
global using Rabbit.Application.Dtos;
global using Rabbit.AspNetCore.JwtTokens;
global using Rabbit.Authorization.Permissions;
global using Rabbit.Cryptography;
global using Rabbit.Domain;
global using Rabbit.Identity.AggregateModels.PermissionAggregate;
global using Rabbit.Identity.AggregateModels.RoleAggregate;
global using Rabbit.Identity.AggregateModels.UserAggregate;
global using Rabbit.Identity.Infrastructure;
global using Rabbit.Identity.Infrastructure.EntityFrameworkCore;
global using Rabbit.Identity.WebAPI;
global using Rabbit.Identity.WebAPI.Application.Commands.Account;
global using Rabbit.Identity.WebAPI.Application.Commands.Permissions;
global using Rabbit.Identity.WebAPI.Application.Commands.Roles;
global using Rabbit.Identity.WebAPI.Application.Commands.Users;
global using Rabbit.Identity.WebAPI.Application.Queries.Models;
global using System.Security.Claims;
