﻿using AHP.Entidades;
using AHP.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHP.UI
{
    public partial class AtividadeUI : Form
    {
        private AtividadeBLL bll;
        public AtividadeUI()
        {
            InitializeComponent();
            bll = new AtividadeBLL();
        }

        private void AtividadeUI_Load(object sender, EventArgs e)
        {
            carregarLista();
        }

        public void carregarLista()
        {
            grid.DataSource = bll.Listar();
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[0].ReadOnly = true;
            grid.Columns[1].HeaderText = "Descrição";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.SelectedRows.Count; i++)
            {
                DialogResult dialogResult = MessageBox.Show("Sure?", "Excluir portfólio", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bll.Excluir(Convert.ToInt32(grid.SelectedRows[i].Cells[0].Value));
                }
                carregarLista();
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bll.Alterar(new Atividade()
            {
                ID = Convert.ToInt32(grid[0, e.RowIndex].Value),
                Descricao = grid[e.ColumnIndex, e.RowIndex].Value.ToString()
            });
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarAtividadeUI form = new AdicionarAtividadeUI(this);
            form.ShowDialog();
        }
    }
}
