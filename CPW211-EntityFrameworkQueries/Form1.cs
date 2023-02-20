using CPW211_EntityFrameworkQueries.Models;
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
    }

    class VendorLocation
    {
        public string VendorName { get; set;}
        public string VendorState { get; set;}
        public string VendorCity { get; set;}
}