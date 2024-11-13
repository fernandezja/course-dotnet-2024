using Esculturas.Core.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esculturas.Core.Entidades
{
    public class ContenidoPaginado<T> where T : IItemPaginado
    {
        public int PageIndex { get; set; }
        public long PageSize { get; set; }
        public long RowTotalCount { get; set; }
        public List<T> Items { get; private set; }

        public void SetItems(List<T> items) {

            if (items.Any())
            {
                RowTotalCount = items.First().RowTotalCount;
            }
            
            this.Items = items;
        }

        public bool ExisteSiguiente
        {
            get {
                return ((PageIndex * PageSize) < RowTotalCount);
            }
        }

        public bool ExisteAnterior
        {
            get
            {
                return (PageIndex > 1);
            }
        }


        public int PaginaSiguiente
        {
            get
            {
                if (ExisteSiguiente)
                {
                    return PageIndex + 1;
                }

                return PageIndex;
            }
        }

        public int PaginaAnterior
        {
            get
            {
                if (ExisteAnterior)
                {
                    return PageIndex - 1;
                }

                return 1;
            }
        }
    }
}
