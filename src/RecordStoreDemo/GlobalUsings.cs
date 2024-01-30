global using Ardalis.GuardClauses;
global using Ardalis.ApiEndpoints;
global using Swashbuckle.AspNetCore.Annotations;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

global using System.ComponentModel.DataAnnotations;
global using System.Net;
global using System.Net.Http.Json;
global using System.Text.RegularExpressions;

global using RecordStoreDemo.Common;
global using RecordStoreDemo.Common.Constants;
global using RecordStoreDemo.Common.Exceptions;
global using RecordStoreDemo.Common.Models;
global using RecordStoreDemo.Common.Validation;
global using RecordStoreDemo.Common.ValueObjects;

global using RecordStoreDemo.Features.Customers.Profiles;
global using RecordStoreDemo.Features.Customers.Rewards;
global using RecordStoreDemo.Features.Customers.SpecialOrders;
global using RecordStoreDemo.Features.Inventory.Products;
global using RecordStoreDemo.Features.Purchasing.Catalogs;
global using RecordStoreDemo.Features.Purchasing.PurchaseOrders;
global using RecordStoreDemo.Features.Purchasing.Vendors;
global using RecordStoreDemo.Features.Receiving;
global using RecordStoreDemo.Features.Webstore;
global using RecordStoreDemo.Features.Webstore.Collections;
global using RecordStoreDemo.Features.Webstore.MetaFields;
global using RecordStoreDemo.Features.Webstore.Products;
global using RecordStoreDemo.Features.Webstore.Products.Images;

global using RecordStoreDemo.Persistence;
global using RecordStoreDemo.Persistence.Repositories;