using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SwarmForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StartLogic();
        }

        private void StartLogic()
        {
            var mainModel = new MainModel();

            DrawChart(zedGraphControl1, mainModel.BestSolutions);
        }

        private void DrawChart(ZedGraphControl zgc, ReadOnlyCollection<float> data)
        {
            GraphPane pane = zgc.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            for (int x = 1; x < data.Count + 1; x++)
            {
                list.Add(x, data[x - 1]);
            }

            LineItem curve = pane.AddCurve("Поиск лучшего решения", list, Color.Violet, SymbolType.Diamond);

            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}