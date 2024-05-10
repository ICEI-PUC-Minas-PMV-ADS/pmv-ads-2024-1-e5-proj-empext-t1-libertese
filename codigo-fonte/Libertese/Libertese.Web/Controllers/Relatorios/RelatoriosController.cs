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
            switch (tipo.ToLower())
            {
                case "vendas":
                    var vendas = await _context.Vendas.ToListAsync();
                    return await GenerateCsv(vendas, "vendas.csv");

                case "despesas":
                    var despesas = await _context.Despesas.ToListAsync();
                    return await GenerateCsv(despesas, "despesas.csv");

                case "receita":
                    var receitas = await _context.Receitas.ToListAsync();
                    return await GenerateCsv(receitas, "receitas.csv");

                default:
                    return NotFound();
            }
        }

        private async Task<FileContentResult> GenerateCsv<T>(IEnumerable<T> records, string fileName)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            using var csvWriter = new CsvWriter(writer,
                new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," });

            csvWriter.WriteRecords(records);
            writer.Flush();
            return File(memoryStream.ToArray(), "text/csv", fileName);
        }

        public async Task<IActionResult> Index()
        {
            var datasCriacao = new List<DateTime?>();

            // Exemplo de como adicionar datas de várias entidades.
            datasCriacao.AddRange(await _context.Set<Venda>().Select(v => v.DataCriacao).Distinct().ToListAsync());
            datasCriacao.AddRange(await _context.Set<Despesa>().Select(d => d.DataCriacao).Distinct().ToListAsync());
            datasCriacao.AddRange(await _context.Set<Receita>().Select(d => d.DataCriacao).Distinct().ToListAsync());

            // Ordenação final das datas (pode ser feito no banco de dados ou na aplicação)
            datasCriacao = datasCriacao.Distinct().OrderBy(d => d).ToList();

            // Passando as datas como uma lista de DateTime? usando ViewBag (ou ViewData)
            ViewBag.DatasCriacao = datasCriacao;

            return View();
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
