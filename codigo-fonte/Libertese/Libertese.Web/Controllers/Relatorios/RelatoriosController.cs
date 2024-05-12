using Libertese.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Libertese.Domain.Entities;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Venda;
using Libertese.Web.ViewModels;


namespace Libertese.Web.Controllers.Relatorios
{
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método genérico para baixar CSV
        public async Task<IActionResult> DownloadCsv(string tipo)
        {
            IEnumerable<object> records = tipo.ToLower() switch
            {
                "vendas" => await _context.Vendas.ToListAsync(),
                "despesas" => await _context.Despesas.ToListAsync(),
                "receita" => await _context.Receitas.ToListAsync(),
                _ => null
            };

            if (records == null || !records.Any())
            {
                return Content("Nenhum registro encontrado.");
            }

            string fileName = $"{tipo}_{DateTime.Now.ToString("yyyyMMdd")}.csv";
            return await GenerateCsv(records, fileName);
        }



        private async Task<FileContentResult> GenerateCsv<T>(IEnumerable<T> records, string fileName)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream, leaveOpen: true);
            using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," });

            csvWriter.WriteRecords(records);
            writer.Flush();
            memoryStream.Position = 0; // Garanta que o stream está no começo antes de ler

            return File(memoryStream.ToArray(), "text/csv", fileName);
        }


        public async Task<IActionResult> Index()
        {
            var datasCriacaoVendas = await _context.Vendas
                .Select(v => v.DataCriacao)
                .Distinct()
                .OrderBy(date => date)
                .ToListAsync();

            var datasCriacaoDespesas = await _context.Despesas
                .Select(d => d.DataCriacao)
                .Distinct()
                .OrderBy(date => date)
                .ToListAsync();

            var datasCriacaoReceitas = await _context.Receitas
                .Select(d => d.DataCriacao)
                .Distinct()
                .OrderBy(date => date)
                .ToListAsync();

            // Crie e preencha a ViewModel
            var viewModel = new DatasCriacaoViewModel
            {
                DatasCriacaoVendas = datasCriacaoVendas,
                DatasCriacaoDespesas = datasCriacaoDespesas,
                DatasCriacaoReceitas = datasCriacaoReceitas
                // Inicialize outras propriedades conforme necessário
            };

            return View(viewModel); // Passe a ViewModel para a view
        }



        // GET: RelatoriosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RelatoriosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelatoriosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RelatoriosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RelatoriosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RelatoriosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RelatoriosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
