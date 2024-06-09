using Libertese.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Libertese.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Relatorios
{
    [Authorize(Policy = "RequireRelatorios")]
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DownloadCsv(string tipo, DateTime? periodoInicio, DateTime? periodoFim, bool checkOnly = false)
        {
            IEnumerable<object> records = null;

            switch (tipo.ToLower())
            {
                case "vendas":
                    records = await _context.Vendas
                        .Where(v => (!periodoInicio.HasValue || v.DataCriacao >= periodoInicio) &&
                                    (!periodoFim.HasValue || v.DataCriacao <= periodoFim))
                        .ToListAsync();
                    break;
                case "despesas":
                    records = await _context.Despesas
                        .Where(d => (!periodoInicio.HasValue || d.DataCriacao >= periodoInicio) &&
                                    (!periodoFim.HasValue || d.DataCriacao <= periodoFim))
                        .ToListAsync();
                    break;
                case "receita":
                    records = await _context.Receitas
                        .Where(r => (!periodoInicio.HasValue || r.DataCriacao >= periodoInicio) &&
                                    (!periodoFim.HasValue || r.DataCriacao <= periodoFim))
                        .ToListAsync();
                    break;
                default:
                    return Json(new { error = "Tipo de relatório desconhecido." });
            }

            if (records == null || !records.Any())
            {
                return Json(new { error = "Nenhum registro encontrado para este período." });
            }

            if (checkOnly)
            {
                return Json(new { success = true });
            }

            // Gerar o CSV
            return await GenerateCsv(records, $"{tipo}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv");
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
    }
}
