namespace Tally
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void createCompanyButton_Click(object sender, EventArgs e)
        {
            CreateCompanyForm createCompany = new CreateCompanyForm();
            createCompany.ShowDialog();
        }

        private void alterComapnyButton_Click(object sender, EventArgs e)
        {
            CreateCompanyForm createCompany = new CreateCompanyForm();
            createCompany.ShowDialog();
        }
    }
}
