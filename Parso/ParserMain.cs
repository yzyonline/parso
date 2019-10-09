using Parso.Common;
using Parso.Entities;
using Parso.HtmlParser.CustomParser;
using Parso.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parso
{
    public partial class ParserMain : Form
    {
        public ParserMain()
        {
            InitializeComponent();
        }

        public long BatchId { get; set; }

        internal int CatalogCount = 0;
        internal int CompletedCatalogCount = 0;
        internal Progress<int> Progress { get; set; }

        private async void btnParseAction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name = txtBatchName.Text))
            {
                MessageBox.Show("Batch Name Missing!");
                return;
            }

            ParsoEntities entities = new ParsoEntities();
            var batchDefinition = new Batch()
            {
                Name = txtBatchName.Text,
                ApplicationId = Convert.ToInt64(cmbApplicationType.SelectedValue.ToString()),
                StartDate = batchStartDate.Value.Date,
                EndDate = batchEndDate.Value.Date,
                RecordDate = DateTime.Now
            };

            entities.Batch.Add(batchDefinition);
            entities.SaveChanges();

            BatchId = batchDefinition.Id;

            progressBar.Maximum = 100;
            progressBar.Step = 1;

            Progress = new Progress<int>(v =>
            {
                progressBar.Value = v;
            });

            switch (((ApplicationDefinition)cmbApplicationType.SelectedItem).Name.ToString())
            {
                case "Carrefour":
                    await Task.Run(() => ParseCarrefour());
                    break;
                case "Migros":
                    await Task.Run(() => ParseMigros());
                    break;
            }
        }

        public void ParseCarrefour()
        {
            CarrefourHtmlParser parser = new CarrefourHtmlParser();

            var rootUrl = "https://www.carrefoursa.com/affiliate/Sitemap1.xml";
            var catalogList = parser.ParseCatalogList(BatchId, rootUrl);

            CatalogCount = catalogList.Count();
            parser.ParseFinished += Parser_ParseFinished;
            Task.Factory.StartNew(() => Parallel.ForEach<Parso.Common.Base.ParsoCatalog>(catalogList, item => parser.ParseProductList(item)));
        }

        private void Parser_ParseFinished(object sender, HtmlParser.ParseFinishedEventArgs e)
        {
            CompletedCatalogCount += 1;

            if (Progress != null)
                ((IProgress<int>)Progress).Report(Convert.ToInt32(((double)(CompletedCatalogCount) / CatalogCount) * 100));
        }

        public void ParseMigros()
        {
            MigrosHtmlParser parser = new MigrosHtmlParser();

            var rootUrl = "https://www.sanalmarket.com.tr/kweb/getCategoryList.do?searchType=2";
            var catalogList = parser.ParseCatalogList(BatchId, rootUrl);

            CatalogCount = catalogList.Count();
            parser.ParseFinished += Parser_ParseFinished;

            Task<ParallelLoopResult> loopResult =  Task.Factory.StartNew(() => Parallel.ForEach<Parso.Common.Base.ParsoCatalog>(catalogList, item => parser.ParseProductList(item)));
        }

        private void ParserMain_Load(object sender, EventArgs e)
        {
            ParsoEntities entities = new ParsoEntities();

            cmbApplicationType.DataSource = entities.ApplicationDefinition.ToList();
            cmbApplicationType.DisplayMember = "Name";
            cmbApplicationType.ValueMember = "Id";
            cmbApplicationType.Show();
        }
    }
}
