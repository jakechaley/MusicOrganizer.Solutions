using Microsoft.AspNetCore.Mvc;
using Organizer.Models;
using System.Collections.Generic;

namespace Organizer.Controllers
{
  public class AlbumController : Controller
  {
    [HttpGet("/albums")]
    public ActionResult Index()
    {
      List<Album> allAlbums = Album.GetAll();
      return View(allAlbums);
    }

    [HttpGet("/albums/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/albums")]
    public ActionResult Create(string title, string artist)
    {
      Album myAlbum = new Album(title, artist);
      return RedirectToAction("Index");
    }

    [HttpPost("/albums/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }

    [HttpGet("/albums/{id}")]
    public ActionResult Show(int id)
    {
      Album foundAlbum = Album.Find(id);
      return View(foundAlbum);
    }
  }
}