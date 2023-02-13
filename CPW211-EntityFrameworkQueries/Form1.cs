using CPW211_EntityFrameworkQueries.Models;
using System.Linq;

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
    }
}