using System;
using System.Collections.Generic;

namespace CPW211_EntityFrameworkQueries.Models;

public partial class Term
{
    public int TermsId { get; set; }

    public string TermsDescription { get; set; } = null!;

    public short TermsDueDays { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Vendor> Vendors { get; } = new List<Vendor>();
}
