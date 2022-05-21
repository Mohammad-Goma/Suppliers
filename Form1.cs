using System;
using System.Windows.Forms;

namespace Suppliers
{
    public partial class Form1 : Form
    {
        public Int64 Pricing_Lists = 0;
        Supplier sup = new Supplier();
        Products prod = new Products();
        frm.frm_rpt_cat cat = new frm.frm_rpt_cat();
        frm.frm_rpt_purchas purchas = new frm.frm_rpt_purchas();
        frm.frm_rpt_sups sups = new frm.frm_rpt_sups();
        frm.frm_rpt_contracts cont = new frm.frm_rpt_contracts();
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            sup.loadimage(img);
        }

        private void product_image_Click(object sender, EventArgs e)
        {
            sup.loadimage(img);
        }

        private void btn_delete_suplier_Click(object sender, EventArgs e)
        {
            sup.Delete(code_Supplier);
            sup.New(Code, img, contract_image, id, name_Supplier, code_Supplier, Category_Supplier, handling_way,
                sales_manager, phone_1, sales_representative, phone_2, sales_supervisor, phone_3, Pricing_Lists,
                Credit_limit, Category, tax_num, Commercial_Register, Procurement_Officer, title);
            sup.SelectDataToDGV(metroGrid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sup.Fill(Code);
            //sup.SelectDataToDGV(metroGrid);
            //prod.Fill(M_Grid);
            //prod.Fill(name_Sup_Prod);
        }

        private void btn_save_suplier_Click(object sender, EventArgs e)
        {
            if (id.Text.Trim() == "")
            {
                sup.save(name_Supplier, code_Supplier, Category_Supplier,handling_way, sales_manager, phone_1,
                    sales_representative,phone_2, sales_supervisor, phone_3, Credit_limit, img,contract_image,
                    Category, tax_num,Commercial_Register,Procurement_Officer, title);
                sup.Fill(Code); 
                sup.New(Code, img, contract_image, id, name_Supplier, code_Supplier,
                    Category_Supplier, handling_way, sales_manager, phone_1,
                    sales_representative, phone_2, sales_supervisor, phone_3, Pricing_Lists,
                    Credit_limit, Category, tax_num, Commercial_Register, Procurement_Officer, title);
            }
            else
            {
                sup.Edit(id, name_Supplier, code_Supplier, Category_Supplier,handling_way,sales_manager, phone_1,
                    sales_representative, phone_2, sales_supervisor, phone_3,Credit_limit,img,contract_image,
                    Category, tax_num, Commercial_Register, Procurement_Officer, title);

                sup.New(Code,img,contract_image,id,name_Supplier,code_Supplier,
                    Category_Supplier,handling_way,sales_manager,phone_1,
                    sales_representative,phone_2,sales_supervisor,phone_3,Pricing_Lists,
                    Credit_limit,Category,tax_num,Commercial_Register,Procurement_Officer,title);

                //sup.SelectDataToDGV(metroGrid);
                sup.Fill(Code);
            }
        }

        private void Code_TextChanged(object sender, EventArgs e)
        {
            sup.Select( id,Code,code_Supplier,name_Supplier,Category_Supplier,
                 handling_way,sales_manager,phone_1,sales_representative,phone_2,
                 sales_supervisor,phone_3,Credit_limit,Category,
                 tax_num,Commercial_Register,Procurement_Officer,title);

            sup.Show_image( img,  contract_image, code_Supplier);
        }

        private void btn_new_suplier_Click(object sender, EventArgs e)
        {
            sup.New(Code, img, contract_image, id, name_Supplier, code_Supplier,
                    Category_Supplier, handling_way, sales_manager, phone_1,
                    sales_representative, phone_2, sales_supervisor, phone_3, Pricing_Lists,
                    Credit_limit, Category, tax_num, Commercial_Register, Procurement_Officer, title);
        
            //sup.SelectDataToDGV(metroGrid);
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            metroGrid.Rows[e.RowIndex].Selected = true;
            //sup.MetroGrid_CellClick(metroGrid, id, name_Supplier, code_Supplier, Category_Supplier, handling_way, sales_manager, phone_1, sales_representative, phone_2, sales_supervisor, phone_3,Credit_limit);
            sup.Show_image(img, contract_image, code_Supplier);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ID_Product.Text.Trim() == "")
            {
                prod.Save(pic_Box, Code_product, name_Sup_Prod, name_product, Type_product, price_product, Qty_product, fk_product);
                prod.Fill(M_Grid);
                MessageBox.Show("تم الحفظ بنجاح","رسالة الحفظ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                prod.Edite(pic_Box, Code_product, name_product, Type_product, price_product, Qty_product, name_Sup_Prod, fk_product);
                prod.Fill(M_Grid);
                MessageBox.Show("تم التعديل بنجاح", "رسالة التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            sup.New(Code,img, contract_image, id, name_Supplier, code_Supplier,
                    Category_Supplier, handling_way, sales_manager, phone_1,
                    sales_representative, phone_2, sales_supervisor, phone_3, Pricing_Lists,
                    Credit_limit, Category, tax_num, Commercial_Register, Procurement_Officer,title);

            //prod.Fill(M_Grid);
        }

        private void M_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            prod.M_Grid_CellClick(M_Grid, name_Sup_Prod, name_product, Code_product, Type_product, price_product, Qty_product, ID_Product);
            prod.Show_image(pic_Box, Code_product);
        }

        private void pic_Box_Click(object sender, EventArgs e)
        {
            sup.loadimage(pic_Box);
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {
            sup.loadimage(pic_Box);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            prod.Delete(Code_product);
            MessageBox.Show("تم الحذف بنجاح","رسالة الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void price_product_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void Credit_limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        //private void Code_TextChanged_1(object sender, EventArgs e)
        //{
        //    sup.Select(id,Code,code_Supplier,name_Supplier,Category_Supplier,handling_way,sales_manager,phone_1,
        //               sales_representative,phone_2,sales_supervisor,phone_3,Credit_limit,Category,
        //               tax_num,Commercial_Register,Procurement_Officer);
        //}

        private void name_Sup_Prod_TextChanged(object sender, EventArgs e)
        {
            //prod.Select_Sup_Code(fk_product);
        }

        private void Qty_product_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            sup.SelectAllProducts(id, M_Grid_Produtcs);
        }

        private void name_product_TextChanged(object sender, EventArgs e)
        {

        }

        private void Code_product_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Supplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void code_Supplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void contract_image_Click(object sender, EventArgs e)
        {
            sup.loadimage(contract_image);
        }

        private void Category_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Category_Supplier.SelectedIndex == 0)
            {
                string[] pub0 =new string[] { "اغذية جافة", "حلويات", "اغذية طازجة", "مجمدات", "البان وعصائر",
                    "مياة معدنية", "مياة غازية","منظفات","تجميل","منزلية","لعب اطفال","هدايا - أعباد ميلاد","اخرى"};
                Category.Items.Clear();
                foreach (string x in pub0)
                {
                    Category.Items.Add(x);
                }
            }
            else
                if(Category_Supplier.SelectedIndex == 1)
            {
                string[] pub1 = {"اغذية جافة","حلويات","اغذية طازجة","مجمدات","البان وعصائر","مياة معدنية","مياة غازية"};
                Category.Items.Clear();
                foreach (string x in pub1)
                {
                    Category.Items.Add(x);
                }
            }
            else
                if (Category_Supplier.SelectedIndex == 2)
            {
                string[] pub2 = {"منظفات","تجميل","منزلية","لعب اطفال","هدايا - أعباد ميلاد","اخرى"};
                Category.Items.Clear();
                foreach (string x in pub2)
                {
                    Category.Items.Add(x);
                }
            }
        }

        private void btn_save_setting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = txt_ServerName.Text.Trim();
            Properties.Settings.Default.DataBase = txt_DataBaseName.Text.Trim();
            Properties.Settings.Default.UserName = txt_UserName.Text.Trim();
            Properties.Settings.Default.Password = txt_Paswword.Text.Trim();
            Properties.Settings.Default.Save();
            msg.Text = "تم الحفظ بنجاح";
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (txt_open.Text.Trim()=="goma_1988")
            {
                pnl_open.Visible = false;
            }
        }

        private void btn_Sups_Click(object sender, EventArgs e)
        {
            try
            {

                if (sups == null)
                {
                    sups = new frm.frm_rpt_sups();
                    sups.Show();
                }
                else if (sups.Visible == true)
                {
                    sups.BringToFront();
                    sups.Focus();
                }
                else
                {
                    sups.Close(); sups = new frm.frm_rpt_sups(); sups.Show();
                }
            } catch{ }
        }

        private void Categories_Click(object sender, EventArgs e)
        {
            try
            {

                if (cat == null)
                {
                    cat = new frm.frm_rpt_cat();
                    cat.Show();
                }
                else if (cat.Visible == true)
                {
                    cat.BringToFront();
                    cat.Focus();
                }
                else
                {
                    cat.Close(); cat = new frm.frm_rpt_cat(); cat.Show();
                }
            }
            catch { }
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            try
            {

                if (purchas == null)
                {
                    purchas = new frm.frm_rpt_purchas();
                    purchas.Show();
                }
                else if (purchas.Visible == true)
                {
                    purchas.BringToFront();
                    purchas.Focus();
                }
                else
                {
                    purchas.Close(); purchas = new frm.frm_rpt_purchas(); purchas.Show();
                }
            }
            catch { }
        }

        private void contract_Click(object sender, EventArgs e)
        {
            try
            {
                if (cont == null)
                {
                    cont = new frm.frm_rpt_contracts();
                    cont.Show();
                }
                else 
                if (cont.Visible == true)
                {
                    cont.BringToFront();
                    cont.Focus();
                }
                else
                {
                    cont.Close(); cont = new frm.frm_rpt_contracts(); cont.Show();
                }
            }
            catch { }
        }


    }
}
