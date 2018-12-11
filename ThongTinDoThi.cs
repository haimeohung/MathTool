using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Math_V1._1
{
    public partial class ThongTinDoThi : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ThongTinDoThi()
        {
            InitializeComponent();
        }

        private void ThongTinDoThi_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ExpressionHelper.ArrExpression.Count; i++)
            {
                this.cbBieuThuc.Items.Add(ExpressionHelper.ArrExpression[i].ToString());
                this.cbBieuThuc.SelectedIndex = 0;
            }
            this.rbDo.Checked = false;
            this.rbRadian.Checked = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lvXAndFX.Items.Clear();
            Expression expression = new Expression(cbBieuThuc.Text);

            for (int i = Convert.ToInt32(ExpressionHelper.XStartValue); i <= Convert.ToInt32(ExpressionHelper.XEndValue); i++)
            {
                double Y = expression.Evaluate(i);
                ListViewItem lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(Y.ToString());
                lvXAndFX.Items.Add(lvi);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.rbDo.Checked = false;
            this.rbRadian.Checked = true;
            this.Close();
        }

        private void rbDo_CheckedChanged(object sender, EventArgs e)
        {
            ExpressionHelper.BlnDo = true;
            ExpressionHelper.BlnRadian = false;
        }

        private void rbRadian_CheckedChanged(object sender, EventArgs e)
        {
            ExpressionHelper.BlnDo = false;
            ExpressionHelper.BlnRadian = true;
        }
    }
}