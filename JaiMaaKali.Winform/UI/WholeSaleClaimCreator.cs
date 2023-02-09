using AutoMapper;
using JaiMaaKali.WinForm.Data;
using JaiMaaKali.WinForm.Data.Repository;
using JaiMaaKali.WinForm.Export;
using JaiMaaKali.WinForm.Extension;
using JaiMaaKali.WinForm.Service.Bill;
using JaiMaaKali.WinForm.Service.WholeSaleClaim;
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
    public partial class WholeSaleClaimCreator : UserControl
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Data.Model.PartyClaimCriteria> _claimRepository;
        private readonly IRepository<Data.Model.BillItem> _billRepository;
        private readonly IRepository<Data.Model.AmountDiscount> _discountRepo;
        private IList<PartyWholeSaleClaimCriteria> _claimCriterias;
        private WholeSaleClaimGenerator _wholeSaleClaimGenerator;
        private IList<Bill> _sampleBills;
        private ClaimDiscounts _claimDiscounts;
        private decimal _taxRate;
        private decimal _discountRate;
        private decimal _expectedTotalClaimAmount;

        public WholeSaleClaimCreator(IMapper mapper,
            IRepository<Data.Model.PartyClaimCriteria> claimRepo,
            IRepository<Data.Model.BillItem> billRepo,
            IRepository<Data.Model.AmountDiscount> discountRepo)
        {
            InitializeComponent();
            _taxRate = TaxRateNumericField.Value/100;
            _discountRate = DiscountRateNumericField.Value/100;
            _expectedTotalClaimAmount = ExpectedClaimAmountNumericField.Value;
            _sampleBills = new List<Bill>();
            _mapper = mapper;
            _claimRepository = claimRepo;
            _billRepository = billRepo;
            _discountRepo = discountRepo;
        }

        private void AllTextFilled(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(ClaimDataFileInput.Text))
                {

                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if (!Path.Exists(BillFolder.Text))
                {

                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if(ExpectedClaimAmountNumericField.Value < 0)
                {
                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if(!File.Exists(DiscountRateFileTextField.Text))
                {
                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if (!Path.Exists(OutputPathInput.Text))
                {

                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
            }
            catch
            {
                GenerateButton.BackColor = Color.DarkGray;
                GenerateButton.Enabled = false;
                return;
            }
            _wholeSaleClaimGenerator = new WholeSaleClaimGenerator(_claimCriterias, _claimDiscounts);
            GenerateButton.BackColor = Color.Green;
            GenerateButton.Enabled = true;
            return;
        }

        private void ClaimCriteriaFileInput_OpenExplorer(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select a file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ClaimDataFileInput.Text = filePath;
            }
        }

        private void SampleBillPath_OpenExplorer(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.Description = "Select a folder";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog.SelectedPath;
                BillFolder.Text = filePath + "\\";
            }

        }

        private void OutputPath_OpenExplorer(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.Description = "Select a folder";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog.SelectedPath;
                OutputPathInput.Text = filePath + "\\";
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClaimDataFileInput.Text = string.Empty;
            BillFolder.Text = string.Empty;
            OutputPathInput.Text = string.Empty;
            ExpectedClaimAmountNumericField.Value = 10000;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Estimated Claim
                var estimatedClaims = _wholeSaleClaimGenerator
                    .GenerateClaim(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    _expectedTotalClaimAmount,
                    500.00m,
                    0.00m);
                IList<Bill> outputBills = new List<Bill>();
                IList<PartyClaim> knownClaims = new List<PartyClaim>();
                foreach(var bill in _sampleBills)
                {
                    //Creating for estimated claim amount of that party
                    if(bill == null ) continue;
                    IBillCreator billCreator = new BillCreator(bill.BillItems
                        .Select(x => new BillItem() 
                        { 
                            SN= x.SN,
                            Description = x.Description,
                            Quantity= x.Quantity,
                            Rate= x.Rate,
                        }));
                    var claim = estimatedClaims.GetPartyClaims().FirstOrDefault(x => x.Value.Party == bill.Party).Value;
                    if(claim == null ) continue;
                    var outputbill = billCreator.CreateBillForTotalAmount(bill.Party, _taxRate, _discountRate, claim.Amount);
                    outputBills.Add(outputbill);

                    //Using Bill Amount for Claim
                    claim.Amount = outputbill.GetTotalAmount();
                    _wholeSaleClaimGenerator.AddKnownPartyClaim(claim);
                }
                //Craeting Final Claim 
                var outputWholeSaleClaim = _wholeSaleClaimGenerator.GenerateClaim(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    _expectedTotalClaimAmount,
                    500.00m,
                    0.00m);

                //Exporting Claims to csv
                var outputpath = Path.Combine(OutputPathInput.Text, DateTime.Now.ToString("yyyy_MM"));
                IExport exporter = new JsonExport();
                var billstoExport = _mapper.Map<IList<Export.Model.Bill>>(outputBills.ToList());
                var claimToExport = _mapper.Map<Export.Model.WholeSaleClaim>(outputWholeSaleClaim);
                exporter.ExportList<Export.Model.Bill>(billstoExport.ToList(), outputpath , "Bill");
                exporter.Export<Export.Model.WholeSaleClaim>(claimToExport, outputpath, "WholeSaleClaim");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _wholeSaleClaimGenerator._knownPartyClaims.Clear();
            }
            
        }

        private void ClaimDataFileInput_Leave(object sender, EventArgs e)
        {
            try
            {
                _claimRepository.ReadDataFromFile(ClaimDataFileInput.Text, new Data.CSVFileStatergy<Data.Model.PartyClaimCriteria>());
                _claimCriterias = _mapper.Map<IEnumerable<PartyWholeSaleClaimCriteria>>(_claimRepository.Entities).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BillFolder_Leave(object sender, EventArgs e)
        {
            try
            {
                _sampleBills.Clear();
                var files = Directory.GetFiles(BillFolder.Text);
                foreach (var file in files)
                {
                    try
                    {
                        _billRepository.ReadDataFromFile(file, new CSVFileStatergy<Data.Model.BillItem>());
                        var party_name = Path.GetFileNameWithoutExtension(file);
                        var party_criteria = _claimCriterias
                            .FirstOrDefault(x => x.Party.CustomerName == party_name.RemoveExtraSpace().ToUpper()) ??
                            throw new DataException($"{party_name} is not found in claim criteria.");
                        var party = party_criteria.Party;
                        var bill = new Bill(party, _taxRate, _discountRate);
                        _billRepository.ReadDataFromFile(file, new CSVFileStatergy<Data.Model.BillItem>());
                        bill.AddBillItems(_mapper.Map<IEnumerable<BillItem>>(_billRepository.Entities));
                        _sampleBills.Add(bill);
                    }
                    catch (Exception ex) 
                    { 
                        MessageBox.Show(ex.ToString());
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TaxRateNumericField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _taxRate = TaxRateNumericField.Value / 100;
                foreach(var bill in _sampleBills)
                {
                    bill.TaxRate = _taxRate;
                    AllTextFilled(sender, e);
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DiscountRateNumericField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _discountRate = DiscountRateNumericField.Value / 100;
                foreach (var bill in _sampleBills)
                {
                    bill.DiscountRate = _discountRate;
                    AllTextFilled(sender, e);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void WholeSaleClaimCreator_Load(object sender, EventArgs e)
        {

        }

        private void DiscountRateFileTextField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select a file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DiscountRateFileTextField.Text = filePath;
            }
        }

        private void DiscountRateFileTextField_Leave(object sender, EventArgs e)
        {
            try
            {
                _discountRepo.ReadDataFromFile(DiscountRateFileTextField.Text, new CSVFileStatergy<Data.Model.AmountDiscount>());
                _claimDiscounts = _mapper.Map<ClaimDiscounts>(_discountRepo.Entities);
                AllTextFilled(sender, e);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ExpectedClaimAmountNumericField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _expectedTotalClaimAmount = ExpectedClaimAmountNumericField.Value;
                AllTextFilled(sender, e);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
