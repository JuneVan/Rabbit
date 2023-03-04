﻿global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Debug;
global using Rabbit.Authorization;
global using Rabbit.Domain;
global using Rabbit.Domain.Auditing;
global using Rabbit.EntityFrameworkCore;
global using Rabbit.EntityFrameworkCore.Extensions;
global using Rabbit.Events;
global using Rabbit.Reflections;
global using Rabbit.Threading;
global using System.Data;
global using System.Linq.Expressions;
global using System.Reflection;