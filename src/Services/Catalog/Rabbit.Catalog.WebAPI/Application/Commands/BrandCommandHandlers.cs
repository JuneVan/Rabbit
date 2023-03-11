namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class BrandCommandHandlers : IRequestHandler<CreateBrandCommand, int>, IRequestHandler<UpdateBrandCommand>, IRequestHandler<DeleteBrandCommand>
    {
        private readonly IRepository<Brand> _brandRepository;
        public BrandCommandHandlers(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand(request.Name, request.Description, request.Logo);
            var brandId = await _brandRepository.InsertAndGetIdAsync(brand);
            await _brandRepository.UnitOfWork.CommitAsync();
            return brandId;
        }

        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FirstOrDefaultAsync(request.Id);
            if (brand == null) throw new EntityNotFoundException(typeof(Brand), request.Id);
            brand.SetName(request.Name);
            brand.SetDescription(request.Description);
            brand.SetLogo(request.Logo);
            await _brandRepository.UpdateAsync(brand);
            await _brandRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.FirstOrDefaultAsync(request.Id);
            if (brand == null) throw new EntityNotFoundException(typeof(Brand), request.Id);

            // TODO:检查商品引用

            await _brandRepository.DeleteAsync(brand);
            await _brandRepository.UnitOfWork.CommitAsync();
        }
    }
}
