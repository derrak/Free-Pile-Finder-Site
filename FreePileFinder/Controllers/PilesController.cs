
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreePileFinder.Models;

namespace FreePileFinder.Controllers
{
  public class PilesController : Controller
  {
    public IActionResult Index()
    {
      var allPiles = Pile.GetPiles();
      return View(allPiles);
    }

    [HttpPost]
    public IActionResult Index(Pile pile)
    {
      Pile.Post(pile);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var pile = Pile.GetDetails(id);
      return View(pile);
    }

    public IActionResult Edit(int id)
    {
      var pile = Pile.GetDetails(id);
      return View(pile);
    }

    [HttpPost]
    public IActionResult Details(int id, Pile pile)
    {
      pile.PileId = id;
      Pile.Put(pile);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Pile.Delete(id);
      return RedirectToAction("Index");
    }
  }}
