﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Data;
using Garage_2._0.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace Garage_2._0.Controllers
{
    public class VehicleController_old : Controller
    {
        private readonly Garage_2_0Context _context;
        public readonly uint _capacity = 9;

        public VehicleController_old(Garage_2_0Context context)
        {
            _context = context;
        }

        // GET: Vehicle2
        public async Task<IActionResult> Index() 
        {
            if (_context.Vehicle_old != null)
            {
                var vehicles = await _context.Vehicle_old.ToListAsync();
                //ViewData["NrOfParkedVehicles"] = vehicles.Count;

                if (vehicles.Count == _capacity) ViewData["NrOfAvailableSlots"] = "The garage is full";
                else ViewData["NrOfAvailableSlots"] = _capacity - vehicles.Count;

                return View(vehicles);
            }
            else return Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");

            //return _context.Vehicle2 != null ?
            //            View(await _context.Vehicle2.ToListAsync()) :
            //            Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");
        }

        public async Task<IActionResult> Index2(string searchString)
        {
            var vehicles = from m in _context.Vehicle_old
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.RegNr!.Contains(searchString));
            }

            return View(nameof(Index), await vehicles.ToListAsync());
        }

        // GET: Vehicle2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle_old == null)
            {
                return NotFound();
            }

            var vehicle2 = await _context.Vehicle_old
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle2 == null)
            {
                return NotFound();
            }

            return View(vehicle2);
        }

        // GET: Vehicle2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,VehicleType,Make,Model,Color,NrOfWheels")] Vehicle_old vehicle)
        {
            //if (RegNumExists(vehicle2.RegNr))
            //    ModelState.AddModelError("RegNr", "RegNr is already in the garage.");
            // return Problem("RegNr is already in the garage.");

            var vehicles = await _context.Vehicle_old.ToListAsync();

            if(vehicles.Count == _capacity)
                return Problem("Garage is Full");

            if (ModelState.IsValid)
            {
                vehicle.RegNr = vehicle.RegNr.ToUpper();
                vehicle.ParkingLot = GetParkingLot();

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Vehicle with registration number {vehicle.RegNr} has been parked";
                return RedirectToAction(nameof(Index));
                
            }
            return View(vehicle);
        }

        // GET: Vehicle2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle_old == null) return NotFound();

            var vehicle = await _context.Vehicle_old.FindAsync(id);
            if (vehicle == null) return NotFound();

            var viewModel = new EditVehicleViewModel
            {
                Id = vehicle.Id,
                ParkingLot = vehicle.ParkingLot,
                RegNr = vehicle.RegNr,
                VehicleType = vehicle.VehicleType,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle.Color,
                NrOfWheels = vehicle.NrOfWheels,
                TimeOfArrival = vehicle.TimeOfArrival
            };
            
            //var viewModel = new EditVehicleViewModel
            //{
            //    RegNo = vehicle2.RegNr,
            //};

            return View(viewModel);
        }

        // POST: Vehicle2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("Id,ParkingLot,RegNr,VehicleType,Make,Model,Color,NrOfWheels")]*/ EditVehicleViewModel vehicleView)
        {
            if (id != vehicleView.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = new Vehicle_old
                    {
                        Id = vehicleView.Id,
                        ParkingLot = vehicleView.ParkingLot,
                        RegNr = vehicleView.RegNr,
                        VehicleType = vehicleView.VehicleType,
                        Make = vehicleView.Make,
                        Model = vehicleView.Model,
                        Color = vehicleView.Color,
                        NrOfWheels = vehicleView.NrOfWheels,
                        TimeOfArrival = vehicleView.TimeOfArrival
                    };
                    
                    _context.Update(vehicle);
                    _context.Entry(vehicle).Property(v => v.TimeOfArrival).IsModified = false;
                    _context.Entry(vehicle).Property(v => v.RegNr).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicleView.Id)) return NotFound();
                    else throw;
                }
                TempData["Message"] = $"Vehicle has been rebuilt";
                return RedirectToAction(nameof(Index));
            }

            return View(vehicleView);
        }

        // GET: Vehicle2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle_old == null) return NotFound();

            var vehicle2 = await _context.Vehicle_old
                .FirstOrDefaultAsync(m => m.Id == id);

            if(vehicle2 == null) return NotFound();

            TimeSpan timespan = new TimeSpan();
            timespan = DateTime.Now.Subtract(vehicle2.TimeOfArrival);
            double cost = timespan.TotalMinutes * 0.9;

            int i = timespan.ToString().IndexOf(".");
            ViewBag.TimeParked = timespan.ToString().Remove(i);

            i = cost.ToString().IndexOf(",");
            ViewBag.Cost = cost.ToString().Remove(i + 3);

            return View(vehicle2);
        }

        // POST: Vehicle2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle_old == null)
            {
                return Problem("Entity set 'Garage_2_0Context.Vehicle2'  is null.");
            }
            var vehicle2 = await _context.Vehicle_old.FindAsync(id);
            if (vehicle2 != null)
            {
                _context.Vehicle_old.Remove(vehicle2);
            }
            
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Vehicle has exited the garage";
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicle_old?.Any(e => e.Id == id)).GetValueOrDefault();
        }
  
        [HttpGet]
        public JsonResult ValidateRegNum(string regnr)
        {
            var r = new Regex("[A-Z][A-Z][A-Z][1-9][1-9][1-9]");
            if (!r.IsMatch(regnr.ToUpper()))
            {
                return Json("Invalid RegNr format");
            }
            else if ((_context.Vehicle_old?.Any(r => r.RegNr.ToUpper() == regnr.ToUpper())).GetValueOrDefault())
            {
                return Json("RegNr is already in the garage");
            }

            return Json(true);
        }

        private int GetParkingLot()
        {
            var vehicles = _context.Vehicle_old.ToList();
            int parkingLot = 0, i = 1;

            foreach (var vehicle in vehicles.OrderBy(p => p.ParkingLot).ToList())
            {
                if (vehicle.ParkingLot > parkingLot + 1) return parkingLot + 1;

                parkingLot = vehicle.ParkingLot;
                i++;
            }

            return i;
        }


        public async Task<IActionResult> Statistics()
        {
            if (_context.Vehicle_old == null)
            {
                return NotFound();
            }

            var totalCount = await Statistics_1_Async();
            var totalCount2 = await Statistics_2_Async();
            
            if (totalCount == null)
            {
                return NotFound();
            }

            var model = new StatisticsViewModel
            {
                VehicleCount = totalCount,
                VehiclesNoOfWheels = totalCount2
            };
            
            return View(model);
        }

        private async Task<List<VehicleCountDto>> Statistics_1_Async()
        {
            return await _context.Vehicle_old.GroupBy(v => v.VehicleType)
                                                 .Select(vt => new VehicleCountDto
                                                 {
                                                     VehicleType = vt.Key,
                                                     Total = vt.Count()
                                                 }).ToListAsync();
        }

        private async Task<int> Statistics_2_Async()
        {
            return _context.Vehicle_old.Sum(v => v.NrOfWheels);                                            
        }
    }
}