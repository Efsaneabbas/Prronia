﻿using Microsoft.AspNetCore.Mvc;
using ProniaBusiness.Exceptions;
using ProniaBusiness.Services.Abstracts;
using PrroniaCore.Models;
using FileNotFoundException = ProniaBusiness.Exceptions.FileNotFoundException;

namespace Prronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSliders();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _sliderService.AddSlider(slider);
            }
            catch (ImageContextTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNullReferenceException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);
            if (existSlider == null) return NotFound();
            return View(existSlider);
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _sliderService.UpdateSlider(slider.Id, slider);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContextTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);
            if (existSlider == null) return NotFound();
            return View(existSlider);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _sliderService.DeleteSlider(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }


    }
}
