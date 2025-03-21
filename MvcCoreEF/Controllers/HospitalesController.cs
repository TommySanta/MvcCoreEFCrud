﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Models;
using MvcCoreEF.Repositories;

namespace MvcCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospital repo;
        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> Details(int idhospital)
        {
            Hospital hospital = await this.repo.FindHospitalAsync(idhospital);
            return View(hospital);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hospital hospital)
        {
            await this.repo.InsertHospitalAsync(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int idhospital)
        {
            await this.repo.DeleteHospitalAsync(idhospital);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int idhospital)
        {
            Hospital hospital = await this.repo.FindHospitalAsync(idhospital);
            return View(hospital);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Hospital hospital)
        {
            await this.repo.UpdateHospitalAsync(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }
    }
}
