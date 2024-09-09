using System;
using System.Collections.Generic;

namespace VendorApp.Models;

public partial class Vendor
{
    public long Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string TradeName { get; set; } = null!;

    public string TaxId { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? WebsiteUrl { get; set; }

    public string PhysicalAddress { get; set; } = null!;

    public string Country { get; set; } = null!;

    public decimal? AnnualTurnover { get; set; }

    public DateTimeOffset? LastEdition { get; set; }
}
