using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductsScreen : Form
    {
        private SqlConnection databaseConnection;
        private int lastSelectedProductKey;

        public ProductsScreen()
        {
            InitializeComponent();
            LanguageHelper.SetApplicationLanguage();
            LoadProducts();
        }

        // Method to load products into the DataGridView
        private void LoadProducts()
        {
            try
            {
                List<Product> products = ProductRepository.LoadProducts();

                if (products == null || products.Count == 0)
                {
                    productsDGV.DataSource = null;
                    MessageBox.Show("No products found.");
                    return;
                }

                productsDGV.DataSource = products;

                if (productsDGV.Columns.Contains("ID"))
                {
                    productsDGV.Columns["ID"].Visible = false; // Hide the ID column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        // Save the new product
        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.ValidateInput(textBoxProductName, textBoxProductBrand, comboBoxCategory, textBoxProductPrice, textBoxProductAmount, out Product product))
            {
                return;
            }
            ProductRepository.SaveProduct(product);
            LoadProducts();
        }

        // Edit the selected product
        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.ValidateInput(textBoxProductName, textBoxProductBrand, comboBoxCategory, textBoxProductPrice, textBoxProductAmount, out Product product))
            {
                return;
            }
            product.ID = lastSelectedProductKey;
            ProductRepository.EditProduct(product);
            LoadProducts();
        }

        // Delete the selected product
        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            //  Check if a product is selected
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            // 2 Ask for user confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            //  If the user clicks "Yes", delete the product
            if (result == DialogResult.Yes)
            {
                ProductRepository.DeleteProduct(lastSelectedProductKey);
                LoadProducts(); // Refresh the DataGridView
                ClearAllFields(); // Clear the input fields
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadProducts();
            ClearAllFields();
        }

        // Clear all input fields
        private void btnClearText_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        // Method to load data from the selected table row into the corresponding text fields
        private void productsDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (productsDGV.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                lastSelectedProductKey = Convert.ToInt32(productsDGV.SelectedRows[0].Cells["ID"].Value);
                textBoxProductName.Text = productsDGV.SelectedRows[0].Cells["Name"].Value.ToString();
                textBoxProductBrand.Text = productsDGV.SelectedRows[0].Cells["Brand"].Value.ToString();
                comboBoxCategory.Text = productsDGV.SelectedRows[0].Cells["Category"].Value.ToString();
                textBoxProductPrice.Text = productsDGV.SelectedRows[0].Cells["Price"].Value.ToString();
                textBoxProductAmount.Text = productsDGV.SelectedRows[0].Cells["Amount"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the selected product: " + ex.Message); // Message translated to English
            }
        }

        // Method to clear all input fields
        private void ClearAllFields()
        {
            textBoxProductName.Clear();
            textBoxProductBrand.Clear();
            textBoxProductPrice.Clear();
            comboBoxCategory.SelectedIndex = -1;
            textBoxProductAmount.Clear();
            comboBoxFilterBy.SelectedIndex = -1;
            comboBoxSelectItem.SelectedIndex = -1;

            lastSelectedProductKey = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterBy.SelectedItem == null)
            {
                MessageBox.Show("Please select Name, Brand oder Category.");
                return;
            }

            string filterType = comboBoxFilterBy.SelectedItem.ToString();

            if (filterType == "Name" || filterType == "Brand" || filterType == "Category")
            {
                comboBoxSelectItem.DataSource = ProductRepository.GetFilterValues(filterType);
            }
            else
            {
                MessageBox.Show("Invalid selection.");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterBy.SelectedItem == null || comboBoxSelectItem.SelectedItem == null)
            {
                MessageBox.Show("Bitte wähle einen Filter und einen Wert aus.");
                return;
            }

            string filterType = comboBoxFilterBy.SelectedItem.ToString();
            string filterValue = comboBoxSelectItem.SelectedItem.ToString();

            productsDGV.DataSource = ProductRepository.GetFilteredProducts(filterType, filterValue);
        }
    }
}