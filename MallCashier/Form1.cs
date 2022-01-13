using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallCashier
{
    /// <summary>
    /// 做一个超市收银系统：根据客户所买的单价和数量，向客户收费
    /// 需要：单价、数量输入框；确认以及重置按钮，显示商品以及总价格
    /// 
    /// 后期增加打折处理，
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DiscountCbx.Items.AddRange(new object[] { "正常折扣", "打九折", "打八折", "打七折", "打六折", "打五折", "满300减20" });
            this.DiscountCbx.SelectedIndex = 0;
        }
        decimal totalPrice = 0;

        private void Confirm_Btn_Click(object sender, EventArgs e)
        {
            var price = this.txtPrice.Text;
            var num = this.txtNumber.Text;
            decimal countPrice = 0;

            #region 面向过程  
            countPrice = Convert.ToDecimal(price) * Convert.ToDecimal(num);
            #region 面向过程(增加折扣商品) 
            //switch (this.DiscountCbx.SelectedIndex)
            //{
            //    case 0:
            //        countPrice = countPrice;
            //        break;
            //    case 1:
            //        countPrice = (Convert.ToDecimal(price) * Convert.ToDecimal(num)) * (decimal)0.9;
            //        break;
            //    case 2:
            //        countPrice = (Convert.ToDecimal(price) * Convert.ToDecimal(num)) * (decimal)0.8;
            //        break;
            //    case 3:
            //        countPrice = (Convert.ToDecimal(price) * Convert.ToDecimal(num)) * (decimal)0.7;
            //        break;
            //    case 4:
            //        countPrice = (Convert.ToDecimal(price) * Convert.ToDecimal(num)) * (decimal)0.6;
            //        break;
            //    case 5:
            //        countPrice = (Convert.ToDecimal(price) * Convert.ToDecimal(num)) * (decimal)0.5;
            //        break;
            //    default:
            //        break;
            //}
            #endregion
            #endregion



            #region 利用工厂模式
            /// 如果我需要加打三折，或者满300减40，或者满300送八十等，需要重新改代码 ，维护性不好
            /// 面向对象的编程，并不是类越多越好,类的划分是为了封装，
            /// 但分类的基础是抽象，具有相同属性和功能的对象的抽象集合才是类
            var type = this.DiscountCbx.SelectedItem.ToString();
            CashSuper cashSuper = CashFactory.CreateCashSuper(type);
            countPrice=cashSuper.AcceptCash(countPrice);

            ///如果增加满100块钱累计10点积分，积分达到一定条件后可以领取奖品
            ///答：新增要给积分算法，，构造函数设置两个参数：条件和返点，
            ///    让他继承 CashSuper，然后在收费现金工厂里面增加满100送10积分的分支条件，然后再改动界面就行了。
            ///    
            /// 工厂模式虽然能解决这个问题，但是这个模式只是解决对象的创建问题。
            /// 而工厂本身包含了多有的收费方式，商场可能经常性的更改打折额度和返利额度，
            /// 每次维护收费方式都要改动这个工厂，导致代码需要重新编译部署，这个是个很糟糕的处理方式(非好方法)
            ///
            #endregion

            #region 策略模式(客户端代码)
            ///
            StrategyContext strategyContext = new StrategyContext(type);
            countPrice = strategyContext.GetResult(countPrice);

            #endregion

            totalPrice += countPrice;
            this.txtDesc.Items.Add($"单价：{price},数量：{num},总价：{countPrice}");
            this.countNum.Text = totalPrice.ToString();
        }

        private void Reset_Btn_Click(object sender, EventArgs e)
        {
            this.txtPrice.Text = "";
            this.txtNumber.Text = "";
            this.countNum.Text = "";
            this.totalPrice = 0;
            this.txtDesc.Items.Clear();
            this.DiscountCbx.SelectedIndex = 0;
        }

        private void txtDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
