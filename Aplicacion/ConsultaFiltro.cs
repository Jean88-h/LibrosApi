using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Uttt.Micro.Libro.Modelo;
using Uttt.Micro.Libro.Persistencia;

namespace Uttt.Micro.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriasMaterial
                    .FirstOrDefaultAsync(x => x.LibreriaMaterialId == request.LibroId, cancellationToken);

                if (libro == null)
                {
                    throw new Exception("No se encontró el libro");
                }

                return _mapper.Map<LibroMaterialDto>(libro);
            }
        }
    }
}