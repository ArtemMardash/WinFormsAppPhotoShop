﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppPhotoShop
{
    public partial class Form3 : Form
    {
        Form1 OwnerForm;
        public Form3(Form1 ownerForm)
        {
            InitializeComponent();
            OwnerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}