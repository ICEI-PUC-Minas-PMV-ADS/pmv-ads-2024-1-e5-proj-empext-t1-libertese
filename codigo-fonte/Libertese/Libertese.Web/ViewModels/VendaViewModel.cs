using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class VendaViewModel : BaseEntity
    {

        public string Id { get; set; }

        [Display(Name = "Cliente")]
        public string Cliente { get; set; }
        
        [Display(Name = "Total de itens")]
        public int Itens { get; set; }

        [Display(Name = "Data da venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [Display(Name = "Hora da venda")]
        public DateTime Hora { get; set; }

        public dynamic? Cancelamento { get; set; }

        [Display(Name = "Valor Total da Venda")]
        public decimal Valor { get; set; }

        [Display(Name = "Produtos")]
        public List<ProdutoVendaViewModel> Produtos { get; set; } = new List<ProdutoVendaViewModel>();

        [Display(Name = "Unix Timestamp")]
        public string Identificador
        {
            get 
            {
                return ((DateTimeOffset)Data).ToUnixTimeSeconds().ToString();
            }
        }
    
    
    
    }

}


