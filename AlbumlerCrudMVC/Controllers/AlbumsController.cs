using Microsoft.AspNetCore.Mvc;
using Albums.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlbumlerCrudMVC.Controllers
{
    public class AlbumsController : Controller
    {
        private static List<Album> _albums = new List<Album>
        {
            new Album { Id = 1, Title = "Album 1", Artist = "Artist 1", Year = 2020 },
            new Album { Id = 2, Title = "Album 2", Artist = "Artist 2", Year = 2019 },
            new Album { Id = 3, Title = "Album 3", Artist = "Artist 3", Year = 2021 },
            new Album { Id = 4, Title = "Sen Olsan Bari", Artist = "Aleyna Tilki", Year = 2017 },
            new Album { Id = 5, Title = "Cevapsız Çınlama", Artist = "Mabel Matiz", Year = 2015 },
            new Album { Id = 6, Title = "Bir Derdim Var", Artist = "Murat Boz", Year = 2013 }
        };

        public IActionResult Index()
        {
            return View(_albums);
        }

        public IActionResult Details(int id)
        {
            var album = _albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                album.Id = _albums.Max(a => a.Id) + 1;
                _albums.Add(album);
                return RedirectToAction("Index");
            }

            return View(album);
        }

        public IActionResult Edit(int id)
        {
            var album = _albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                var existingAlbum = _albums.FirstOrDefault(a => a.Id == album.Id);
                if (existingAlbum == null)
                {
                    return NotFound();
                }

                existingAlbum.Title = album.Title;
                existingAlbum.Artist = album.Artist;
                existingAlbum.Year = album.Year;

                return RedirectToAction("Index");
            }

            return View(album);
        }

        public IActionResult Delete(int id)
        {
            var album = _albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var album = _albums.FirstOrDefault(a => a.Id == id);
            if (album != null)
            {
                _albums.Remove(album);
            }

            return RedirectToAction("Index"); // Albümler listesine geri dön
        }


    }
}
