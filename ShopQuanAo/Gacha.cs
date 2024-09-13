using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopQuanAo
{
    public partial class Gacha : Form
    {
        public Gacha()
        {
            InitializeComponent();
        }

        private void btnGacha_Click(object sender, EventArgs e)
        {
            
            Random rand = new Random();                     
                int x = Convert.ToInt32(rand.Next(0, 99));
                int y = Convert.ToInt32(lblRoll.Text);

            if (y > 0)
            {
                lbGacha.Items.Clear();
                if (x < 1)
                    lbGacha.Items.Add("Voucher giới hạn -40%");
                else if (x < 9)
                    lbGacha.Items.Add("Voucher -10%");
                else
                    lbGacha.Items.Add("Chúc may mắn lần sau");
                y--;
                lblRoll.Text = y.ToString();

            }
            else
                txtNoti.Text = "Bạn đã hết lượt săn hôm nay";
        }

        private void btnGacha10_Click(object sender, EventArgs e)
        {
            
            int y = Convert.ToInt32(lblRoll.Text);
            Random rand = new Random();
            if (y > 9)
            {
                lbGacha.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    int x = Convert.ToInt32(rand.Next(0, 99));
                    if (y > 0)
                    {
                        
                        if (x < 1)
                            lbGacha.Items.Add("Voucher giới hạn -40%");
                        else if (x < 9)
                            lbGacha.Items.Add("Voucher -10%");
                        else
                            lbGacha.Items.Add("Chúc may mắn lần sau");

                        y--;
                        lblRoll.Text = y.ToString();

                    }                   
                }
            } else if (y > 0 && y< 10)
                txtNoti.Text = "Bạn không đủ 10 lượt";
              else txtNoti.Text = "Bạn đã hết lượt săn hôm nay";
        }
    }
}
