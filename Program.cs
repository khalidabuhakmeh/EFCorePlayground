// See https://aka.ms/new-console-template for more information

using EFCorePlayground;
using EFCorePlayground.Models;
using Microsoft.EntityFrameworkCore;

var db = new Database();

// all advocates
var all = db.Advocates.ToList();

// The humble `Where` clause
var maarten = db
    .Advocates
    .Where(a => a.Id == 1)
    .ToList();

// multiple conditions are "AND" operations
var riderAndResharper = db
    .Advocates
    .Where(a => a.Products.Contains("Rider"))
    .Where(a => a.Products.Contains("ReSharper"))
    .ToList();

// what about OR operations?
var dotnetOrRust = db
    .Advocates
    .Where(a => 
        a.Technologies.Contains("Rust") ||
        a.Technologies.Contains(".NET")
    )
    .ToList();

// what about && ?
var dotnetOrRustWithAnd = db
    .Advocates
    .Where(a => 
        a.Technologies.Contains("Rust") &&
        a.Technologies.Contains(".NET")
    )
    .ToList();

// Extra homework: An extension method
var riderOrIntelliJ = db
    .Advocates
    .Where(a => a.Technologies.Length > 0)
    .Or(
        a => a.Products.Contains("Rider"),
        a => a.Products.Contains("IntelliJ")
    )
    .ToList();

// what about database functions?
var mAdvocates = db
    .Advocates
    .Where(a => EF.Functions.Like(a.Name, "M%"))
    .ToList();
    
// filter in memory?
bool ProductEndsWithEr(string product)
    => product.EndsWith("er");

var erProducts = db
    .Advocates
    .ToList() // execute SQL (all records)
    // in memory now
    .Where(a => a.Products.Any(ProductEndsWithEr))
    .ToList();
    
// conditional filtering
var random = Random.Shared.Next(1, 10) > 5;

var conditional = db
    .Advocates
    .If(random, q => 
        q.Where(a => a.Name.StartsWith("K"))
    )
    .ToList();