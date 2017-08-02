using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AbstractTunes.Data.Models;
using AbstractTunes.Data.Models.Accounts;
using AbstractTunes.Data.Models.Songs;
using AbstractTunes.Data.Storage;

namespace AbstractTunes.UI.Controllers
{
    public class SongController : Controller
    {
        private readonly SongDataStore _songDataProvider;

        public SongController()
        {
            var accountSubscriptionType = AccountSubscriptionType.Standard;

            _songDataProvider = new SongDataStore(accountSubscriptionType);
        }

        // GET: Song
        public ActionResult Index()
        {
            var songs = _songDataProvider.GetAllSongs();

            return View(songs);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            var song = _songDataProvider.GetSong(id);

            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(Song song)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var audioFilePath = Server.MapPath("~/App_Data/Default.mp3");

            song.File.FileBytes = System.IO.File.ReadAllBytes(audioFilePath);
            song.File.Type = AudioFileType.Mp3;
            song.File.Name = $"{song.Metadata.Title}.{song.File.Type}";

            _songDataProvider.SaveSong(song);

            return RedirectToAction("Index");
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            var song = _songDataProvider.GetSong(id);

            return View(song);
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _songDataProvider.UpdateSong(id, song);

            return RedirectToAction("Index");
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _songDataProvider.DeleteSong(id);

            return RedirectToAction("Index");
        }
    }
}
