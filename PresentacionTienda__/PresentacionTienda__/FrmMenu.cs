﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionTienda_
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmAltas AL = new FrmAltas();
            AL.MdiParent = this;
            AL.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            FrmBajas AL = new FrmBajas();
            AL.MdiParent = this;
            AL.Show();

        }

        private void btnModificaciones_Click(object sender, EventArgs e)
        {
            FrmModificaciones AL = new FrmModificaciones();
            AL.MdiParent = this;
            AL.Show();
        }
    }
}
