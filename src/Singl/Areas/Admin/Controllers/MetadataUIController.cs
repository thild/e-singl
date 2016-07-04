using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Singl.Areas.Admin.ViewModels;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class MetadataUIController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: MetadataUI
        [HttpGet()]
        public IActionResult Index(Guid? modelId, Guid? id)
        {
            if (modelId == null)
            {
                return new StatusCodeResult(404);
            }

            var list = db.MetadataUI.Where(m => m.ModelId == modelId);
            if (list == null)
            {
                list = new List<MetadataUI>().AsQueryable();
            }

            var metadata = id == null ? new MetadataUI { ModelId = modelId.Value } :
                db.MetadataUI.SingleOrDefault(m => m.Id == id.Value);

            var vm = new MetadataUIViewModel
            {
                Metadata = metadata,
                MetadataList = list
            };

            return View(vm);
        }

        // GET: MetadataUI/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            var metadataUI = db.MetadataUI
                .Single(m => m.Id == id);

            if (metadataUI == null)
            {
                return new StatusCodeResult(404);
            }

            return View(metadataUI);
        }

        // GET: MetadataUI/Create
        [Route("Create")]
        public IActionResult Create(Guid? modelId)
        {
            if (modelId == null)
            {
                return new StatusCodeResult(404);
            }
            return View(new MetadataUI { ModelId = modelId.Value });
        }

        // POST: MetadataUI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public IActionResult Create(MetadataUIViewModel metadataUI)
        {
            if (ModelState.IsValid)
            {
                if (db.MetadataUI.Any(m => m.Id == metadataUI.Metadata.Id))
                {
                    db.MetadataUI.Update(metadataUI.Metadata);
                }
                else
                {
                    db.MetadataUI.Add(metadataUI.Metadata);
                }
                db.SaveChanges();
            }

            return Redirect($"/Admin/MetadataUI/?modelId={metadataUI.Metadata.ModelId}");
        }

        // GET: MetadataUI/Edit/5
        [Route("[action]/{id}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            var metadataUI = db.MetadataUI
                .Single(m => m.Id == id);
            if (metadataUI == null)
            {
                return new StatusCodeResult(404);
            }

            return View(metadataUI);
        }

        // POST: MetadataUI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]

        public IActionResult Edit(MetadataUI metadataUI)
        {
            if (ModelState.IsValid)
            {
                db.Update(metadataUI);
                db.SaveChanges();
                //return Redirect(Request.Headers["Referer"]);
                return RedirectToAction("Index", new { modelId = metadataUI.ModelId });
            }
            return View(metadataUI);
        }

        // GET: MetadataUI/Delete/5
        [ActionName("Delete")]
        [Route("[action]")]
        public IActionResult Delete(Guid? modelId, Guid? id)
        {
            if (modelId == null)
            {
                return new StatusCodeResult(404);
            }
            var metadataUI = db.MetadataUI.Single(m => m.Id == id);
            db.MetadataUI.Remove(metadataUI);
            db.SaveChanges();
            return Redirect($"/Admin/MetadataUI/?modelId={modelId}");
        }
    }
}
