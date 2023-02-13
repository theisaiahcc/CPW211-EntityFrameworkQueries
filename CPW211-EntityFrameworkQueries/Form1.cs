using CPW211_EntityFrameworkQueries.Models;

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
    }
}