using System;
using System.Linq;
using System.Windows.Forms;
using CaesarCypher.UI.Cypher;

namespace CaesarCypher.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnEncryptClicked(object sender, EventArgs e)
        {
            if (TryGetCypher(out var cypher))
            {
                output.Text = cypher.Encrypt(input.Text);
            }
        }

        private void OnDecryptClicked(object sender, EventArgs e)
        {
            if (TryGetCypher(out var cypher))
            {
                output.Text = cypher.Decrypt(input.Text);
            }
        }

        private bool TryGetCypher(out ICypher cypher)
        {
            var keyValue = key.Text;
            error.Text = "";
            if (string.IsNullOrEmpty(keyValue))
            {
                cypher = null;
                error.Text = "Key is empty";
                return false;
            }
            
            if (int.TryParse(keyValue, out var resultKey))
            {
                cypher = new KeyCypher(resultKey);
                return true;
            }

            keyValue = keyValue.ToLower();
            if (keyValue.Any(c => (c < 'а' || c > 'я') && c != 'ё'))
            {
                cypher = null;
                
                return false;
            }

            cypher = new KeyWordCypher(keyValue);
            return true;
        }
    }
}