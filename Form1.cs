
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace partners
{
    public partial class Form1 : Form
    {
        private Pr4Context? db;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new Pr4Context();
            this.db.Partners.Load();
            this.dataGridViewPartners.DataSource = db.Partners.Local.ToBindingList();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.db?.Dispose();
            this.db = null;
        }
    }
}
