﻿using AHP.Dados;
using AHP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AHP.Negocios
{
    class PortfolioBLL
    {
        private PortfolioDAO dao;

        public PortfolioBLL()
        {
            dao = new PortfolioDAO();
        }

        public void Adicionar(Portfolio portfolio)
        {
            dao.Adicionar(portfolio);
        }

        public void Excluir(int id)
        {
            dao.Excluir(id);
        }

        public List<Portfolio> Listar()
        {
            return dao.Listar();
        }

        public void Alterar(Portfolio portfolio)
        {
            dao.Alterar(portfolio);
        }
    }
}
