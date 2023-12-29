using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TenantPropertyMngt.Models;
using TenantPropertyMngt.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TenantPropertyMngt.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static NuGet.Client.ManagedCodeConventions;
using Microsoft.AspNetCore.Authorization;

namespace TenantPropertyMngt.Pages.Agent.Lease
{
    [Authorize(Roles ="agent")]
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly TenantPropertyMngtDbContext context;

        [BindProperty]
        public int SelectedTenantID { get; set; }

        public SelectList TenantList { get; set; }

        public SelectList PropertyList { get; set; }

        [BindProperty]
        public LeaseDto LeaseDto { get; set; } = new LeaseDto();
        public LeaseModel LeaseModel { get; set; }= new LeaseModel();
        public string errorMessage = "";
        public string successMessage = "";

        public CreateModel(IWebHostEnvironment environment, TenantPropertyMngtDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            try
            {
                var tenants = context.Tenants
                    .Include(t => t.AssociatedProperty)
                    .Select(t => new SelectListItem
                    {
                        Value = t.TenantID.ToString(),
                        Text = $"{t.TenantID}, {t.TenantName},{t.IdCard}, {t.Email}, {t.Telephone} "
                    })
                    .ToList();

                var properties = context.Properties
                    .Where(p => p.Status != "Occupied")
                    .Select(p => new SelectListItem
                    {
                        Value = $"{p.PropertyID}, {p.PropertyName}, {p.Rent}",
                        Text = $"{p.PropertyID}, {p.PropertyName}, {p.Rent}"
                    })
                    .ToList();

                if (tenants != null && properties != null)
                {
                    ViewData["Tenants"] = tenants;
                    ViewData["Properties"] = properties;
                }
                else
                {

                    ViewData["Tenants"] = new List<SelectListItem>();
                    ViewData["Properties"] = new SelectList(properties, "Value", "Text");
                }

            }
            catch (Exception ex)
            {
                ViewData["Tenants"] = new List<SelectListItem>();
                ViewData["Properties"] = new List<SelectListItem>();
                Console.WriteLine($"Exception in OnGet method: {ex.Message}");
            }

            return Page();
        }

        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Please provide all the required fields";
                    return Page();
                }

                var selectedTenant = await context.Tenants
                    .Include(t => t.AssociatedProperty)
                    .FirstOrDefaultAsync(t => t.TenantID == LeaseDto.TenantID);

                if (selectedTenant == null)
                {
                    ModelState.AddModelError(string.Empty, "Please select a valid tenant");
                    return Page();
                }

                var selectedProperty = await context.Properties.FirstOrDefaultAsync(p => p.PropertyID == LeaseDto.PropertyID);

                if (selectedProperty == null)
                {
                    ModelState.AddModelError(string.Empty, "Please select a valid property");
                    return Page();
                }

                // Check if the selected property has a vacant status
                if (selectedProperty.Status != "Vacant")
                {
                    ModelState.AddModelError(string.Empty, "Selected property is not vacant");
                    return Page();
                }

                // Update tenant's associated property
                selectedTenant.PropertyID = LeaseDto.PropertyID;
                selectedTenant.AssociatedProperty ??= new List<PropertyModel>();

                // Create a new lease
                LeaseModel lease = new LeaseModel()
                {
                    LeaseType = LeaseDto.LeaseType,
                    PropertyID = selectedProperty.PropertyID,
                    PropertyName = LeaseDto.PropertyName,
                    Rent = LeaseDto.Rent,
                    Email = LeaseDto.Email,             
                    Telephone = LeaseDto.Telephone,
                    TenantID = selectedTenant.TenantID,
                    TenantName = LeaseDto.TenantName,
                    IdCard = LeaseDto.IdCard,
                    StartDate = LeaseDto.StartDate,
                    EndDate = LeaseDto.EndDate,
                    Status = LeaseDto.Status
                };
                // Add lease to context and save changes
                context.Leases.Add(lease);
                await context.SaveChangesAsync();

                selectedProperty.Status = "Occupied";
                await context.SaveChangesAsync();

                SuccessMessage = "Lease created successfully";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in OnPost: {ex}");
                ErrorMessage = "An error occurred while processing your request.";
                return Page();
            }
        }

    }
}


