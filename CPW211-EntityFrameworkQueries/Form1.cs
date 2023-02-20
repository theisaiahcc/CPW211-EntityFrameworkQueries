using CPW211_EntityFrameworkQueries.Models;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;

namespace CPW211_EntityFrameworkQueries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectAllVendors_Click(object sender, EventArgs e)
        {
            using ApContext dbContext= new ApContext();

            List<Vendor> vendorList = dbContext.Vendors.ToList();
        }

        private void btnAllCaliVendors_Click(object sender, EventArgs e)
        {
            using ApContext dbContext = new ApContext();

            List<Vendor> vendorList  = dbContext.Vendors
                                            .Where(v => v.VendorState == "CA")
                                            .OrderBy(v => v.VendorState)
                                            .ToList();
        }

        private void btnSelectSpecificColumns_Click(object sender, EventArgs e)
        {
            using ApContext dbContext = new ApContext();

            // anonymous type
            List<VendorLocation> results = (from v in dbContext.Vendors
                          select new VendorLocation
                          { 
                              VendorName = v.VendorName,
                              VendorState = v.VendorState, 
                              VendorCity = v.VendorCity 
                          }).ToList();
            
            StringBuilder displayString = new StringBuilder();
            foreach ( var v in results )
            {
                displayString.AppendLine($"{v.VendorName} is in {v.VendorCity}");
            }

            MessageBox.Show(displayString.ToString());
        }

        private void btnMiscQueries_Click(object sender, EventArgs e)
        {
            ApContext dbContext = new ApContext();

            bool doesExist = (from v in dbContext.Vendors
                              where v.VendorState == "WA"
                              select v).Any();

            int InvoiceCount = (from invoice in dbContext.Invoices
                                select invoice).Count();

            // Query a single vendor
            Vendor ? singleVendor = (from v in dbContext.Vendors
                                     where v.VendorName == "IBM"
                                     select v).SingleOrDefault();
            if ( singleVendor != null )
            {
                // do something
            }
        }

        private void btnVendorsAndInvoices_Click(object sender, EventArgs e)
        {
            ApContext dbContext = new();

            // vendors left join
            List<Vendor> allVendors = dbContext.Vendors.Include(v => v.Invoices).ToList();
                                      /*(from v in dbContext.Vendors
                                      join inv in dbContext.Invoices
                                        on v.VendorId equals inv.VendorId into grouping
                                      from inv in grouping.DefaultIfEmpty()
                                      select v).ToList();*/

            StringBuilder results = new StringBuilder();

            foreach( Vendor v in allVendors )
            {
                results.Append(v.VendorName);
                foreach (Invoice inv in v.Invoices)
                {
                    results.Append(", ");
                    results.Append(inv.InvoiceNumber);
                }
                results.AppendLine();
            }
            MessageBox.Show(results.ToString());
        }
        
    }

    class VendorLocation
    {
        public string VendorName { get; set; }
        public string VendorState { get; set; }
        public string VendorCity { get; set; }
    }
}