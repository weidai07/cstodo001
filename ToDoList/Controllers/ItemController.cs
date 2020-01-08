using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);
      return RedirectToAction("Index");
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [Route("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item theItem = Item.Find(id);
      return View(theItem);
    }

    [HttpGet("/items/destroy/{id}")]
    public ActionResult Destroy(int id)
    {
      Item.DestroyItem(id);
      return RedirectToAction("Index");
    }

    // [HttpGet("/items/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Item theItem = Item.Find(id);
    //   return View(theItem);
    // }


  }
}