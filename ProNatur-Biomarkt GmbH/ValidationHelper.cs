using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    internal class ValidationHelper
    {
        public static bool ValidateInput(TextBox nameBox, TextBox brandBox, ComboBox categoryBox,
                                         TextBox priceBox, TextBox amountBox, out Product product)
        {
            product = null;

            string productName = nameBox.Text;
            string productBrand = brandBox.Text;
            string productCategory = categoryBox.Text;

            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(productBrand) ||
                string.IsNullOrWhiteSpace(productCategory) ||
                string.IsNullOrWhiteSpace(priceBox.Text) ||
                string.IsNullOrWhiteSpace(amountBox.Text))
            {
                MessageBox.Show("Bitte fülle alle Felder aus!");
                return false;
            }

            // Convert comma to dot in price(Example "1,50 will be 1.50)
            string priceText = priceBox.Text.Replace(",", ".");

            // Validate the price
            if (!decimal.TryParse(priceText, out decimal productPrice) || productPrice <= 0)
            {
                MessageBox.Show("Bitte gib einen gültigen Preis (> 0) ein.");
                return false;
            }

            // Validate the quantity
            if (!int.TryParse(amountBox.Text, out int productAmount) || productAmount <= 0)
            {
                MessageBox.Show("Bitte gib eine gültige Anzahl (> 0) ein.");
                return false;
            }

            // If all validations pass, create a new Product object with the valid data.
            // This encapsulates the product's information in a single object for easier management and use,
            // and assigns it to the 'product' output parameter for further processing, like saving to a database.

            product = new Product
            {
                Name = productName,
                Brand = productBrand,
                Category = productCategory,
                Price = productPrice,
                Amount = productAmount
            };

            return true;
        }
    }
}