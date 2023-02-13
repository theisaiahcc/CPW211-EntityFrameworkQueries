using System;
using System.Collections.Generic;

namespace CPW211_EntityFrameworkQueries.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int VendorId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public decimal InvoiceTotal { get; set; }

    public decimal PaymentTotal { get; set; }

    public decimal CreditTotal { get; set; }

    public int TermsId { get; set; }

    public DateTime InvoiceDueDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; } = new List<InvoiceLineItem>();

    public virtual Term Terms { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
