﻿using FoodTruck.Negocio;
using FoodTruck.Negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodTruck.Grafico
{
    public partial class ManterBebida : Form
    {
        public Bebida BebidaSelecionada { get; set; }

        public ManterBebida()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            Bebida bebida = new Bebida();

            bebida.Id = Convert.ToInt64(tbId.Text);
            bebida.Nome = tbNome.Text;
            bebida.Valor = Convert.ToDecimal(tbValor.Text);
            bebida.Tamanho = Convert.ToSingle(tbTamanho.Text);

            Validacao validacao;
            if (BebidaSelecionada == null)
            {
                validacao = Program.Gerenciador.CadastrarBebida(bebida);
            }
            else
            {
                validacao = Program.Gerenciador.AlterarBebida(bebida);
            }

            if (!validacao.Valido)
            {
                String mensagemValidacao = "";
                foreach (var chave in validacao.Mensagens.Keys)
                {
                    String msg = validacao.Mensagens[chave];
                    mensagemValidacao += msg;
                    mensagemValidacao += Environment.NewLine;
                }
                MessageBox.Show(mensagemValidacao);
            }
            else
            {
                MessageBox.Show("Bebida salva com sucesso!");
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManterBebida_Shown(object sender, EventArgs e)
        {
            if (BebidaSelecionada != null)
            {
                this.tbId.Text = BebidaSelecionada.Id.ToString();
                this.tbNome.Text = BebidaSelecionada.Nome;
                this.tbValor.Text = BebidaSelecionada.Valor.ToString();
                this.tbTamanho.Text = BebidaSelecionada.Tamanho.ToString();
            }
        }
    }
}
