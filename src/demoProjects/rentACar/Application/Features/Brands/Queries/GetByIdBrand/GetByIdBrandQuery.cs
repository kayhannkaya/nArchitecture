using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListBrand;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery:IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand brand=await _brandRepository.GetAsync(b => b.Id == request.Id);
                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);
                return brandGetByIdDto;
            }
        }
    }
}
