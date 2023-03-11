using Unit = Rabbit.Catalog.AggregateModels.UnitAggregate.Unit;

namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class UnitCommandHandlers : IRequestHandler<CreateUnitCommand, int>, IRequestHandler<UpdateUnitCommand>, IRequestHandler<DeleteUnitCommand>
    {
        private readonly IRepository<Unit> _unitRepository;
        public UnitCommandHandlers(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<int> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = new Unit(request.Name, request.IsActive);
            var unitId = await _unitRepository.InsertAndGetIdAsync(unit);
            await _unitRepository.UnitOfWork.CommitAsync();
            return unitId;
        }

        public async Task Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitRepository.FirstOrDefaultAsync(request.Id);
            if (unit == null)
                throw new EntityNotFoundException(typeof(Unit), request.Id);
            unit.SetName(request.Name);
            unit.SetIsActive(request.IsActive);
            await _unitRepository.UpdateAsync(unit);
            await _unitRepository.UnitOfWork.CommitAsync();

        }

        public async Task Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitRepository.FirstOrDefaultAsync(request.Id);
            if (unit == null) throw new EntityNotFoundException(typeof(Unit), request.Id);

            // TODO:检查商品引用

            await _unitRepository.DeleteAsync(unit);
            await _unitRepository.UnitOfWork.CommitAsync();
        }
    }
}
