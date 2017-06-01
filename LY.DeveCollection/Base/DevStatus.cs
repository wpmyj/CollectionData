using Client.Utility;
using LY.DeveCollection.SRExctue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LY.DeveCollection.Base
{
    public partial class DevStatus : Form
    {
        DevExecuteServiceClient client = new SRExctue.DevExecuteServiceClient();
        private WorkbenchTaskExecute workTask;

        public DevStatus(WorkbenchTaskExecute workTask)
        {
            InitializeComponent();
            this.workTask = workTask;

        }
        private void DevStatus_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = workTask.LstDeveiceTask;

            //var Test = client.GetDevViewList("text");
            //dataGridView1.DataSource = Test;
            //var ListModel = workTask.LstDeveiceTask.Where(t => (t.Priority == 0)).OrderByDescending(t => t.Priority).ToList();
            //foreach (var model in ListModel)
            //{

            //}

        }



        private void BgWait1_DoWork(object sender, DoWorkEventArgs e)
        {
            BgWait1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "Refresh":

                        //   MessageBox.Show(MyAddress);
                        //   dataGridView1.DataSource = client.GetDevViewList("text");
                        //  dataGridView1.Refresh();

                        //   String str = this.dataGridView1.SelectedCells[0].Value.ToString();
                        //  MessageBox.Show(str);



                        break;

                    case "bttniStartTask":

                        if (ClsMsg.ShowQuestionMsg("启动任务？") == DialogResult.Yes)
                        {

                            workTask.StartTask();


                        }

                        break;

                    case "bttniEndTask":

                        if (ClsMsg.ShowQuestionMsg("停止任务？") == DialogResult.Yes)
                        {
                            workTask.StopTask();

                        }

                        break;

                    default:
                        break;
                }
            }


            catch (Exception ex)
            {
                BgWait1.ReportProgress(102, ex.Message);
            }

            BgWait1.ReportProgress(100);
        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //  MessageBox.Show("Finish");


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {

                if (BgWait1.IsBusy == false)
                {
                    switch (e.ClickedItem.Name)
                    {

                        case "bttniStartTask":
                            BgWait1.RunWorkerAsync("bttniStartTask");

                            break;

                        case "bttniEndTask":
                            BgWait1.RunWorkerAsync("bttniEndTask");


                            break;

                        case "bbtniExit":

                            this.Close();

                            break;


                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = workTask.LstDeveiceTask[dataGridView1.CurrentCell.RowIndex];
            model.CurrDeviceConnect.Master.WriteSingleCoils((ushort)model.ExecID, 100, true, 255);
           
        }


    }
}
