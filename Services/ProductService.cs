using AutoMapper;
using Grpc.Core;
using gRPCwithDotnet.Data;
using gRPCwithDotnet.Data.Interfaces;
using gRPCwithDotnet.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace gRPCwithDotnet.Services
{
    public class ProductService : product.productBase
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(IProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<CreateProductResponse> ProductCreate(CreateProductRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Description))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Field description"));
            return await _context.ProductCreate(_mapper.Map<Product>(request));
        }

        public override async  Task<GetAllProductResponse> ProductGetAll(GetAllProductRequest request, ServerCallContext context)
        {
            var model = await _context.ProductGetAll();
            if(!model.Any()) throw new RpcException(new Status(StatusCode.DataLoss, "Not Model"));
            return _mapper.Map<GetAllProductResponse>(model);
        }

        public override async Task<GetProductResponse> ProductGetSingle(GetProductSingleRequest request, ServerCallContext context)
        {
            if (request.Id < 1) throw new RpcException(new Status(StatusCode.InvalidArgument, "Id error"));
            var model = await _context.ProductGetSingle(request.Id);
            if(model is null) throw new RpcException(new Status(StatusCode.DataLoss, "Not Model"));
            return _mapper.Map<GetProductResponse>(model);
        }

        public override async Task<UpdateProductResponse> ProductUpdate(UpdateProductRequest request, ServerCallContext context)
        {
            if (request.Id < 1) throw new RpcException(new Status(StatusCode.InvalidArgument, "Id error"));
            var model = await _context.ProductUpdate(_mapper.Map<Product>(request));
            return new UpdateProductResponse
            {
                Id = model.Id
            };
        }

        public override async Task<DeleteProductResponse> ProductDelete(DeleteProductRequest request, ServerCallContext context)
        {
            if (request.Id < 1) throw new RpcException(new Status(StatusCode.InvalidArgument, "Id error"));
            var model =  await _context.ProductDelete(request.Id);
            return new DeleteProductResponse
            {
                Id = model.Id
            };
        }
    }
}
