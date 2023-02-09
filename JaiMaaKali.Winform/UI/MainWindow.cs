using AutoMapper;
using JaiMaaKali.WinForm.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaiMaaKali.WinForm.UI
{
    public partial class MainWindow : Form
    {
        
        public MainWindow(IMapper mapper, 
            IRepository<Data.Model.PartyClaimCriteria> claimRepo,
            IRepository<Data.Model.BillItem> billRepo,
            IRepository<Data.Model.AmountDiscount> discountRepo)
        {
            InitializeComponent();
            // WholeSaleClaimControl
            // 
            WholeSaleClaimControl = new WholeSaleClaimCreator(mapper, claimRepo, billRepo, discountRepo);
            // 
            // TransportClaimControl
            // 
            transportClaimControl = new TransportClaimControl();
            // 
            TransportClaimPageButton_Click(new object(), new EventArgs());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TransportClaimPageButton_Click(object sender, EventArgs e)
        {
            TransportClaimPageButton.FillColor = Color.DarkOrange;
            WholeSalePageButton.FillColor = Color.Transparent;
            AddUserControl(transportClaimControl);
        }

        private void AddUserControl(UserControl userControl)
        {
            if (userControl == null) { return; }
            int headerheight = panel1.Size.Height + NavPanel.Size.Height;
            OutputPanel.Dock = DockStyle.Fill;
            OutputPanel.Controls.Clear();
            OutputPanel.Controls.Add(userControl);
            userControl.Size = new Size(OutputPanel.Size.Width, userControl.Size.Height);
            OutputPanel.BringToFront();
        }

        private void WholeSalePageButton_Click(object sender, EventArgs e)
        {

            TransportClaimPageButton.FillColor = Color.Transparent;
            WholeSalePageButton.FillColor = Color.DarkOrange;
            AddUserControl(WholeSaleClaimControl);
        }
    }
}
