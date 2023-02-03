
using JaiMaaKali.WinForm.Export;
using JaiMaaKali.WinForm.Service.ClaimGenerator;
using JaiMaaKali.WinForm.Service.DataMining;
using System.Security.Claims;
using System.Windows.Forms;

namespace JaiMaaKali.WinForm
{
    public partial class ClaimCreator : Form
    {
        public ClaimCreator()
        {
            InitializeComponent();
            YearComboBox.Items.Clear();
            int now_year = DateTime.Now.Year;
            for(int i=0;i < 20; i++)
            {
                YearComboBox.Items.Add(now_year-i);
            }
            MonthComboBox.Items.Clear();
            MonthComboBox.DataSource = Enum.GetValues(typeof(Month));
            GenerateButton.Enabled = false;
        }

        

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string datafilepath = DataFileInput.Text;
                int year = Int32.Parse(YearComboBox.Text);
                int month = MonthComboBox.SelectedIndex + 1;
                decimal rate = decimal.Parse(RateInputBox.Text);
                string formatfile = FormatFileInput.Text;
                string output = OutputPathInput.Text;
                IDataManager<PurchaseProduct> dataminer = new DataManager<PurchaseProduct>(new CSVFileStatergy<PurchaseProduct>());
                IClaimGenerator<PurchaseProduct> claimGenerator = new PurchaseProductClaimGenerator(rate);
                dataminer.MineDataFromFile(datafilepath);
                var claims = claimGenerator.GetTransportClaims(dataminer.Data).Where(x => x.BillDate.Year == year).Where(x => x.BillDate.Month == month).OrderBy(x => x.BillDate).ToList();

                IExport<TransportClaim> exporter = new TransportClaimExcelExport(formatfile);
                var filename = exporter.ExportToFile(claims, output);
                MessageBox.Show($"Path: {filename}", "File Successfully Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "File Not Created");
            }
            
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
             DataFileInput.Text = string.Empty;
            FormatFileInput.Text = string.Empty;
            OutputPathInput.Text = string.Empty;
        }

        private void AllTextFilled(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(DataFileInput.Text))
                {
                    
                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if (String.IsNullOrEmpty(YearComboBox.Text) || (Int32.Parse(YearComboBox.Text) > DateTime.Now.Year))
                {
                    
                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if (String.IsNullOrEmpty(MonthComboBox.Text) || !Enum.IsDefined(typeof(Month), MonthComboBox.Text))
                {
                    
                    GenerateButton.BackColor = Color.DarkGray;
                    GenerateButton.Enabled = false;
                    return;
                }
                if (!File.Exists(FormatFileInput.Text))
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
                if(String.IsNullOrEmpty(RateInputBox.Text) || decimal.Parse(RateInputBox.Text) < 0)
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
            GenerateButton.BackColor = Color.Green;
            GenerateButton.Enabled = true;
            return;
        }

        private void DataFileInput_OpenExplorer(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select a file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataFileInput.Text = filePath;
            }
        }

        private void FormatFileInput_OpenExplorer(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select a file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FormatFileInput.Text = filePath;
            }
        }

        private void OutputPath_OpenExplorer(object sender, EventArgs e)
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
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}