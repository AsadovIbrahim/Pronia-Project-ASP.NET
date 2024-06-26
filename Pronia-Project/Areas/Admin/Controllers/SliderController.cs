﻿using Microsoft.AspNetCore.Mvc;
using Pronia_Project.Datas;
using Pronia_Project.Models;
using System;

namespace Pronia_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        ProductDbContext _context;

        public SliderController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sliders = _context.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            var existingSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existingSlider == null)
            {
                return NotFound();
            }

            existingSlider.Title = slider.Title;
            existingSlider.SubTitle = slider.SubTitle;
            existingSlider.ImgUrl = slider.ImgUrl;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}