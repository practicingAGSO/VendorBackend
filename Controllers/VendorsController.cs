﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorApp.Context;
using VendorApp.Models;

namespace VendorApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly VendorDbContext _context;

        public VendorsController(VendorDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return await _context.Vendors.OrderBy(p=> p.LastEdition).ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(long id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }
            vendor.LastEdition = DateTimeOffset.UtcNow;

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(long id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(long id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(long id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}
